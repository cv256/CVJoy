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

#define packetLen 6 // must be equal to CVJoyAc.SerialSend.PacketLen

// external hardware -> arduino :
#define pinZeroCrossDetector  19 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pinWheelEncA  2 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pinWheelEncB  3 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pinPedalAccel  1 // analog input
#define pinPedalBreak  5 // analog input// A2 is damaged?...
#define pinPedalClutch  3 // analog input
#define pinHandbrake 4 // analog input
#define pinButton1 42 // ESC
#define pinButton2 37 // esq
#define pinButton3 39 // esq 
#define pinButton4 41 // pisca 
#define pinButton5 38 // pisca 
#define pinButton6 40 // pisca 
#define pinButton7 36 // direita 
#define pinButton8 35 // direita 
#define pinButton9 34 // direita 
#define pinGear1 43
#define pinGear2 48
#define pinGear3 46
#define pinGear4 44
#define pinGear5 47
#define pinGear6 45
#define pinGearR 49
#define pinLeftUSSend 14
#define pinLeftUSRead 15
#define pinRightUSSend 17
#define pinRightUSRead 16

// arduino -> external hardware:
// #define pinRpm1       29
// #define pinRpm2       30
// #define pinSlipFront  28
// #define pinSlipBack   31

#define pinWheelMotorPower  6
#define pinWheelMotorDir1  22
#define pinWheelMotorDir2  23

#define pinLeftMotorPower  8
#define pinLeftMotorDir1  24
#define pinLeftMotorDir2  25

#define pinRightMotorPower  9 
#define pinRightMotorDir1  26
#define pinRightMotorDir2  27

#define pinWindMotorPower LED_BUILTIN
#define pinShakeMotorPower  11


//unsigned long lastLoop;
unsigned long lastSerialRecv;
unsigned long lastMainsZero;
unsigned long dimmerLeftDelay;
unsigned long dimmerRightDelay;
word dimmerWindDelay;
unsigned long dimmerShakeDelay;

char leftMotorPowerSpeed;// -127 to 127
char rightMotorPowerSpeed;// -127 to 127
byte windMotorPowerSpeed;// 0-255
byte shakeMotorPowerSpeed;// 0-255

// volatile byte WheelEncAFlag = 0; // let's us know when we're expecting a rising edge on pinA to signal that the encoder has arrived at a detent
// volatile byte WheelEncBFlag = 0; // let's us know when we're expecting a rising edge on pinB to signal that the encoder has arrived at a detent (opposite direction to when aFlag is set)
volatile unsigned int wheelPosition = 32768; //this variable stores our current value of encoder position

void setup()
{
  // external hardware -> arduino :
  pinMode(pinZeroCrossDetector, INPUT);
  pinMode(pinWheelEncA, INPUT_PULLUP);
  pinMode(pinWheelEncB, INPUT_PULLUP);
  pinMode(pinPedalAccel, INPUT);
  pinMode(pinPedalBreak, INPUT);
  pinMode(pinPedalClutch, INPUT);
  pinMode(pinHandbrake, INPUT);
  pinMode(pinButton1, INPUT_PULLUP);
  pinMode(pinButton2, INPUT_PULLUP);
  pinMode(pinButton3, INPUT_PULLUP);
  pinMode(pinButton4, INPUT_PULLUP);
  pinMode(pinButton5, INPUT_PULLUP);
  pinMode(pinButton6, INPUT_PULLUP);
  pinMode(pinButton7, INPUT_PULLUP);
  pinMode(pinButton8, INPUT_PULLUP);
  pinMode(pinButton9, INPUT_PULLUP);
  pinMode(pinGear1, INPUT_PULLUP);
  pinMode(pinGear2, INPUT_PULLUP);
  pinMode(pinGear3, INPUT_PULLUP);
  pinMode(pinGear4, INPUT_PULLUP);
  pinMode(pinGear5, INPUT_PULLUP);
  pinMode(pinGear6, INPUT_PULLUP);
  pinMode(pinGearR, INPUT_PULLUP);
  pinMode(pinLeftUSSend,OUTPUT);
  pinMode(pinLeftUSRead,INPUT);
  pinMode(pinRightUSSend,OUTPUT);
  pinMode(pinRightUSRead,INPUT);

  // arduino -> external hardware
  // steeringwheel FF:
  pinMode(pinWheelMotorPower, OUTPUT);
  pinMode(pinWheelMotorDir1, OUTPUT);
  pinMode(pinWheelMotorDir2, OUTPUT);
  // pitch and roll :
  pinMode(pinLeftMotorPower, OUTPUT);
  pinMode(pinLeftMotorDir1, OUTPUT);
  pinMode(pinLeftMotorDir2, OUTPUT);
  pinMode(pinRightMotorPower, OUTPUT);
  pinMode(pinRightMotorDir1, OUTPUT);
  pinMode(pinRightMotorDir2, OUTPUT);
 // wind & shake :
  pinMode(pinWindMotorPower, OUTPUT);
  pinMode(pinShakeMotorPower, OUTPUT);

  // steeringwheel position reading :
  noInterrupts();           // disable all interrupts
  //TCCR4A = 0; // timer 4 controls pin 6, 7, 8
  TCCR4B = (TCCR4B & 0b11111000) | 0x01; // 0x03 gives 980Hz I red that DC motors work better with >2KHz and there may be losses above 20KHz. But I made experiments with 2 different motors and both had much better effeciency with lower frequencies. Divisor 1 and 2 makes no noise but are not effecient. Divisors bigger than 3 make the steeringwheel shiver. Diviser 3 makes some whistle but it's my choice.
  // preparing the steering wheel encoder :
  attachInterrupt(digitalPinToInterrupt(pinWheelEncA), doEncoderA, CHANGE);
  attachInterrupt(digitalPinToInterrupt(pinWheelEncB), doEncoderB, CHANGE);
  // all AC Dimmers :
  attachInterrupt(digitalPinToInterrupt(pinZeroCrossDetector), zero_cross_ISR, RISING);
  Timer1.initialize(100); // 10000 microseconds/255 =~ 40 microseconds !
  Timer1.attachInterrupt( timerIsr );
  interrupts();           // enable all interrupts

  // start communication from/to the computer via USB:
  SerialReset(); 
} //...setup



void loop()
{
/*  // FOR DEBUGGING :
  while ( Serial.available() ) { 
    byte x = Serial.read(); 
    Serial.write(x);
        Serial.write(x);
            Serial.write(x);
  }
*/
  if (Serial.available() >= packetLen) {  // data that’s already arrived and stored in the serial receive buffer (which holds 64 bytes)
    // READ from computer / write to hardware: --------------------- must be equal to CVJoyAc.SerialSend
    byte wheelMotorPowerDir = Serial.read(); // 0  checkdigit + wheelMotorPowerDir
	lastSerialRecv = millis();
	if (wheelMotorPowerDir == 253) { // reset whell position
	wheelPosition = 32768;
	}
	byte wheelMotorPowerSpeed = Serial.read(); // 1
	leftMotorPowerSpeed = Serial.read() - 128; // 2 
	rightMotorPowerSpeed = Serial.read() - 128; // 3
	windMotorPowerSpeed = Serial.read(); // 4
	shakeMotorPowerSpeed = Serial.read(); // 5
	if (wheelMotorPowerSpeed > 0) {
	if (wheelMotorPowerDir == 254) {
	  digitalWrite(pinWheelMotorDir1, HIGH);
	  digitalWrite(pinWheelMotorDir2, LOW);
	} else {
	  digitalWrite(pinWheelMotorDir1, LOW);
	  digitalWrite(pinWheelMotorDir2, HIGH);
	}
	}
	analogWrite(pinWheelMotorPower, wheelMotorPowerSpeed);
	// analogWrite(pinWindMotorPower, windMotorPowerSpeed);

	// read from hardware / SEND to computer : --------------------- must be equal to CVJoyAc.SerialRead
	byte tmpByte = 192; // checkdigit (64+128)
	if (digitalRead(pinButton9) == LOW) tmpByte += 32;
	if (micros()-lastMainsZero > 11000) tmpByte += 1; // No Mains power / MainsPower freq lower than 50Hz+10%
	if (wheelMotorPowerDir<253) tmpByte += 2; // Arduino got invalid data from computer
	Serial.write(tmpByte); //0
	tmpByte = 0;
	if (digitalRead(pinButton1) == LOW) tmpByte += 1;
	if (digitalRead(pinButton2) == LOW) tmpByte += 2;
	if (digitalRead(pinButton3) == LOW) tmpByte += 4;
	if (digitalRead(pinButton4) == LOW) tmpByte += 8;
	if (digitalRead(pinButton5) == LOW) tmpByte += 16;
	if (digitalRead(pinButton6) == LOW) tmpByte += 32;
	if (digitalRead(pinButton7) == LOW) tmpByte += 64;
	if (digitalRead(pinButton8) == LOW) tmpByte += 128;
	Serial.write(tmpByte);//1
	tmpByte = 0;
	if (digitalRead(pinGear1) == LOW) tmpByte += 1;
	if (digitalRead(pinGear2) == LOW) tmpByte += 2;
	if (digitalRead(pinGear3) == LOW) tmpByte += 4;
	if (digitalRead(pinGear4) == LOW) tmpByte += 8;
	if (digitalRead(pinGear5) == LOW) tmpByte += 16;
	if (digitalRead(pinGear6) == LOW) tmpByte += 32;
	if (digitalRead(pinGearR) == LOW) tmpByte += 64;
	if (digitalRead(pinHandbrake) == LOW) tmpByte += 128;
	Serial.write(tmpByte);//2
	unsigned int tmpUInt;
	tmpUInt = analogRead(pinPedalAccel);
	Serial.write(tmpUInt & 255);//3
	Serial.write(tmpUInt / 256);//4
	tmpUInt = analogRead(pinPedalBreak);
	Serial.write(tmpUInt & 255);//5
	Serial.write(tmpUInt / 256);//6
	tmpUInt = analogRead(pinPedalClutch);
	Serial.write(tmpUInt & 255);//7
	Serial.write(tmpUInt / 256);//8
	Serial.write(wheelPosition & 255);//9
	Serial.write(wheelPosition / 256);//10

	// Read Left Distance :
	digitalWrite(pinLeftUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
	delayMicroseconds(12);
	digitalWrite(pinLeftUSSend, LOW);
	tmpUInt=pulseIn(pinLeftUSRead, HIGH, 2100); // microseconds of (total) sound travel, timeout at 70cm;
	Serial.write(tmpUInt & 255);//11
	Serial.write(tmpUInt / 256);//12
	// Read Right Distance :
	digitalWrite(pinRightUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
	delayMicroseconds(12);
	digitalWrite(pinRightUSSend, LOW);
	tmpUInt=pulseIn(pinRightUSRead, HIGH, 2100); // microseconds of (total) sound travel, timeout at 70cm;
	Serial.write(tmpUInt & 255);//13
	Serial.write(tmpUInt / 256);//14


    // waste eventual excessive data :   (communication error)
    while ( Serial.available() ) { 
      byte x = Serial.read(); 
    }

  } //..if Serial.available()==packetLen

  // if we lost communication with the computer stop the motors, dont let them in the last state or they will make ugly damage !
  if (millis() - lastSerialRecv > 200) { // 200 = 5 fps , lower than that and it will start bumping
    digitalWrite(pinLeftMotorPower, LOW);
    digitalWrite(pinRightMotorPower, LOW);
    digitalWrite(pinWindMotorPower, LOW);
    digitalWrite(pinShakeMotorPower, LOW);
    analogWrite(pinWheelMotorPower, 0);
    leftMotorPowerSpeed = 0;
    rightMotorPowerSpeed = 0;
    windMotorPowerSpeed = 0;
    shakeMotorPowerSpeed = 0;
	  // SerialReset();
  }

} //...loop




void zero_cross_ISR()
{
// frequency of AC signal is 50 Hz so the time period will be 1/f, which will be 20ms, half cycle is 10ms or 10000 microseconds. Hence the range of “Delay” can be varied from 0-10000 microseconds
  
  //Serial.println( (int)( (float)(micros()-zero_cross) / (float)10 ) );
  
  lastMainsZero=micros();
  
  if (leftMotorPowerSpeed == 0) { // zero:
    dimmerLeftDelay = 0;
    digitalWrite(pinLeftMotorPower, LOW);
  } else {
    if (leftMotorPowerSpeed < 0) {
      digitalWrite(pinLeftMotorDir1, LOW);
      digitalWrite(pinLeftMotorDir2, LOW);
    } else {
      digitalWrite(pinLeftMotorDir1, HIGH);
      digitalWrite(pinLeftMotorDir2, HIGH);
    }
    if (abs(leftMotorPowerSpeed) >= 127) { // full power:
      dimmerLeftDelay = 0;
      digitalWrite(pinLeftMotorPower, HIGH);
    } else { // dim:
      dimmerLeftDelay = lastMainsZero + (127 - abs(leftMotorPowerSpeed)) * 70;
      digitalWrite(pinLeftMotorPower, LOW);
    }
  }

  if (rightMotorPowerSpeed == 0) { // zero:
    dimmerRightDelay = 0;
    digitalWrite(pinRightMotorPower, LOW);
  } else {
    if (rightMotorPowerSpeed < 0) {
      digitalWrite(pinRightMotorDir1, HIGH);
      digitalWrite(pinRightMotorDir2, HIGH);
    } else {
      digitalWrite(pinRightMotorDir1, LOW);
      digitalWrite(pinRightMotorDir2, LOW);
    }
    if (abs(rightMotorPowerSpeed) >= 127) { // full power:
      dimmerRightDelay = 0;
      digitalWrite(pinRightMotorPower, HIGH);
    } else { // dim:
      dimmerRightDelay = lastMainsZero + (127 - abs(rightMotorPowerSpeed)) * 70;
      digitalWrite(pinRightMotorPower, LOW);
    }
  }

  dimmerWindDelay += windMotorPowerSpeed;
  if (dimmerWindDelay >= 255) {
    digitalWrite(pinWindMotorPower, HIGH);
    dimmerWindDelay = dimmerWindDelay % 255;
  } /* else {
    digitalWrite(pinWindMotorPower, LOW); // this is done in the timerIsr()
  } */

  if (shakeMotorPowerSpeed == 0) { // zero:
    dimmerShakeDelay = 0;
    digitalWrite(pinShakeMotorPower, LOW);
  } else {
    if (shakeMotorPowerSpeed == 255) { // full power:
      dimmerShakeDelay = 0;
      digitalWrite(pinShakeMotorPower, HIGH);
    } else { // dim:
      dimmerShakeDelay = lastMainsZero + (255 - shakeMotorPowerSpeed) * 35;
      digitalWrite(pinShakeMotorPower, LOW);
    }
  }
  
}



void timerIsr() {
  // manage TRIAC DIMMING:   learn on http://www.alfadex.com/2014/02/dimming-230v-ac-with-arduino-2/

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

  if (micros()-lastMainsZero > 1000) { // the triac's gate dont need to be High for the whole cycle
    digitalWrite(pinWindMotorPower, LOW); 
  }

  if (dimmerShakeDelay != 0) {
    if (micros() >= dimmerShakeDelay) {
      digitalWrite(pinShakeMotorPower, HIGH);
      dimmerShakeDelay = 0;
    }
  }
}


void doEncoderA() {
    noInterrupts();           // disable all interrupts
  // look for a low-to-high on channel A
  if (digitalRead(pinWheelEncA) == HIGH) {
    // check channel B to see which way encoder is turning
    if (digitalRead(pinWheelEncB) == LOW) {
      wheelPosition += 1;         // CW
    }
    else {
      wheelPosition -= 1;         // CCW
    }
  }
  else   // must be a high-to-low edge on channel A
  {
    // check channel B to see which way encoder is turning
    if (digitalRead(pinWheelEncB) == HIGH) {
      wheelPosition += 1;          // CW
    }
    else {
      wheelPosition -= 1;          // CCW
    }
  }
    interrupts();           // disable all interrupts
}

void doEncoderB() {
    noInterrupts();           // disable all interrupts
  // look for a low-to-high on channel B
  if (digitalRead(pinWheelEncB) == HIGH) {
    // check channel A to see which way encoder is turning
    if (digitalRead(pinWheelEncA) == HIGH) {
      wheelPosition += 1;         // CW
    }
    else {
      wheelPosition -= 1;         // CCW
    }
  }
  // Look for a high-to-low on channel B
  else {
    // check channel B to see which way encoder is turning
    if (digitalRead(pinWheelEncA) == LOW) {
      wheelPosition += 1;          // CW
    }
    else {
      wheelPosition -= 1;          // CCW
    }
  }
    interrupts();           // enable all interrupts
}

void SerialReset () {
 // Serial.end(); end and begin operations are async and take time, we would need to wait for some time before we can begin again
 // serial communications throught USB :   the highest rate without error seems to be actually 115200 - which is the standard... 
 Serial.begin(serialSpeed); // data rate in bits per second (baud) for serial data transmission. For communicating with the computer, use one of these rates: 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, or 115200
}
