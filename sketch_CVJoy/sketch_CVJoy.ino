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

#define MPU6050 0x68 // I2C address of the MPU-6050   SDA = pin 20  SCL = pin 21
#define packetLen 6 // must be equal to CVJoyAc.SerialSend.PacketLen


// external hardware -> arduino :
#define zeroCrossDetector  19 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pedalAccel  1 // analog input
#define pedalBreak  2 // analog input
#define pedalClutch  3 // analog input
#define button1 23 // esq
#define button2 26 // esq
#define button3 27 // esq
#define button4 28 // pisca
#define button5 29 // pisca
#define button6 31 // pisca
#define button7 41 // direita
#define button8 42 // direita
#define button9 44 // direita
#define gear1 33
#define gear2 37
#define gear3 30
#define gear4 35
#define gear5 34
#define gear6 32
#define gearR 36
#define handbrake 38

// arduino -> external hardware:
#define rpm1  39
#define rpm2  43
#define slipFront  45
#define slipBack  40

#define wheelMotorPower  6
#define wheelMotorDir1  52
#define wheelMotorDir2  53

#define pitchMotorPower  22
#define pitchMotorDir1  48
#define pitchMotorDir2  49

#define rollMotorPower  25
#define rollMotorDir1  50
#define rollMotorDir2  51

#define windMotorPower  24


//unsigned long lastLoop;
unsigned long lastSerialRecv;

unsigned long dimmerPitchDelay;
unsigned long dimmerRollDelay;
unsigned long dimmerWindDelay;

char pitchMotorPowerSpeed;// -127 to 127
char rollMotorPowerSpeed;// -127 to 127
byte windMotorPowerSpeed;// 0-255



void setup()
{
  // external hardware -> arduino :
  pinMode(zeroCrossDetector, INPUT);
  pinMode(pedalAccel, INPUT);
  pinMode(pedalBreak, INPUT);
  pinMode(pedalClutch, INPUT);
  pinMode(button1, INPUT_PULLUP);
  pinMode(button2, INPUT_PULLUP);
  pinMode(button3, INPUT_PULLUP);
  pinMode(button4, INPUT_PULLUP);
  pinMode(button5, INPUT_PULLUP);
  pinMode(button6, INPUT_PULLUP);
  pinMode(button7, INPUT_PULLUP);
  pinMode(button8, INPUT_PULLUP);
  pinMode(button9, INPUT_PULLUP);
  pinMode(gear1, INPUT_PULLUP);
  pinMode(gear2, INPUT_PULLUP);
  pinMode(gear3, INPUT_PULLUP);
  pinMode(gear4, INPUT_PULLUP);
  pinMode(gear5, INPUT_PULLUP);
  pinMode(gear6, INPUT_PULLUP);
  pinMode(gearR, INPUT_PULLUP);
  pinMode(handbrake, INPUT_PULLUP);
  // arduino -> external hardware
  pinMode(rpm1, OUTPUT);
  pinMode(rpm2, OUTPUT);
  pinMode(slipFront, OUTPUT);
  pinMode(slipBack, OUTPUT);
  pinMode(wheelMotorPower, OUTPUT);
  noInterrupts();           // disable all interrupts
  //TCCR4A = 0; // timer 4 controls pin 6, 7, 8
  TCCR4B = (TCCR4B & 0b11111000) | 0x03; // 0x03 gives 980Hz I red that DC motors work better with >2KHz and there may be losses above 20KHz. But I made experiments with 2 different motors and both had much better effeciency with lower frequencies. Divisor 1 and 2 makes no noise but are not effecient. Divisors bigger than 3 make the steeringwheel shiver. Diviser 3 makes some whistle but it's my choice.
  interrupts();           // enable all interrupts
  pinMode(wheelMotorDir1, OUTPUT);
  pinMode(wheelMotorDir2, OUTPUT);
  pinMode(pitchMotorPower, OUTPUT);
  pinMode(pitchMotorDir1, OUTPUT);
  pinMode(pitchMotorDir2, OUTPUT);
  pinMode(rollMotorPower, OUTPUT);
  pinMode(rollMotorDir1, OUTPUT);
  pinMode(rollMotorDir2, OUTPUT);
  pinMode(windMotorPower, OUTPUT);
  // preparing the Dimmers
  attachInterrupt(digitalPinToInterrupt(zeroCrossDetector), zero_cross_ISR, RISING);
  Timer1.initialize(100); // 100 microseconds = 10KHz = 200 times each 50Hz
  Timer1.attachInterrupt( timerIsr );
  //Turning on the Gyroscope
    // at power-up:
    //    Gyro at 250 degrees second
    //    Acceleration at 2g
    //    Clock source at internal 8MHz
    //    The device is in sleep mode.
    Wire.begin(); // join i2c bus (address optional for master)
    //Activate the MPU-6050
    Wire.beginTransmission(MPU6050);                                        //Start communicating with the MPU-6050
    Wire.write(0x6B);                                                    // PWR_MGMT_1 register
    Wire.write(0x00);                                                    // set to zero (wakes up the MPU-6050)
    Wire.endTransmission();                                             
    //Configure the accelerometer (+/-2g)
    Wire.beginTransmission(MPU6050);                                        //Start communicating with the MPU-6050
    Wire.write(0x1C);                                                    //Send the requested starting register
    Wire.write(0x00);                                                    //Set the requested starting register
    Wire.endTransmission();                                             
    //Configure the DLPF (Digital Low Pass Filter)
    Wire.beginTransmission(MPU6050);                                        //Start communicating with the MPU-6050
    Wire.write(26);                                                    //Send the requested starting register
    Wire.write(4);                                                    //Set the requested starting register 3=(44Hz@1KHz=22 samplings lag=4.8ms) 4=(21Hz@1KHz=47 samplings lag=8.5ms)  5=(10Hz@1KHz=100 samplings lag=13.8ms)
    Wire.endTransmission();                                             

  Serial.begin(115200);
} //...setup



void loop()
{

  //react to serial commands received:
  if (Serial.available() == packetLen) {
    byte wheelMotorPowerDir = Serial.read();
    if (wheelMotorPowerDir >= 254) { // checkdigit + wheelMotorPowerDir
      lastSerialRecv = millis();
      byte wheelMotorPowerSpeed = Serial.read();
      pitchMotorPowerSpeed = Serial.read() - 128; //pitchDesiredPos
      rollMotorPowerSpeed = Serial.read() - 128; //rollDesiredPos
      windMotorPowerSpeed = Serial.read();
      //leds:
      byte tmp = Serial.read();
      if (tmp & 1) {
        digitalWrite(rpm1, HIGH);
      } else {
        digitalWrite(rpm1, LOW);
      }
      if (tmp & 2) {
        digitalWrite(rpm2, HIGH);
      } else {
        digitalWrite(rpm2, LOW);
      }
      if (tmp & 4) {
        digitalWrite(slipFront, HIGH);
      } else {
        digitalWrite(slipFront, LOW);
      }
      if (tmp & 8) {
        digitalWrite(slipBack, HIGH);
      } else {
        digitalWrite(slipBack, LOW);
      }
      if (wheelMotorPowerSpeed > 0) {
        if (wheelMotorPowerDir == 254) {
          digitalWrite(wheelMotorDir1, HIGH);
          digitalWrite(wheelMotorDir2, LOW);
        } else {
          digitalWrite(wheelMotorDir1, LOW);
          digitalWrite(wheelMotorDir2, HIGH);
        }
      }
      analogWrite(wheelMotorPower, wheelMotorPowerSpeed);

      //send data to serial:   must be equal to CVJoyAc.SerialRead
      tmp = 170; // checkdigit
      if (digitalRead(button9) == LOW) tmp += 1;
      Serial.write(tmp);
      tmp = 0;
      if (digitalRead(button1) == LOW) tmp += 1;
      if (digitalRead(button2) == LOW) tmp += 2;
      if (digitalRead(button3) == LOW) tmp += 4;
      if (digitalRead(button4) == LOW) tmp += 8;
      if (digitalRead(button5) == LOW) tmp += 16;
      if (digitalRead(button6) == LOW) tmp += 32;
      if (digitalRead(button7) == LOW) tmp += 64;
      if (digitalRead(button8) == LOW) tmp += 128;
      Serial.write(tmp);
      tmp = 0;
      if (digitalRead(gear1) == LOW) tmp += 1;
      if (digitalRead(gear2) == LOW) tmp += 2;
      if (digitalRead(gear3) == LOW) tmp += 4;
      if (digitalRead(gear4) == LOW) tmp += 8;
      if (digitalRead(gear5) == LOW) tmp += 16;
      if (digitalRead(gear6) == LOW) tmp += 32;
      if (digitalRead(gearR) == LOW) tmp += 64;
      if (digitalRead(handbrake) == LOW) tmp += 128;
      Serial.write(tmp);
      unsigned int n;
      n = analogRead(pedalAccel);
      Serial.write(n & 255);
      Serial.write(n / 256);
      n = analogRead(pedalBreak);
      Serial.write(n & 255);
      Serial.write(n / 256);
      n = analogRead(pedalClutch);
      Serial.write(n & 255);
      Serial.write(n / 256);

      // Read Gyroscope :
      Wire.beginTransmission(MPU6050); //start transmission to device
      Wire.write(0x3B);  // starting with register 0x3B (ACCEL_XOUT_H)
      Wire.endTransmission(false);
      Wire.requestFrom(MPU6050,6,true);  // request a total of 14 registers
      Serial.write(Wire.read());  // 0x3B (ACCEL_XOUT_H) 
      Serial.write(Wire.read());  // 0x3C (ACCEL_XOUT_L)   
      Serial.write(Wire.read());  // 0x3D (ACCEL_YOUT_H)
      Serial.write(Wire.read());  // 0x3E (ACCEL_YOUT_L)
      Serial.write(Wire.read());  // 0x3F (ACCEL_ZOUT_H) 
      Serial.write(Wire.read());  // 0x40 (ACCEL_ZOUT_L)

    } //..checkdigit
  } //..if Serial.available()==packetLen

  // if we lost communication with the computer stop the motors, dont let them in the last state or they will make ugly damage !
  if (millis() - lastSerialRecv > 200) { // 200 = 5 fps , lower than that and it will start bumping
    pitchMotorPowerSpeed = 0;
    rollMotorPowerSpeed = 0;
    windMotorPowerSpeed = 0;
    analogWrite(wheelMotorPower, 0);
  }

} //...loop





void zero_cross_ISR()
{
  //Serial.println( (int)( (float)(micros()-zero_cross) / (float)10 ) );

  if (pitchMotorPowerSpeed == 0) { // zero:
    dimmerPitchDelay = 0;
    digitalWrite(pitchMotorPower, LOW);
  } else {
    if (pitchMotorPowerSpeed < 0) {
      digitalWrite(pitchMotorDir1, HIGH);
      digitalWrite(pitchMotorDir2, HIGH);
    } else {
      digitalWrite(pitchMotorDir1, LOW);
      digitalWrite(pitchMotorDir2, LOW);
    }
    if (abs(pitchMotorPowerSpeed >= 127)) { // full power:
      dimmerPitchDelay = 0;
      digitalWrite(pitchMotorPower, HIGH);
    } else { // dim:
      dimmerPitchDelay = micros() + (127 - abs(pitchMotorPowerSpeed)) * 70;
      digitalWrite(pitchMotorPower, LOW);
    }
  }

  if (rollMotorPowerSpeed == 0) { // zero:
    dimmerRollDelay = 0;
    digitalWrite(rollMotorPower, LOW);
  } else {
    if (rollMotorPowerSpeed < 0) {
      digitalWrite(rollMotorDir1, HIGH);
      digitalWrite(rollMotorDir2, HIGH);
    } else {
      digitalWrite(rollMotorDir1, LOW);
      digitalWrite(rollMotorDir2, LOW);
    }
    if (abs(rollMotorPowerSpeed >= 127)) { // full power:
      dimmerRollDelay = 0;
      digitalWrite(rollMotorPower, HIGH);
    } else { // dim:
      dimmerRollDelay = micros() + (127 - abs(rollMotorPowerSpeed)) * 70;
      digitalWrite(rollMotorPower, LOW);
    }
  }

  if (windMotorPowerSpeed == 0) { // zero:
    dimmerWindDelay = 0;
    digitalWrite(windMotorPower, LOW);
  } else {
    if (windMotorPowerSpeed == 255) { // full power:
      dimmerWindDelay = 0;
      digitalWrite(windMotorPower, HIGH);
    } else { // dim:
      dimmerWindDelay = micros() + (255 - windMotorPowerSpeed) * 35;
      digitalWrite(windMotorPower, LOW);
    }
  }

}



void timerIsr() {
  // manage TRIAC DIMMING:   learn on http://www.alfadex.com/2014/02/dimming-230v-ac-with-arduino-2/

  if (dimmerPitchDelay != 0) {
    if (micros() >= dimmerPitchDelay) {
      digitalWrite(pitchMotorPower, HIGH);
      dimmerPitchDelay = 0;
    }
  }

  if (dimmerRollDelay != 0) {
    if (micros() >= dimmerRollDelay) {
      digitalWrite(rollMotorPower, HIGH);
      dimmerRollDelay = 0;
    }
  }

  if (dimmerWindDelay != 0) {
    if (micros() >= dimmerWindDelay) {
      digitalWrite(windMotorPower, HIGH);
      dimmerWindDelay = 0;
    }
  }

}


