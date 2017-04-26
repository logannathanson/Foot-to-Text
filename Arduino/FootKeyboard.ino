#include <Bounce2.h>
#define BUTTON_PIN_BACK 9
#define BUTTON_PIN_UP 10
#define BUTTON_PIN_DOWN 11
#define BUTTON_PIN_SELECT 8

Bounce back = Bounce(BUTTON_PIN_BACK, 10);
Bounce up = Bounce(BUTTON_PIN_UP, 10);
Bounce down = Bounce(BUTTON_PIN_DOWN, 10);
Bounce select = Bounce(BUTTON_PIN_SELECT, 10);

void setup() {
  pinMode(BUTTON_PIN_BACK,INPUT);

  pinMode(BUTTON_PIN_UP, INPUT);

  pinMode(BUTTON_PIN_DOWN, INPUT);

  pinMode(BUTTON_PIN_SELECT, INPUT);

  Serial.begin(9600);
}

void loop() {


  back.update();
  up.update();
  down.update();
  select.update();
  
  if (back.fallingEdge()) {
      //Back Button one is pressed!
      Serial.println("back");
  }
  if (up.fallingEdge()) {
      //Up button one is pressed!
      Serial.println("up");
  }
  if (down.fallingEdge()) {
      //Down button one is pressed!
      Serial.println("down");
  }
  if (select.fallingEdge()) {
      //Select button one is pressed!
      Serial.println("select");
  }
 
}
