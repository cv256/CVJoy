# CVJoy
Car Simulator
For only 700 USD I  built myself a full car simulator , with:
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

It is recognised just like any comercial good steering wheel with forceedback, 3 pedals, handbrake, buttons and shifter, so that parts work with any game
The leds, wind, shaking, pith&roll need specific software for each game, and by now I've developed it only for Assetto Corsa (but it's easy to do it for other car games, or even flight simulators).

This project wants to be a complete tutorial on how to do it, and I'm sharing all the software I developed for this. It would be fantastic if this could help others to build their own simulators.



THE SOFTWARE:

Inside you Program Files folder create a folder called CVJoy (this is the regular way but it doesnt have to be exactly like this).
Inside it save CVJoy.exe you can find here.

Download and install vjoy. This tiny software allows other softwares to emulate a joystick on your computer. Configure it like this:
......

Download AssettoCorsaSharedMemory and save its contents inside the CVJoy folder. This tiny library allows other softwares to know whats happening in the game in real-time (speed, position, acceleration, rpm)

Connect the computer (this project needs just 1 computer) to the Arduino using a usb cable. The computar will recognise your arduino as a serial port, tipically COM3.

Download and install the arduino driver/software you can find here.
Use it to open my file ??? And then save it into the arduino. This file is the software (written in the arduino's specific language) that the arduino will allways be running, even if it is not connected to any computer.

This is one of the screens of the software I'm doing.
On the top half you can «review» the buttons, leds, pitch, roll, steering wheel, shift.
On the lower left you can view the data that is being red from AC.
On the lower right you can configure some things on the fly (there are more screens where you can configure a lot more)


THE HARDWARE:

The electronics are based on a Arduino Mega (35$) + 4 triacs (35$) + 8 relays (10$). You just have to connect the wires (make no mistakes!)
