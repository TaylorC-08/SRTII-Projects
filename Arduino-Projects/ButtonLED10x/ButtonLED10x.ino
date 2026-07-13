// Code to make an LED blink 10 times very quickly on a button press
// By Taylor Cunningham
// March 21st, 2025

int pin = 0;
void setup() {
  // put your setup code here, to run once:
  pinMode(pin, OUTPUT); // initialize the LED pin as an output
  pinMode(buttonPin, INPUT); // initialize the pushbutton pin as an input
}

void loop() {
  // put your main code here, to run repeatedly:
  buttonState = digitalRead(buttonPin); // read the state of the pushbutton value
  if (buttonState == HIGH) 
  {
      for(int i=0; i<10; i++)
  {
    digitalWrite(pin, HIGH);  // turn the LED on (HIGH is the voltage level)
    delay(30);                      // wait for 30 ms
    digitalWrite(pin, LOW);   // turn the LED off by making the voltage LOW
    delay(30);                      // wait for 30 ms
  }
  } else 
  {
    digitalWrite(pin, LOW); // turn LED off
  }
}
