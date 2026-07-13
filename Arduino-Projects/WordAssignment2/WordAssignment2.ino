// Code to flash LEDs so that when a board with a line of 7 vertical LEDs is shaken
// the word TARNISHED is visible
// By Taylor Cunningham & Dominic Navarrete
// April 28th, 2025

const int len = 61;//Variable of length of array for later reference
const int APin = A4;//Establishes potentiometer analog pin
const int Button = 2;//Establishes Button pin
int buttonState =0;//Variable for reading if button is pressed or not
int potVal = 0;//Varible to store potentiometer value to increase or decrease resistance as needed
int array[7][len] ={//Creates Binary for LEDs to display the word "TARNISHED"
{1,1,1,1,1,1,0,0,0,1,1,0,0,0,1,1,1,0,0,0,1,0,0,0,0,0,1,0,0,1,1,1,0,0,1,1,1,1,1,0,0,1,0,0,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,0,0},
{1,1,1,1,1,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,1,0,0,0,0,1,0,0,0,1,0,0,0,1,1,1,1,1,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,0,1,0,0,0,0,0},
{0,0,1,1,0,0,0,0,1,0,0,1,0,0,1,1,1,0,0,0,1,0,1,0,0,0,1,0,0,0,1,0,0,0,1,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0},
{0,0,1,1,0,0,0,0,1,1,1,1,0,0,1,1,0,0,0,0,1,0,0,1,0,0,1,0,0,0,1,0,0,0,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,0,0,1,0,0,0,0},
{0,0,1,1,0,0,0,0,1,0,0,1,0,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,0,1,1,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0},
{0,0,1,1,0,0,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,0,0,1,1,0,0,0,1,0,0,0,1,1,1,1,1,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,0,1,0,0,0,0,0},
{0,0,1,1,0,0,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1,0,0,1,1,1,1,1,0,0,1,0,0,1,0,0,1,1,1,1,0,0,1,1,0,0,0,0,0,0}};
void setup() {//Runs once
  for(int i =4; i<=10; i++)//Establishes pins 3-10 as the LED pins 
  {
    pinMode(i,OUTPUT);
  }
  pinMode(Button, INPUT);//Establish button pin
  pinMode(APin, INPUT); //Establish potentiometer pin
}
void loop() {//Runs indefinitely 
  potVal = analogRead(APin);//Reads potentiometer value
  buttonState = digitalRead(Button);//Reads current button state
  for(int column=0;column<len;column++){//Loops through all columns
    for (int row=0;row<7;row++){//Loops through all rows
      digitalWrite(10-row, array[row][column]);
    }
    buttonState = digitalRead(Button);//Reads current button state
    while (buttonState == LOW){
      buttonState = digitalRead(Button);//Reread current button state
    }
    delay(potVal);//Delays based on potentiometer value
    potVal = analogRead(APin);//Reads potentiometer value again to check for change
  }
}
