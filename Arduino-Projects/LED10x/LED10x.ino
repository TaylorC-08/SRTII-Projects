// Code to make a LED blink 10 times rapidly
// By Taylor Cunningham
// March 21st, 2025

int pin = 0;
void setup() {
  // put your setup code here, to run once:
  pinMode(pin, OUTPUT); // initialize digital pin LED_BUILTIN as an output.
}

void loop() {
  // put your main code here, to run repeatedly:
  for(int i=0; i<10; i++)
  {
    digitalWrite(pin, HIGH);  // turn the LED on (HIGH is the voltage level)
    delay(100);                      // wait for 100 ms
    digitalWrite(pin, LOW);   // turn the LED off by making the voltage LOW
    delay(150);                      // wait for 150 ms
  }
}
