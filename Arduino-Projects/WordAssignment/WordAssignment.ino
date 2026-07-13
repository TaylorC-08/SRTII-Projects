// Code to flash LEDs so that when a board with a line of 7 vertical LEDs is shaken
// the word DOM is visible
// By Taylor Cunningham & Dominic Navarrete
// April 28th, 2025

const int len = 21;
const int APin = A1;
const int Button = 10;
int buttonState =0;
int potVal = 0;
int array[7][len] ={//Creates Binary for LEDs to display the name "DOM"
  {1,1,0,0,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1},
  {1,0,1,0,0,0,1,0,0,1,0,0,1,1,0,0,0,0,0,1,1},
  {1,0,0,1,0,0,1,0,0,1,0,0,1,0,1,0,0,0,1,0,1},
  {1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,0,1,0,0,1},
  {1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,0,1,0,0,0,1},
  {1,0,1,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,1},
  {1,1,0,0,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1}};
void setup() {//Runs once
  for(int i =0; i<=7; i++)//Establishes pins 1-7 as the LED pins 
  {
    pinMode(i,OUTPUT);
  }
  pinMode(Button, INPUT);//Establish button pin
  pinMode(APin, INPUT); //Establish potentiometer pin
}
void loop() {//Runs indefinitely 
  potVal = analogRead(APin);//Reads potentiometer value
  buttonState = digitalRead(Button);//Reads current button state
  while (buttonState == HIGH){
    buttonState = digitalRead(Button);
    for(int column=0;column<len;column++){//Loops through all columns
      for (int row=0;row<7;row++){//Loops through all rows
        digitalWrite(row+1, array[row][column]);
      }
      delay(potVal);//Delays based on potentiometer value
      potVal = analogRead(APin);//Reads potentiometer value again to check for change
    }
  }
}