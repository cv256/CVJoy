// #include <TimerOne.h> // found here: https://github.com/PaulStoffregen/TimerOne.git	unzip it into C: Program Files (x86) Arduino libraries 
// #include <Wire.h>
// https://arduino-info.wikispaces.com/Timers-Arduino			 https://forum.arduino.cc/index.php?topic=72092.0
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
// Setting	 Divisor	 Frequency Hz
// 0x01				 1				31372.55
// 0x02				 8				 3921.16
// 0x03				32					980.39
// 0x04				64					490.20	 <--DEFAULT
// 0x05			 128					245.10
// 0x06			 256					122.55
// 0x07			 1024					30.64

// Arduino Mega serial ports's (also known as a UART or USART) pins:
//	 serial: 0(RX), 1(TX)	,	serial1: 19(RX), 18(TX)	,	serial2: 17(RX), 16(TX)	,	seria3: 15(RX), 14(TX)
// On Uno, Nano, Mini, and Mega, pins 0 and 1 are used for communication with the computer via USB. Connecting anything to these pins can interfere with that communication, including causing failed uploads to the board.
// Serial communication on pins TX/RX uses TTL logic levels (5V or 3.3V depending on the board). Don’t connect these pins directly to an RS232 serial port; they operate at +/- 12V and can damage your Arduino board.
// Pin | Interrrupt # | Arduino Platform
// 2 | 0 | All
// 3 | 1 | All
// 18 | 5 | Arduino Mega Only
// 19 | 4 | Arduino Mega Only
// 20 | 3 | Arduino Mega Only
// 21 | 2 | Arduino Mega Only
#define serialSpeed 115200 // data rate in bits per second (baud) for serial data transmission. For communicating with the computer, use one of these rates: 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, or 115200. The highest without error seems to be actually 115200 - which is the standard

#define pinZeroCrossDetector	2 //on Mega, Mega2560, MegaADK interrupt pins are 2, 3, 18, 19, 20, 21
#define pinLeftUSSend 42
#define pinLeftUSRead 43
#define pinRightUSSend 44
#define pinRightUSRead 45
#define pinLeftMotorDir	22
#define pinLeftMotorPower	24
#define pinRightMotorDir	23
#define pinRightMotorPower	25
#define pinBreakLed 52
#define pinKey 53

void setup()
{
	pinMode(pinZeroCrossDetector, INPUT);
	pinMode(pinLeftUSSend, OUTPUT);
	pinMode(pinLeftUSRead, INPUT);
	pinMode(pinRightUSSend, OUTPUT);
	pinMode(pinRightUSRead, INPUT);
	pinMode(pinLeftMotorPower, OUTPUT);
	pinMode(pinLeftMotorDir, OUTPUT);
	pinMode(pinRightMotorPower, OUTPUT);
	pinMode(pinRightMotorDir, OUTPUT);
	pinMode(pinBreakLed, OUTPUT);
	pinMode(pinKey, INPUT_PULLUP);
	pinMode(LED_BUILTIN, OUTPUT);

	noInterrupts();					 // disable all interrupts

	// all AC Dimmers :
	attachInterrupt(digitalPinToInterrupt(pinZeroCrossDetector), zero_cross_ISR, RISING);// this happens 100 times per second, 100Hz
	// Zero cross (half sinewave) happens every 10ms (1000ms/50Hz/2), so there is a 10ms period that we can use to regulate power using PWM (Pulse Width Modulation - leading edge cut)
	// 10ms/255 =~ 0,039ms = 39 microseconds, 25641 times per second, 26KHz!	 If we are not usign PWM.	If using PSM (Pulse Skip Modulation)

	//Timer1.initialize(300); // 300 microseconds = 3333 times per second, over 100Hz means 33 steps
	//Timer1.attachInterrupt( timer3333 );

	interrupts();					 // enable all interrupts

	// start communication from/to the computer via USB:
	serialReset();
} //...setup


const byte SerialSend2PacketLen=4; // from PC to Arduino
const byte SerialRead2PacketLen=6; // from Arduino to PC

byte leftMotorPower;// 0=erro	1~127 128 129~255	 -128 = -127 0 127
byte rightMotorPower;// 0=erro	1~127 128 129~255	 -128 = -127 0 127
unsigned long dimmerLeftDelay;
unsigned long dimmerRightDelay;
bool leftTriacOn;
bool rightTriacOn;

byte serialReceived[SerialSend2PacketLen]; 
byte serialReceivedIdx;
byte errors; // 1=not receiving data / 2=got invalid data from computer / 16=ACPower
unsigned long lastSerialRecv;
volatile unsigned long lastMainsZero;
unsigned long lastSerialSend;



void loop()
{
	// joyff + game -> pc -> ARDUINO:
	if (Serial.available() > 0) { // data that’s already arrived and stored in the serial receive buffer (which holds 64 bytes)
		serialReceived[serialReceivedIdx] = Serial.read(); // gets first available byte
		serialReceivedIdx++;

		if (serialReceivedIdx < SerialSend2PacketLen) { 
			goto noData;
		}

		// READ from computer / write to hardware: --------------------- must be equal to CVJoyAc.SerialSend
		if (serialReceived[0] < 254) {	// if it doesnt start with the correct header then it is trash
			shift1();
			goto noData;
		}

		byte chk1 = serialReceived[1];
		byte chk2 = (byte)255 - (serialReceived[2] ^ serialReceived[3]);
		if ( (chk1 != chk2) | (serialReceived[2]==0) | (serialReceived[3]==0) ) {
			shift1();
			errors = errors | 2;
			//digitalWrite(LED_BUILTIN, HIGH);
			goto noData;
		}

		//digitalWrite(LED_BUILTIN, LOW);
		serialReceivedIdx = 0;
		lastSerialRecv = millis();

		if ((serialReceived[0] & 1) == 0) {
			digitalWrite(pinBreakLed, LOW);
		} else {
			digitalWrite(pinBreakLed, HIGH);
		}

		leftMotorPower = serialReceived[2];
		rightMotorPower = serialReceived[3];
	}

noData:

	// if we lost communication with the computer stop the motors, dont let them in the last state or they will make ugly damage !
	if (millis() - lastSerialRecv > 200) { // 200 = 5 Hz , lower than that and it will start bumping
		digitalWrite(pinLeftMotorPower, LOW);
		digitalWrite(pinRightMotorPower, LOW);
		leftMotorPower = 0; // signals error
		rightMotorPower = 0;// signals error
		//serialReset();
		errors = errors | 1;
	}

    if (lastMainsZero+12000 < micros()) errors = errors | 16; // No Mains power / MainsPower freq lower than 50Hz(10000+12+2915+12+2915+...) // NÂO MUSAR NADINHA NESTA LINHA !!!  ver o meu Testar_ZeroCross.INO

 	triacs(); // TODO: define the motors powers based of the actual positions versus the desired position
	
	// send to PC:
	if (millis()-lastSerialSend >= 25) {

		byte serialWrite[SerialRead2PacketLen];
	
		// Read Left Distance :
		int tmpUInt=0;
		digitalWrite(pinRightUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
		delayMicroseconds(12);
		digitalWrite(pinRightUSSend, LOW);
		tmpUInt=pulseIn(pinRightUSRead, HIGH, 2915); // microseconds of (total) sound travel, timeout is the time to go, reflect and come back. 50cm x 2 = 2915 microseconds
		serialWrite[2]=tmpUInt & 255;
		serialWrite[3]=tmpUInt / 256;
		// Read Right Distance :
		digitalWrite(pinLeftUSSend, HIGH);// The PING is triggered by a HIGH pulse of 10 or more microseconds
		delayMicroseconds(12);
		digitalWrite(pinLeftUSSend, LOW);
		tmpUInt=pulseIn(pinLeftUSRead, HIGH, 2915); // microseconds of (total) sound travel, timeout is the time to go, reflect and come back. 50cm x 2 = 2915 microseconds
		serialWrite[4]=tmpUInt & 255;
		serialWrite[5]=tmpUInt / 256;

		// send to PC:
		serialWrite[0] = 252 | ((digitalRead(pinKey) == LOW) ? 1 : 0); // checkdigit
		serialWrite[1] = errors;
		errors=0;
		Serial.write(serialWrite, SerialRead2PacketLen);
		lastSerialSend = millis();
	}

} //...loop


void shift1() {
	for (int i = 0; i < serialReceivedIdx; i++) {
		serialReceived[i] = serialReceived[i + 1];
	}
	serialReceivedIdx -= 1;
}


void zero_cross_ISR() {
	// frequency of AC signal is 50 Hz so the time period will be 1/f, which will be 20ms, half cycle is 10ms or 10000 microseconds. Hence the range of “Delay” can be varied from 0-10000 microseconds

	//Serial.println( (int)( (float)(micros()-zero_cross) / (float)10 ) );

	lastMainsZero = micros();
	
	leftTriacOn = false;
	rightTriacOn = false;
	digitalWrite(pinLeftMotorPower, LOW);
	digitalWrite(pinRightMotorPower, LOW);
	
	if (leftMotorPower == 0 || leftMotorPower == 128) { // error or zero
		dimmerLeftDelay = 0;	 // dont turn triac on
	} else {
		if (leftMotorPower < 128) {
			digitalWrite(pinLeftMotorDir, LOW);
		} else {
			digitalWrite(pinLeftMotorDir, HIGH);
		}
	dimmerLeftDelay = lastMainsZero + (128 - abs(leftMotorPower-128)) * 70;
	}

	if (rightMotorPower == 0 || rightMotorPower == 128) { // error or zero
		dimmerRightDelay = 0;	// dont turn triac on
	} else {
		if (rightMotorPower < 128) {
			digitalWrite(pinRightMotorDir, LOW);
		} else {
			digitalWrite(pinRightMotorDir, HIGH);
		}
	dimmerRightDelay = lastMainsZero + (128 - abs(rightMotorPower-128)) * 70;
	}
	
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
	// manage TRIAC DIMMING:	 learn on http://www.alfadex.com/2014/02/dimming-230v-ac-with-arduino-2/
	
	if (dimmerLeftDelay != 0 && leftMotorPower != 0) {
		if (!leftTriacOn) {
			if (micros() >= dimmerLeftDelay) {
				leftTriacOn = true;
		    digitalWrite(pinLeftMotorPower, HIGH);
				dimmerLeftDelay = micros() + 12;
			}
		} else {
			if (micros() >= dimmerLeftDelay ) { // the triac's gate dont need to be High for the whole cycle, about 10us is the time you need to make sure the TRIAC got on
				dimmerLeftDelay = 0;
				digitalWrite(pinLeftMotorPower, LOW);
			}
		}
	}

	if (dimmerRightDelay != 0 && rightMotorPower != 0) {
		if (!rightTriacOn) {
			if (micros() >= dimmerRightDelay) {
				rightTriacOn = true;
				digitalWrite(pinRightMotorPower, HIGH);
				dimmerRightDelay = micros() + 12;
			}
		} else {
			if (micros() >= dimmerRightDelay ) { // the triac's gate dont need to be High for the whole cycle, about 10us is the time you need to make sure the TRIAC got on
				dimmerRightDelay = 0;
				digitalWrite(pinRightMotorPower, LOW);
			}
		}
	}

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



void serialReset() {
	// Serial.end(); end and begin operations are async and take time, we would need to wait for some time before we can begin again
	// serial communications throught USB :	 the highest rate without error seems to be actually 115200 - which is the standard...
	Serial.begin(serialSpeed); // data rate in bits per second (baud) for serial data transmission. For communicating with the computer, use one of these rates: 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, or 115200
}
