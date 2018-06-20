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

#define packetLen 7 // must be equal to CVJoyAc.SerialSend.PacketLen

//  LIVRES  pins digitais : 47, 18, 20, 21 -----------------------------------

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
#define leftUSSend 14
#define leftUSRead 15
#define rightUSSend 17
#define rightUSRead 16

// arduino -> external hardware:
#define rpm1  39
#define rpm2  43
#define slipFront  45
#define slipBack  40

#define wheelMotorPower  6
#define wheelMotorDir1  52
#define wheelMotorDir2  53

#define leftMotorPower  25
#define leftMotorDir1  50
#define leftMotorDir2  51

#define rightMotorPower  22 
#define rightMotorDir1  48
#define rightMotorDir2  49

#define windMotorPower  46
#define shakeMotorPower  24


//unsigned long lastLoop;
unsigned long lastSerialRecv;
unsigned long lastMainsZero;
unsigned long dimmerLeftDelay;
unsigned long dimmerRightDelay;
unsigned long dimmerWindDelay;
unsigned long dimmerShakeDelay;

char leftMotorPowerSpeed;// -127 to 127
char rightMotorPowerSpeed;// -127 to 127
byte windMotorPowerSpeed;// 0-255
byte shakeMotorPowerSpeed;// 0-255



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
  pinMode(leftUSSend,OUTPUT);
  pinMode(leftUSRead,INPUT);
  pinMode(rightUSSend,OUTPUT);
  pinMode(rightUSRead,INPUT);

  // arduino -> external hardware
  pinMode(rpm1, OUTPUT);
  pinMode(rpm2, OUTPUT);
  pinMode(slipFront, OUTPUT);
  pinMode(slipBack, OUTPUT);
  // preparing the steeringwheel :
  pinMode(wheelMotorPower, OUTPUT);
  noInterrupts();           // disable all interrupts
  //TCCR4A = 0; // timer 4 controls pin 6, 7, 8
  TCCR4B = (TCCR4B & 0b11111000) | 0x03; // 0x03 gives 980Hz I red that DC motors work better with >2KHz and there may be losses above 20KHz. But I made experiments with 2 different motors and both had much better effeciency with lower frequencies. Divisor 1 and 2 makes no noise but are not effecient. Divisors bigger than 3 make the steeringwheel shiver. Diviser 3 makes some whistle but it's my choice.
  interrupts();           // enable all interrupts
  pinMode(wheelMotorDir1, OUTPUT);
  pinMode(wheelMotorDir2, OUTPUT);
  // preparing the pitch and roll :
  pinMode(leftMotorPower, OUTPUT);
  pinMode(leftMotorDir1, OUTPUT);
  pinMode(leftMotorDir2, OUTPUT);
  pinMode(rightMotorPower, OUTPUT);
  pinMode(rightMotorDir1, OUTPUT);
  pinMode(rightMotorDir2, OUTPUT);
  pinMode(windMotorPower, OUTPUT);
  pinMode(shakeMotorPower, OUTPUT);
  // preparing the mains Dimmers :
  attachInterrupt(digitalPinToInterrupt(zeroCrossDetector), zero_cross_ISR, RISING);
  Timer1.initialize(100); // 100 microseconds = 10KHz = 200 times each 50Hz
  Timer1.attachInterrupt( timerIsr );
  
  Serial.begin(115200);
} //...setup



void loop()
{

  if (Serial.available() == packetLen) {
    // READ from computer / write to hardware: --------------------- must be equal to CVJoyAc.SerialSend
    byte wheelMotorPowerDir = Serial.read(); // 0
    if (wheelMotorPowerDir >= 254) { // checkdigit + wheelMotorPowerDir
      lastSerialRecv = millis();
      byte wheelMotorPowerSpeed = Serial.read(); // 1
      leftMotorPowerSpeed = Serial.read() - 128; // 2 
      rightMotorPowerSpeed = Serial.read() - 128; // 3
      windMotorPowerSpeed = Serial.read(); // 4
      shakeMotorPowerSpeed = Serial.read(); // 5
      //leds:
      byte tmpByte = Serial.read(); // 6
      if (tmpByte & 1) {
        digitalWrite(rpm1, HIGH);
      } else {
        digitalWrite(rpm1, LOW);
      }
      if (tmpByte & 2) {
        digitalWrite(rpm2, HIGH);
      } else {
        digitalWrite(rpm2, LOW);
      }
      if (tmpByte & 4) {
        digitalWrite(slipFront, HIGH);
      } else {
        digitalWrite(slipFront, LOW);
      }
      if (tmpByte & 8) {
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

      // read from hardware / SEND to computer : --------------------- must be equal to CVJoyAc.SerialRead
      tmpByte = 192; // checkdigit (64+128)
      if (digitalRead(button9) == LOW) tmpByte += 32;
      if (micros()-lastMainsZero > 11000) tmpByte += 1; // No Mains power / MainsPower freq lower than 50Hz+10%
      if (wheelMotorPowerDir<254) tmpByte += 2; // Arduino got invalid data from computer
      Serial.write(tmpByte); //0
      tmpByte = 0;
      if (digitalRead(button1) == LOW) tmpByte += 1;
      if (digitalRead(button2) == LOW) tmpByte += 2;
      if (digitalRead(button3) == LOW) tmpByte += 4;
      if (digitalRead(button4) == LOW) tmpByte += 8;
      if (digitalRead(button5) == LOW) tmpByte += 16;
      if (digitalRead(button6) == LOW) tmpByte += 32;
      if (digitalRead(button7) == LOW) tmpByte += 64;
      if (digitalRead(button8) == LOW) tmpByte += 128;
      Serial.write(tmpByte);//1
      tmpByte = 0;
      if (digitalRead(gear1) == LOW) tmpByte += 1;
      if (digitalRead(gear2) == LOW) tmpByte += 2;
      if (digitalRead(gear3) == LOW) tmpByte += 4;
      if (digitalRead(gear4) == LOW) tmpByte += 8;
      if (digitalRead(gear5) == LOW) tmpByte += 16;
      if (digitalRead(gear6) == LOW) tmpByte += 32;
      if (digitalRead(gearR) == LOW) tmpByte += 64;
      if (digitalRead(handbrake) == LOW) tmpByte += 128;
      Serial.write(tmpByte);//2
      unsigned int tmpUInt;
      tmpUInt = analogRead(pedalAccel);
      Serial.write(tmpUInt & 255);//3
      Serial.write(tmpUInt / 256);//4
      tmpUInt = analogRead(pedalBreak);
      Serial.write(tmpUInt & 255);//5
      Serial.write(tmpUInt / 256);//6
      tmpUInt = analogRead(pedalClutch);
      Serial.write(tmpUInt & 255);//7
      Serial.write(tmpUInt / 256);//8

      // Read Left Distance :
      digitalWrite(leftUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
      delayMicroseconds(12);
      digitalWrite(leftUSSend, LOW);
      tmpUInt=pulseIn(leftUSRead, HIGH, 35000); // microseconds of (total) sound travel;
      Serial.write(tmpUInt & 255);//9
      Serial.write(tmpUInt / 256);//10
      // Read Right Distance :
      digitalWrite(rightUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
      delayMicroseconds(12);
      digitalWrite(rightUSSend, LOW);
      tmpUInt=pulseIn(rightUSRead, HIGH, 35000); // microseconds of (total) sound travel;
      Serial.write(tmpUInt & 255);//11
      Serial.write(tmpUInt / 256);//12

    } //..checkdigit
  } //..if Serial.available()==packetLen

  // if we lost communication with the computer stop the motors, dont let them in the last state or they will make ugly damage !
  if (millis() - lastSerialRecv > 200) { // 200 = 5 fps , lower than that and it will start bumping
    digitalWrite(leftMotorPower, LOW);
    digitalWrite(rightMotorPower, LOW);
    digitalWrite(windMotorPower, LOW);
    digitalWrite(shakeMotorPower, LOW);
    analogWrite(wheelMotorPower, 0);
    leftMotorPowerSpeed = 0;
    rightMotorPowerSpeed = 0;
    windMotorPowerSpeed = 0;
    shakeMotorPowerSpeed = 0;
  }

} //...loop





void zero_cross_ISR()
{
  //Serial.println( (int)( (float)(micros()-zero_cross) / (float)10 ) );
  lastMainsZero=micros();
  if (leftMotorPowerSpeed == 0) { // zero:
    dimmerLeftDelay = 0;
    digitalWrite(leftMotorPower, LOW);
  } else {
    if (leftMotorPowerSpeed < 0) {
      digitalWrite(leftMotorDir1, LOW);
      digitalWrite(leftMotorDir2, LOW);
    } else {
      digitalWrite(leftMotorDir1, HIGH);
      digitalWrite(leftMotorDir2, HIGH);
    }
    if (abs(leftMotorPowerSpeed) >= 127) { // full power:
      dimmerLeftDelay = 0;
      digitalWrite(leftMotorPower, HIGH);
    } else { // dim:
      dimmerLeftDelay = lastMainsZero + (127 - abs(leftMotorPowerSpeed)) * 70;
      digitalWrite(leftMotorPower, LOW);
    }
  }

  if (rightMotorPowerSpeed == 0) { // zero:
    dimmerRightDelay = 0;
    digitalWrite(rightMotorPower, LOW);
  } else {
    if (rightMotorPowerSpeed < 0) {
      digitalWrite(rightMotorDir1, HIGH);
      digitalWrite(rightMotorDir2, HIGH);
    } else {
      digitalWrite(rightMotorDir1, LOW);
      digitalWrite(rightMotorDir2, LOW);
    }
    if (abs(rightMotorPowerSpeed) >= 127) { // full power:
      dimmerRightDelay = 0;
      digitalWrite(rightMotorPower, HIGH);
    } else { // dim:
      dimmerRightDelay = lastMainsZero + (127 - abs(rightMotorPowerSpeed)) * 70;
      digitalWrite(rightMotorPower, LOW);
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
      dimmerWindDelay = lastMainsZero + (255 - windMotorPowerSpeed) * 35;
      digitalWrite(windMotorPower, LOW);
    }
  }

  if (shakeMotorPowerSpeed == 0) { // zero:
    dimmerShakeDelay = 0;
    digitalWrite(shakeMotorPower, LOW);
  } else {
    if (shakeMotorPowerSpeed == 255) { // full power:
      dimmerShakeDelay = 0;
      digitalWrite(shakeMotorPower, HIGH);
    } else { // dim:
      dimmerShakeDelay = lastMainsZero + (255 - shakeMotorPowerSpeed) * 35;
      digitalWrite(shakeMotorPower, LOW);
    }
  }
  
}



void timerIsr() {
  // manage TRIAC DIMMING:   learn on http://www.alfadex.com/2014/02/dimming-230v-ac-with-arduino-2/

  if (dimmerLeftDelay != 0) {
    if (micros() >= dimmerLeftDelay) {
      digitalWrite(leftMotorPower, HIGH);
      dimmerLeftDelay = 0;
    }
  }

  if (dimmerRightDelay != 0) {
    if (micros() >= dimmerRightDelay) {
      digitalWrite(rightMotorPower, HIGH);
      dimmerRightDelay = 0;
    }
  }

  if (dimmerWindDelay != 0) {
    if (micros() >= dimmerWindDelay) {
      digitalWrite(windMotorPower, HIGH);
      dimmerWindDelay = 0;
    }
  }
  
  if (dimmerShakeDelay != 0) {
    if (micros() >= dimmerShakeDelay) {
      digitalWrite(shakeMotorPower, HIGH);
      dimmerShakeDelay = 0;
    }
  }

}

