// Code to drive a robot forward, with a right and left turn until 
// it is under a platform suspended by a tower, after which it knocks down
// the tower with an attached servo and custom attachment part and stops
// By Taylor Cunningham
// April 28th, 2025
#include <Servo.h>//Servo library for servo functions
Servo right;
Servo left;
Servo arm;
const int lightPin = A5;//Pin for phototransitor 
int light = 0;//val for checking with phototransitor
int val =0;//Value read by phototransitor where low number means light is present, high means dark
void forward(){//Function for moving car forward for 5 seconds about 2 feet
  right.writeMicroseconds(1700);
  left.writeMicroseconds(1300);
  delay(5000);}
void rightTurn(){//Function for turning right 90 degrees
  right.writeMicroseconds(1700);
  left.writeMicroseconds(1700);
  delay(1350);}
void leftTurn(){//Function to turn left for 90 degrees
  right.writeMicroseconds(1300);
  left.writeMicroseconds(1300);
  delay(1250);}
void setup() {//put your setup code here, to run once:
  Serial.begin(9600);//Code used to be able to display light readings from phototransitor later
  right.attach(12);//Attaches servo to the pin number it is plugged into
  left.attach(13);
  arm.attach(10);
  arm.write(0);//Resets the arm position in case it was not already reset
  forward();//Calling of previously made function to do as function is titled (saves lines of code this way)
  rightTurn();
  forward();
  leftTurn();
  forward();
  light = analogRead(lightPin);
}
void loop() {// put your main code here, to run repeatedly:
  val = analogRead(lightPin);
  Serial.println(val);//Outputs phototransitor value
  delay(100);
  while(val<light){//While there is light
    val = analogRead(lightPin);//Rereads light value to exit loop when it becomes dark
    Serial.println(val);
    delay(100);
    right.writeMicroseconds(1700);
    left.writeMicroseconds(1300);
    arm.write(0);//Resets arm in case it is not already
    delay(20);
  }
  while(val>light){//While there is not light
    val = analogRead(lightPin);
    Serial.println(val);//Rereads light value to exit loop when it is light again
    right.writeMicroseconds(1500);//Sets both wheels to stop moving
    left.writeMicroseconds(1500);
    arm.write(170);//Makes servo arm spin to knock down object
    delay(20);
  }
}