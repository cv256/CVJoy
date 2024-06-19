#include <TimerOne.h> // found here: https://github.com/PaulStoffregen/TimerOne.git  unzip it into C: Program Files (x86) Arduino libraries 
#include <Wire.h>
// https://arduino-info.wikispaces.com/Timers-Arduino       https://forum.arduino.cc/index.php?topic=72092.0
// Arduino 2560 has 15 pins supporting PWM, from 2 to 13 and 44, 45, 46
// the PWM default frequency is 490 Hz for all pins, with the exception of Timer0 (pin 13 and 4), whose frequency is 980 Hz? In the Arduino firmware all timers were configured to a 1kHz frequency and interrupts are generally enabled?
// All timers depend on the system clock of your Arduino system. Normally the system clock is 16MHz
// This is the list of timers in Arduino Mega 2560:
// timer 0 8 bit (controls pin 4, 13) used for delay, millis, micros
// timer 1 16 bit (controls pin 11, 12) used by Timer1, TimerOne libraries
// timer 2 8 bit (controls pin 9, 10) used for tone
// timer 3 16 bit (controls pin 2, 3, 5) used by servo library, used by Timer3 library
// timer 4 16 bit (controls pin 6, 7, 8)
// timer 5 16 bit (controls pin 44, 45, 46)
// Setting   Divisor   Frequency Hz
// 0x01         1        31372.55
// 0x02         8         3921.16
// 0x03        32          980.39
// 0x04        64          490.20   <--DEFAULT
// 0x05       128          245.10
// 0x06       256          122.55
// 0x07       1024          30.64

// Arduino Mega serial ports's (also known as a UART or USART) pins:
//   serial: 0(RX), 1(TX)  ,  serial1: 19(RX), 18(TX)  ,  serial2: 17(RX), 16(TX)  ,  seria3: 15(RX), 14(TX)
// On Uno, Nano, Mini, and Mega, pins 0 and 1 are used for communication with the computer via USB. Connecting anything to these pins can interfere with that communication, including causing failed uploads to the board.
// Serial communication on pins TX/RX uses TTL logic levels (5V or 3.3V depending on the board). Don’t connect these pins directly to an RS232 serial port; they operate at +/- 12V and can damage your Arduino board.
#define serialSpeed 115200 // data rate in bits per second (baud) for serial data transmission. For communicating with the computer, use one of these rates: 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, or 115200. The highest without error seems to be actually 115200 - which is the standard

// external hardware -> arduino :
#define pinZeroCrossDetector  19 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pinLeftUSSend 14
#define pinLeftUSRead 15
#define pinRightUSSend 17
#define pinRightUSRead 16

// #define pinLeftMotorPower  8
// #define pinLeftMotorDir1  24
// #define pinLeftMotorDir2  25

// #define pinRightMotorPower  9
// #define pinRightMotorDir1  26
// #define pinRightMotorDir2  27

#define pinWindMotor  10 // LED_BUILTIN=13
#define pinShakeMotor 7

byte serialReceived[7];
byte serialReceivedIdx;
byte errors; // 1=not receiving data / 2=got invalid data from computer
unsigned long lastSerialRecv;
unsigned long lastMainsZero;
//unsigned long dimmerLeftDelay;
//unsigned long dimmerRightDelay;
//unsigned long dimmerWindDelay; bool windOn; byte windMotorPower;
unsigned long shakeOnTime; unsigned long shakeDuty; bool shakeOn; byte shakeMotorPower; long shakeDelay;

//char leftMotorPower;// -127 to 127
//char rightMotorPower;// -127 to 127

unsigned int every30Hz;

void setup()
{
  // external hardware -> arduino :
  pinMode(pinZeroCrossDetector, INPUT);
  pinMode(pinLeftUSSend, OUTPUT);
  pinMode(pinLeftUSRead, INPUT);
  pinMode(pinRightUSSend, OUTPUT);
  pinMode(pinRightUSRead, INPUT);

  // arduino -> external hardware
  // pitch and roll :
  // pinMode(pinLeftMotorPower, OUTPUT);
  // pinMode(pinLeftMotorDir1, OUTPUT);
  // pinMode(pinLeftMotorDir2, OUTPUT);
  // pinMode(pinRightMotorPower, OUTPUT);
  // pinMode(pinRightMotorDir1, OUTPUT);
  // pinMode(pinRightMotorDir2, OUTPUT);
  // wind & shake :
  pinMode(pinWindMotor, OUTPUT);
  pinMode(pinShakeMotor, OUTPUT);

  pinMode(LED_BUILTIN, OUTPUT);

  noInterrupts();           // disable all interrupts

  // all AC Dimmers :
  attachInterrupt(digitalPinToInterrupt(pinZeroCrossDetector), zero_cross_ISR, RISING);// this happens 100 times per second, 100Hz
  // Zero cross (half sinewave) happens every 10ms (1000ms/50Hz/2), so there is a 10ms period that we can use to regulate power using PWM (Pulse Width Modulation - leading edge cut)
  // 10ms/255 =~ 0,039ms = 39 microseconds, 25641 times per second, 26KHz!   If we are not usign PWM.  If using PSM (Pulse Skip Modulation)

  //Timer1.initialize(300); // 300 microseconds = 3333 times per second, over 100Hz means 33 steps
  //Timer1.attachInterrupt( timer3333 );

  interrupts();           // enable all interrupts

  // start communication from/to the computer via USB:
  SerialReset();
} //...setup



void loop()
{
  // joyff + game -> pc -> ARDUINO:
  if (Serial.available() > 0) { // data that’s already arrived and stored in the serial receive buffer (which holds 64 bytes)
    serialReceived[serialReceivedIdx] = Serial.read();
    serialReceivedIdx++;

    if (serialReceivedIdx < 7) {
      goto noData;
    }

    // READ from computer / write to hardware: --------------------- must be equal to CVJoyAc.SerialSend
    if ( serialReceived[0] != 255) {
      shift1();
      goto noData;
    }

    byte chk1 = serialReceived[1];
    byte chk2 = (byte)255 - ( serialReceived[2] ^ serialReceived[3] ^ serialReceived[4] ^ serialReceived[5] ^ serialReceived[6] );
    if (chk1 != chk2) {
      shift1();
      errors = errors | 2;
      //digitalWrite(LED_BUILTIN, HIGH);
      goto noData;
    }

    //digitalWrite(LED_BUILTIN, LOW);
    serialReceivedIdx = 0;
    lastSerialRecv = millis();

    analogWrite(pinWindMotor , serialReceived[2]); //windMotorPower = serialReceived[3];

    if (serialReceived[3] == 0 || serialReceived[4] == 0) {
      shakeMotorPower = 0;
      shakeOnTime = 0;
      shakeDuty = 0;
      shakeOn = false;
      analogWrite(pinShakeMotor, 0);
    } else {
      shakeMotorPower = serialReceived[3];
      shakeDelay = (unsigned long)256 - (unsigned long)serialReceived[4]; // 255~1
      shakeDuty = shakeDelay * 256  ;
      shakeDelay = ( shakeDelay * shakeDelay ); // 65025~1
      //shakeDuty = shakeDelay + 6500 ; // 71525~6500
      shakeDelay = (unsigned long)4 * shakeDelay;
    }
  }

noData:

  // if we lost communication with the computer stop the motors, dont let them in the last state or they will make ugly damage !
  if (millis() - lastSerialRecv > 200) { // 200 = 5 fps , lower than that and it will start bumping

    //digitalWrite(pinLeftMotorPower, LOW);
    //digitalWrite(pinRightMotorPower, LOW);
    //leftMotorPower = 0;
    //rightMotorPower = 0;

    analogWrite(pinWindMotor, 0);//digitalWrite(pinWindMotor, LOW);    //windMotorPower = 0;

    analogWrite(pinShakeMotor, 0);
    shakeMotorPower = 0;

    // SerialReset();
    errors = errors | 1;
  }

  if (micros() - lastMainsZero > 11000) errors += 16; // No Mains power / MainsPower freq lower than 50Hz+10%

  // send to PC:
  every30Hz++;
  if ( every30Hz >= 4000 ) {
    every30Hz = 0;    
    byte serialWrite[1]; // must be equal to CVJoyAc.SerialRead
    serialWrite[0] = 253; // checkdigit
    serialWrite[1] = errors;
    Serial.write(serialWrite, 8);
    if (errors & 1) return; // if we lost communication we have just stopped the motors and dont want the following code to power them again
  }

  // control 24v DC motors
  if (shakeMotorPower != 0) {
    if (!shakeOn) {
      if (micros() >= shakeOnTime + shakeDelay) {
        shakeOn = true;
        analogWrite(pinShakeMotor, shakeMotorPower);
        shakeOnTime = micros();
      }
    } else {
      if (micros() >= shakeOnTime + shakeDuty) {
        shakeOn = false;
        analogWrite(pinShakeMotor, 0);
      }
    }
  }

  /*
    // Read Left Distance :
    digitalWrite(pinLeftUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
    delayMicroseconds(12);
    digitalWrite(pinLeftUSSend, LOW);
    tmpUInt=pulseIn(pinLeftUSRead, HIGH, 2100); // microseconds of (total) sound travel, timeout at 70cm;
    serialWrite[11]=tmpUInt & 255;
    serialWrite[12]=tmpUInt / 256;
    // Read Right Distance :
    digitalWrite(pinRightUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
    delayMicroseconds(12);
    digitalWrite(pinRightUSSend, LOW);
    tmpUInt=pulseIn(pinRightUSRead, HIGH, 2100); // microseconds of (total) sound travel, timeout at 70cm;
    serialWrite[13]=tmpUInt & 255;
    serialWrite[14]=tmpUInt / 256;
    // TODO: define the motors powers based of the actual positions versus the desired position
   */

  // control 220v AC motors:
  triacs();

} //...loop


void shift1() {
  for( int i=0 ; i<serialReceivedIdx ; i++){
      serialReceived[i] = serialReceived[i+1];  
  }
  serialReceivedIdx -= 1;
}


void zero_cross_ISR() {
  // frequency of AC signal is 50 Hz so the time period will be 1/f, which will be 20ms, half cycle is 10ms or 10000 microseconds. Hence the range of “Delay” can be varied from 0-10000 microseconds

  //Serial.println( (int)( (float)(micros()-zero_cross) / (float)10 ) );

  lastMainsZero = micros();

  /*
    if (leftMotorPower == 0) { // zero:
    dimmerLeftDelay = 0;
    digitalWrite(pinLeftMotorPower, LOW);
    } else {
    if (leftMotorPower < 0) {
      digitalWrite(pinLeftMotorDir1, LOW);
      digitalWrite(pinLeftMotorDir2, LOW);
    } else {
      digitalWrite(pinLeftMotorDir1, HIGH);
      digitalWrite(pinLeftMotorDir2, HIGH);
    }
    if (abs(leftMotorPower) >= 127) { // full power:
      dimmerLeftDelay = 0;
      digitalWrite(pinLeftMotorPower, HIGH);
    } else { // dim:
      dimmerLeftDelay = lastMainsZero + (127 - abs(leftMotorPower)) * 70;
      digitalWrite(pinLeftMotorPower, LOW);
    }
    }

    if (rightMotorPower == 0) { // zero:
    dimmerRightDelay = 0;
    digitalWrite(pinRightMotorPower, LOW);
    } else {
    if (rightMotorPower < 0) {
      digitalWrite(pinRightMotorDir1, HIGH);
      digitalWrite(pinRightMotorDir2, HIGH);
    } else {
      digitalWrite(pinRightMotorDir1, LOW);
      digitalWrite(pinRightMotorDir2, LOW);
    }
    if (abs(rightMotorPower) >= 127) { // full power:
      dimmerRightDelay = 0;
      digitalWrite(pinRightMotorPower, HIGH);
    } else { // dim:
      dimmerRightDelay = lastMainsZero + (127 - abs(rightMotorPower)) * 70;
      digitalWrite(pinRightMotorPower, LOW);
    }
    }
  */

  /* PSM:
    dimmerWindDelay += windMotorPower;
    if (dimmerWindDelay >= 255) {
    digitalWrite(pinWindMotor, HIGH);
    dimmerWindDelay = dimmerWindDelay % 255;
    }
  */
  /* 220v PWM:
    digitalWrite(pinWindMotor, LOW);
    windOn = false;
    if (windMotorPower == 0) { // zero:
    dimmerWindDelay = 0;
    } else {
    dimmerWindDelay = lastMainsZero + (255 - windMotorPower) * 35;
    }
  */
  /* 12v PSM+PWM:
    dimmershakeOnTime += shakeMotorSpeed;
    if (dimmershakeOnTime >= 255) {
    analogWrite(pinShakeMotor, shakeMotorPower);
    dimmershakeOnTime = dimmershakeOnTime % 255;
    }
    else {
    if (dimmershakeOnTime > 10 - shakeMotorSpeed / 13) {
      analogWrite(pinShakeMotor, 0);
    }
    }*/
}



void triacs() {
  // manage TRIAC DIMMING:   learn on http://www.alfadex.com/2014/02/dimming-230v-ac-with-arduino-2/

  /*
    if (dimmerLeftDelay != 0) {
    if (micros() >= dimmerLeftDelay) {
      digitalWrite(pinLeftMotorPower, HIGH);
      dimmerLeftDelay = 0;
    }
    }

    if (dimmerRightDelay != 0) {
    if (micros() >= dimmerRightDelay) {
      digitalWrite(pinRightMotorPower, HIGH);
      dimmerRightDelay = 0;
    }
    }
  */
  /*
    if (dimmerWindDelay != 0) {
      if (!windOn) {
        if (micros() >= dimmerWindDelay) {
          windOn = true;
          digitalWrite(pinWindMotor, HIGH);
        }
      } else {
        if (micros() >= dimmerWindDelay + 15) { // the triac's gate dont need to be High for the whole cycle, about 10us is the time you need to make sure the TRIAC got on
          dimmerWindDelay = 0;
          windOn = false;
          digitalWrite(pinWindMotor, LOW);
        }
      }
    }
  */
  /*
    if (micros()-lastMainsZero > 15) { // the triac's gate dont need to be High for the whole cycle, about 10us is the time you need to make sure the TRIAC got on
    digitalWrite(pinWindMotor, LOW);
    }
  */

  /*
    if (dimmershakeOnTime != 0) {
    if (micros() >= dimmershakeOnTime) {
      digitalWrite(pinShakeMotor, HIGH);
      dimmershakeOnTime = 0;
    }
    }
  */
}



void SerialReset () {
  // Serial.end(); end and begin operations are async and take time, we would need to wait for some time before we can begin again
  // serial communications throught USB :   the highest rate without error seems to be actually 115200 - which is the standard...
  Serial.begin(serialSpeed); // data rate in bits per second (baud) for serial data transmission. For communicating with the computer, use one of these rates: 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, or 115200
}
