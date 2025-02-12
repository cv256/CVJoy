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
#define pinWheelEncA  2 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pinWheelEncB  3 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pinPedalAccel  1 // analog input
#define pinPedalBreak  5 // analog input// A2 is damaged?...
#define pinPedalClutch  3 // analog input
#define pinHandbrake 4 // analog input
#define pinButton1 42 // esq - ESC
#define pinButton2 37 // esq
#define pinButton3 39 // direita 
#define pinButton4 41 // direita 
#define pinButton5 38 // direita 
#define pinButton6 40 // direita 
#define pinButton7 36 // direita 
#define pinButton8 35 // shiftup
#define pinButton9 34 // shiftdown 
#define pinGear1 43
#define pinGear2 48
#define pinGear3 46
#define pinGear4 44
#define pinGear5 47
#define pinGear6 45
#define pinGearR 49
#define pinWheelMotorPower  6
#define pinWheelMotorDir1  22
#define pinWheelMotorDir2  23
#define pinWindMotor  10 // LED_BUILTIN=13
#define pinShakeMotor 9


void setup()
{
	// external hardware -> arduino :
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

	// arduino -> external hardware
	pinMode(pinWheelMotorPower, OUTPUT);
	pinMode(pinWheelMotorDir1, OUTPUT);
	pinMode(pinWheelMotorDir2, OUTPUT);
	pinMode(pinWindMotor, OUTPUT);
	pinMode(pinShakeMotor, OUTPUT);
	pinMode(LED_BUILTIN, OUTPUT);

	noInterrupts();           // disable all interrupts

	// steeringwheel position reading :
	//TCCR4A = 0; // timer 4 controls pin 6, 7, 8
	TCCR4B = (TCCR4B & 0b11111000) | 0x01; // 0x03 gives 980Hz I red that DC motors work better with >2KHz and there may be losses above 20KHz. But I made experiments with 2 different motors and both had much better effeciency with lower frequencies. Divisor 1 and 2 makes no noise but are not effecient. Divisors bigger than 3 make the steeringwheel shiver. Diviser 3 makes some whistle but it's my choice using a 0.33uF capacitor paralel with motor.
	// preparing the steering wheel encoder :
	attachInterrupt(digitalPinToInterrupt(pinWheelEncA), doEncoderA, CHANGE);
	attachInterrupt(digitalPinToInterrupt(pinWheelEncB), doEncoderB, CHANGE);

	interrupts();           // enable all interrupts

	// start communication from/to the computer via USB:
	SerialReset();
} //...setup


// volatile byte WheelEncAFlag = 0; // let's us know when we're expecting a rising edge on pinA to signal that the encoder has arrived at a detent
// volatile byte WheelEncBFlag = 0; // let's us know when we're expecting a rising edge on pinB to signal that the encoder has arrived at a detent (opposite direction to when aFlag is set)
volatile unsigned int wheelPosition = 32768; //this variable stores our current value of encoder position
unsigned int wheelPositionLast;
bool wheelMotorDir253;
unsigned long shakeOnTime; unsigned long shakeDuty; bool shakeOn; byte shakeMotorPower; long shakeDelay;

byte serialReceived[6]; // SerialSend.PacketLen
byte serialReceivedIdx;
byte errors; // 1=not receiving data / 2=got invalid data from computer
unsigned long lastSerialRecv;
unsigned int every30Hz;


void loop()
{
	// joyff + game -> pc -> ARDUINO:
	if (Serial.available() > 0) { // data that’s already arrived and stored in the serial receive buffer (which holds 64 bytes)
		serialReceived[serialReceivedIdx] = Serial.read();
		serialReceivedIdx++;

		if (serialReceivedIdx < 6) { // SerialSend.PacketLen
			goto noData;
		}

		// READ from computer / write to hardware: --------------------- must be equal to CVJoyAc.SerialSend
		if (serialReceived[0] < 252 || serialReceived[0] == 255) {
			shift1();
			goto noData;
		}

		byte chk1 = serialReceived[1];
		byte chk2 = (byte)255 - (serialReceived[2] ^ serialReceived[3] ^ serialReceived[4] ^ serialReceived[5]);
		if (chk1 != chk2) {
			shift1();
			errors = errors | 2;
			//digitalWrite(LED_BUILTIN, HIGH);
			goto noData;
		}

		//digitalWrite(LED_BUILTIN, LOW);
		serialReceivedIdx = 0;
		lastSerialRecv = millis();

		if (serialReceived[0] == 252) { // reset wheel position
			wheelPosition = 32768;
		}

		if (serialReceived[2] > 0) { // wheelMotorPower  Invert Wheel FF direction:
			if (serialReceived[0] == 253 && !wheelMotorDir253) {
				analogWrite(pinWheelMotorPower, 0);
				wheelMotorDir253 = true;
				digitalWrite(pinWheelMotorDir1, HIGH);
				digitalWrite(pinWheelMotorDir2, LOW);
			}
			else if (serialReceived[0] == 254 && wheelMotorDir253) {
				analogWrite(pinWheelMotorPower, 0);
				wheelMotorDir253 = false;
				digitalWrite(pinWheelMotorDir1, LOW);
				digitalWrite(pinWheelMotorDir2, HIGH);
			}
		}
		analogWrite(pinWheelMotorPower, serialReceived[2]);

		analogWrite(pinWindMotor, serialReceived[3]); //windMotorPower = serialReceived[3];

		if (serialReceived[4] == 0 || serialReceived[5] == 0) {
			shakeMotorPower = 0;
			shakeOnTime = 0;
			shakeDuty = 0;
			shakeOn = false;
			analogWrite(pinShakeMotor, 0);
		}
		else {
			shakeMotorPower = serialReceived[4];
			shakeDelay = (unsigned long)256 - (unsigned long)serialReceived[5]; // 255~1
			shakeDuty = shakeDelay * 256;
			shakeDelay = (shakeDelay * shakeDelay); // 65025~1
			//shakeDuty = shakeDelay + 6500 ; // 71525~6500
			shakeDelay = (unsigned long)4 * shakeDelay;
		}

	}

noData:

	// if we lost communication with the computer stop the motors, dont let them in the last state or they will make ugly damage !
	if (millis() - lastSerialRecv > 200) { // 200 = 5 fps , lower than that and it will start bumping
		analogWrite(pinWheelMotorPower, 0);
		analogWrite(pinWindMotor, 0);//digitalWrite(pinWindMotor, LOW);    //windMotorPower = 0;
		analogWrite(pinShakeMotor, 0);
		shakeMotorPower = 0;
		// SerialReset();
		errors = errors | 1;
	}

	// send Wheel Position -> PC -> joy:
	if (wheelPosition != wheelPositionLast) {
		wheelPositionLast = wheelPosition;
		byte serialWrite[3];
		serialWrite[0] = 255; // record type = «wheel info»
		serialWrite[1] = wheelPosition & 255; // position lo part
		serialWrite[2] = ((wheelPosition & 0xFF00) >> 8); // position hi part
		serialWrite[3] = serialWrite[1] ^ serialWrite[2]; // checkdigit
		Serial.write(serialWrite, 4);
	}

	// send Pedals+Gears+Buttons(+RealBolts) -> ARDUINO -> PC -> joy:
	every30Hz++;
	if (every30Hz >= 4000) {
		every30Hz = 0;

		// read from hardware / SEND to computer : --------------------- must be equal to CVJoyAc.SerialRead
		byte serialWrite[7]; // SerialRead.PacketLen
		serialWrite[0] = 254;

		byte tmpByte = 192; // checkdigit (64+128)
		if (digitalRead(pinButton9) == LOW) tmpByte += 32;
		//if (digitalRead(pinButton10) == LOW) tmpByte += 16;
		tmpByte = tmpByte | errors;
		errors = 0;
		serialWrite[1] = tmpByte;

		tmpByte = 0;
		if (digitalRead(pinButton1) == LOW) tmpByte += 1;
		if (digitalRead(pinButton2) == LOW) tmpByte += 2;
		if (digitalRead(pinButton3) == LOW) tmpByte += 4;
		if (digitalRead(pinButton4) == LOW) tmpByte += 8;
		if (digitalRead(pinButton5) == LOW) tmpByte += 16;
		if (digitalRead(pinButton6) == LOW) tmpByte += 32;
		if (digitalRead(pinButton7) == LOW) tmpByte += 64;
		if (digitalRead(pinButton8) == LOW) tmpByte += 128;
		serialWrite[2] = tmpByte;
		tmpByte = 0;
		if (digitalRead(pinGear1) == LOW) tmpByte += 1;
		if (digitalRead(pinGear2) == LOW) tmpByte += 2;
		if (digitalRead(pinGear3) == LOW) tmpByte += 4;
		if (digitalRead(pinGear4) == LOW) tmpByte += 8;
		if (digitalRead(pinGear5) == LOW) tmpByte += 16;
		if (digitalRead(pinGear6) == LOW) tmpByte += 32;
		if (digitalRead(pinGearR) == LOW) tmpByte += 64;
		serialWrite[3] = tmpByte;

		unsigned int tmpUInt;
		tmpUInt = analogRead(pinPedalAccel);
		serialWrite[4] = tmpUInt / 4;
		tmpUInt = analogRead(pinPedalBreak);
		serialWrite[5] = tmpUInt / 4;
		tmpUInt = analogRead(pinPedalClutch);
		serialWrite[6] = tmpUInt / 4;

		serialWrite[7] = serialWrite[1] ^ serialWrite[2] ^ serialWrite[3] ^ serialWrite[4] ^ serialWrite[5] ^ serialWrite[6];
		Serial.write(serialWrite, 8);
	}

	// control 24v DC motors
	if (shakeMotorPower != 0) {
		if (!shakeOn) {
			if (micros() >= shakeOnTime + shakeDelay) {
				shakeOn = true;
				analogWrite(pinShakeMotor, shakeMotorPower);
				shakeOnTime = micros();
			}
		}
		else {
			if (micros() >= shakeOnTime + shakeDuty) {
				shakeOn = false;
				analogWrite(pinShakeMotor, 0);
			}
		}
	}

} //...loop


void shift1() {
	for (int i = 0; i < serialReceivedIdx; i++) {
		serialReceived[i] = serialReceived[i + 1];
	}
	serialReceivedIdx -= 1;
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

void SerialReset() {
	// Serial.end(); end and begin operations are async and take time, we would need to wait for some time before we can begin again
	// serial communications throught USB :   the highest rate without error seems to be actually 115200 - which is the standard...
	Serial.begin(serialSpeed); // data rate in bits per second (baud) for serial data transmission. For communicating with the computer, use one of these rates: 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, or 115200
}
