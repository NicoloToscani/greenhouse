

#include <Servo.h>

Servo servo_dx;
Servo servo_sx;



void setup() {
  
pinMode(7,INPUT);  //MOTORE SX
//pinMode(4,INPUT);  //MOTORE DX
servo_sx.attach(9);
//servo_dx.attach(11);

}

void loop() {

  if(digitalRead(7) == LOW)
  {
    servo_sx.write(0);
  }
  else if(digitalRead(7) == HIGH)
  {
    servo_sx.write(180);
  }

/*
  if(digitalRead(4) == LOW)
  {
    servo_dx.write(0);
  }
  else if(digitalRead(4) == HIGH)
  {
    servo_dx.write(180);
  }
  */

}
