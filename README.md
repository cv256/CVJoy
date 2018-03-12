For only 500 USD (most of it on wood and a chair) I built myself a full car simulator , with:
- 6 speed H shifter and reverse
- sequential shifter
- handbreak + clutch + break + gas pedals (all are 10 bit analogic)
- master shutdown
- 7 buttons (for horn, lights, camera, etc or to emulate keypresses like Esc for pausing the game and entering menu)
- leds for RPM
- leds for loosing traction on Front and on Back
- lots of wind, based on the car speed (provided by 2 strong hairdryers)
- shakes based on the speed and on the suspension movements (provided by an old mixer)
- a great 10bit 900º forcefeedback real steering wheel
- the simulator pitches and rols 20º (wich is a lot, scary) front/back left/right (provided by two 800W drills)
- and I've been thinking about adding 2 seatbelts that compress you when you break or turn hard ;-)

It is recognised just like any comercial good steering wheel with forceedback, 3 pedals, handbrake, buttons and shifter, so that parts work with any game.
The leds, wind, shaking, pith&roll need specific software for each game, and by now I've developed it only for Assetto Corsa (but it's easy to do it for other car games, or even flight simulators).

See the **general diagram here:** https://github.com/cv256/CVJoy/blob/master/Simulador%20Automovel/Comunicacao/Diagram1.png

This project wants to be a complete tutorial on how to do it, and I'm sharing all the software I developed for this. It would be fantastic if this could help others to build their own simulators.



THE SOFTWARE:

Inside you Program Files folder create a folder called CVJoy (this is the regular way but it doesnt have to be exactly like this).
Inside it save CVJoy.exe you can find here.

Download and install vjoy: https://sourceforge.net/projects/vjoystick/
This tiny software allows other softwares to perfectly emulate a joystick on your computer. Configure it like this:
https://github.com/cv256/CVJoy/blob/master/Simulador%20Automovel/Comunicacao/VJoy%20configuration.jpg

Download AssettoCorsaSharedMemory: https://github.com/mdjarv/assettocorsasharedmemory
Compile it and copy the resulting AssettoCorsaSharedMemory.dll into the CVJoy folder.
This tiny library allows other softwares to know whats happening in the game in real-time (speed, position, acceleration, rpm)

Connect the computer (this project needs just 1 computer) to the Arduino using a usb cable. The computar will recognise your arduino as a serial port, tipically COM3.

Download and install the arduino IDE Software you can find here: https://www.arduino.cc/en/Main/Software

Use it to Open my file https://github.com/cv256/CVJoy/blob/master/sketch_CVJoy/sketch_CVJoy.ino
and then Upload it (save it) into the arduino. This file is the software (written in the arduino's specific language) that the arduino will allways be running, even if it is not connected to any computer.

This is one of the **screens of my software CVJoy.exe**:
https://github.com/cv256/CVJoy/blob/master/Simulador%20Automovel/Comunicacao/CV%20Joy1.png
On the top half you can view the buttons, leds, pitch, roll, steering wheel, shift wich are red by CVJoy.exe from the arduino.
On the lower half you can view the data that is being red from AC throught assettocorsasharedmemory, and you can configure how this values will be sent to the arduino, how they will affect the leds, the wind and shake.
And if you press the Setup button you can configura a lot more parameters:
https://github.com/cv256/CVJoy/blob/master/Simulador%20Automovel/Comunicacao/CV%20Joy2.png



THE HARDWARE:

The electronics are based on :
- Arduino Mega (35$) 
- 4 ac dimmers (35$) https://www.facebook.com/krida.electronics/photos/a.146032125748693.1073741832.145962675755638/299516397066931/?type=3&theater
- 8 relays (10$) https://www.miniinthebox.com/pt/8-channel-12v-modulo-rele-para-arduino-funciona-com-oficiais-arduino-placas_p903437.html?prm=2.3.5.0
- ADXL345 (3$) http://www.dx.com/pt/p/gy-291-adxl345-digital-3-axis-acceleration-of-gravity-tilt-module-for-arduino-148921?tc=EUR&ta=PT&gclid=EAIaIQobChMIxtnanuXI1wIVoxXTCh3JIgHqEAQYAyABEgI0ovD_BwE#.WhCBCXlpE_4
- L298 (15$)
- 4 5Kohm 0.5W linear potentiometers
- 4 leds
- 8 microswitches off(on) (for H shifter and sequential)
- 1 switch on-off-on (for reverse)
- 1 switch on-off 2 poles (for emergency cut all energy)
- 7 press buttons off(on)
- an old mouse (for using one of it's rotary encoders)
- a dc motor and a sprocket (got them from an old forcefeedback wheel that was for game-port, not even usb) (I might use 2 motors um paralel, stronger wheel)

Put the Arduino, Dimmers and Relays in a transparent box so that you can see the hardware leds:
https://github.com/cv256/CVJoy/blob/master/Simulador%20Automovel/Comunicacao/DSCN8519.JPG


I'm now changing from ADXL345 to MPU6050, so to get preciser/faster position data.
This is a simple guide for choosing IMUs: https://www.sparkfun.com/pages/accel_gyro_guide
This is a simple explanation about IMUs: http://www.instructables.com/id/Guide-to-gyro-and-accelerometer-with-Arduino-inclu/
This is a fulll explanation of IMUs: https://theccontinuum.com/2012/09/24/arduino-imu-pitch-roll-from-accelerometer/

(writing in progress...)



THE MECHANICS:

(writing in progress...)
