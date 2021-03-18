#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x3F, 16, 2); // Make sure to use I2Cscan to find the address and put it instead of 0x3F

const int buttonPin = 2;

int bNew;
int bOld;
int bState = 1;

String inputData;

void setup()
{
  lcd.init();
  Serial.begin(9600);

  lcd.backlight();
  lcd.clear();
  lcd.print("Waiting...");
}

void loop()
{
  while (Serial.available() > 0)
  {
    char received = Serial.read();
    inputData += received;
      
    if (received == 'c')
    {
      inputData.remove(inputData.length() - 1, 1);
      lcd.setCursor(0, 0);
      lcd.print("CPU Temp: " + inputData + char(223) + "C ");
      inputData = ""; 
    }
 
    if (received == 'g')
    {
      inputData.remove(inputData.length() - 1, 1);
      lcd.setCursor(0, 1);
      lcd.print("GPU Temp: " + inputData + char(223) + "C ");
      inputData = ""; 
    }
  }
  
  setLCDState();
}

void setLCDState() {
  bNew = digitalRead(buttonPin);

  if(bNew == 1 && bOld == 0) {
    if(bState == 0) {
      lcd.backlight();
      bState = 1;
    } else {
      lcd.noBacklight();
      bState = 0;
    }
  }

  bOld = bNew;
}
