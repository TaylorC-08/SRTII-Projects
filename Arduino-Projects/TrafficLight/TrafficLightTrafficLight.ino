//Creates a traffic light using 3 different colored LEDs
// By Taylor Cunningham
// March 24th, 2025

int RedLED = 1;
int YellowLED =4;
int GreenLED =8;
int Button = 12;
int buttonState =0;
void setup() {
  // put your setup code here, to run once:
for (int i =0; i<3; i++){
  pinMode(RedLED, OUTPUT);
  pinMode(YellowLED, OUTPUT);
  pinMode(GreenLED, OUTPUT);
}
pinMode(Button, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  buttonState = digitalRead(Button);
  if (buttonState = LOW){
    digitalWrite(GreenLED, HIGH);
    delay(5000);
    digitalWrite(GreenLED, LOW);
    digitalWrite(YellowLED, HIGH);
    delay(2500);
    digitalWrite(YellowLED, LOW);
    digitalWrite(RedLED, HIGH);
  }
}
