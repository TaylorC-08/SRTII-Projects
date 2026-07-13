//Code to swap two LEDs between an on and off state depending on a button position
// By Taylor Cunningham
// March 21st, 2025

const int Button = 3;
const int LED1 = 1;
const int LED2 =2;
int buttonState =0;
void setup() {
  // put your setup code here, to run once:
  pinMode(Button, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(buttonState = LOW)
  {
    digitalWrite(LED1,HIGH);
    digitalWrite(LED2,LOW);
  } else {
    digitalWrite(LED1,LOW);
    digitalWrite(LED2,HIGH);
  }
}
