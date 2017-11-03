/***********************************************************************************
 * 
 * Demo Arduino code for 4CH AC DIMMER MODULE
 * 
 * AC LINE FREQUENCY - 50HZ !
 *
 * Variables for dimming - buf_CH1, buf_CH2, buf_CH3, buf_CH4 !
 * 
 * Variables have range 0-255. 0 - Fully ON, 255 - Fully OFF.
 *
 * KRIDA Electronics, 4 SEP 2016
 ***********************************************************************************/


#include <TimerOne.h>

#define channel_1 4 
#define channel_2 5
#define channel_3 6
#define channel_4 7

#define SPEED 20

#define GATE_IMPULSE 5

#define FREQ 101
  
unsigned int  CH1, CH2, CH3, CH4;
unsigned int  buf_CH1, buf_CH2, buf_CH3, buf_CH4;
unsigned char clock_cn;    
unsigned int  clock_tick;   
unsigned char i;  

void setup() {

  pinMode(channel_1, OUTPUT);
  pinMode(channel_2, OUTPUT);
  pinMode(channel_3, OUTPUT);
  pinMode(channel_4, OUTPUT);
  attachInterrupt(1, zero_crosss_int, RISING);
  Timer1.initialize(10); 
  Timer1.attachInterrupt( timerIsr );
    
}

void timerIsr()
{    
    clock_tick++;

    if (clock_cn) 
     {
      clock_cn++;
      
       if (clock_cn==GATE_IMPULSE)
       {
        digitalWrite(channel_1, LOW); 
        digitalWrite(channel_2, LOW); 
        digitalWrite(channel_3, LOW); 
        digitalWrite(channel_4, LOW);
        clock_cn=0;
       }
     }
   
        if (CH1==clock_tick)
         {
          digitalWrite(channel_1, HIGH);
          clock_cn=1;
         }  
    
           if (CH2==clock_tick)
            {
             digitalWrite(channel_2, HIGH);
             clock_cn=1;
            }  
        
              if (CH3==clock_tick)
               {
                digitalWrite(channel_3, HIGH);
                clock_cn=1;
               }  
    
                 if (CH4==clock_tick)
                  {
                   digitalWrite(channel_4, HIGH);
                   clock_cn=1;
                  }   

                  
}

 

void zero_crosss_int()
{
  CH1=buf_CH1;
   CH2=buf_CH2;
    CH3=buf_CH3;
     CH4=buf_CH4;
  
  clock_tick=0;        
}

unsigned int DIMM_VALUE (unsigned char level)
{
 unsigned int buf_level;

 if (level < 26)  {level=26;}
 if (level > 229) {level=229;}
  
 return ((level*(FREQ))/256)*10;  
}



void loop() {

  for (i=255;i>1;i--) {buf_CH1=DIMM_VALUE(i); delay(SPEED);}
   for (i=255;i>1;i--) {buf_CH2=DIMM_VALUE(i); delay(SPEED);}
    for (i=255;i>1;i--) {buf_CH3=DIMM_VALUE(i); delay(SPEED);}
     for (i=255;i>1;i--) {buf_CH4=DIMM_VALUE(i); delay(SPEED);}

  for (i=0;i<255;i++) {buf_CH1=DIMM_VALUE(i); delay(SPEED);}   
   for (i=0;i<255;i++) {buf_CH2=DIMM_VALUE(i); delay(SPEED);}   
    for (i=0;i<255;i++) {buf_CH3=DIMM_VALUE(i); delay(SPEED);}   
     for (i=0;i<255;i++) {buf_CH4=DIMM_VALUE(i); delay(SPEED);}   
    
}
