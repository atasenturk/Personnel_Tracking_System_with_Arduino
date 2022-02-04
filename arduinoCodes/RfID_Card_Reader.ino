#include <SPI.h>                   //SPI kütüphanemizi tanımlıyoruz.
#include <MFRC522.h>              //MFRC522 kütüphanemizi tanımlıyoruz.
#include <LiquidCrystal.h>

int RST_PIN = 9; //RC522 modülü reset pinini tanımlıyoruz.
int SS_PIN = 10; //RC522 modülü chip select pinini tanımlıyoruz.

LiquidCrystal lcd = LiquidCrystal(8,7,6,5,4,3);

MFRC522 rfid(SS_PIN, RST_PIN); //RC522 modülü ayarlarını yapıyoruz.
byte Card1[4] = {
  39,
  35,
  165,
  75
}; //Yetkili kart ID'sini tanımlıyoruz. 

byte Card2[4] = {
  154,
  80,
  122,
  130
}; //Yetkili kart ID'sini tanımlıyoruz.

byte Card3[4] = {
  10,
  33,
  149,
  25
}; //Yetkili kart ID'sini tanımlıyoruz.


void setup() {
  Serial.begin(9600); //Seri haberleşmeyi başlatıyoruz.
  SPI.begin(); //SPI iletişimini başlatıyoruz.
  rfid.PCD_Init(); //RC522 modülünü başlatıyoruz.
  lcd.begin(16, 2);
}
void loop() {
  if (!rfid.PICC_IsNewCardPresent()) //Yeni kartın okunmasını bekliyoruz.
    return;
  if (!rfid.PICC_ReadCardSerial()) //Kart okunmadığı zaman bekliyoruz.
    return;
  if (rfid.uid.uidByte[0] == Card1[0] && //Okunan kart ID'si ile ID değişkenini karşılaştırıyoruz.
    rfid.uid.uidByte[1] == Card1[1] &&
    rfid.uid.uidByte[2] == Card1[2] &&
    rfid.uid.uidByte[3] == Card1[3] ||
    rfid.uid.uidByte[0] == Card2[0] && //Okunan kart ID'si ile ID değişkenini karşılaştırıyoruz.
    rfid.uid.uidByte[1] == Card2[1] &&
    rfid.uid.uidByte[2] == Card2[2] &&
    rfid.uid.uidByte[3] == Card2[3] ||
    rfid.uid.uidByte[0] == Card3[0] && //Okunan kart ID'si ile ID değişkenini karşılaştırıyoruz.
    rfid.uid.uidByte[1] == Card3[1] &&
    rfid.uid.uidByte[2] == Card3[2] &&
    rfid.uid.uidByte[3] == Card3[3] 
    ) {
      // Set the cursor on the third column and the first row, counting starts at 0:
      
  lcd.setCursor(2, 0);
  // Print the string 'Hello World!':
  lcd.clear();
  lcd.print("Basarili Giris");
    delay(1000);
  lcd.clear();
  // Set the cursor on the third column and the second row:

  
    ekranaYazdir();
    Serial.println("");
  } else { //Yetkisiz girişte içerideki komutlar çalıştırılır.
    
      lcd.setCursor(2, 0);
  // Print the string 'Hello World!':
  lcd.clear();
  lcd.print("Tanimsiz Kart");
  delay(1000);
  lcd.clear();
  // Set the cursor on the third column and the second row:
  
  }
  rfid.PICC_HaltA();
}
void ekranaYazdir() {
  Serial.print("ID Numarasi: ");
  for (int sayac = 0; sayac < 4; sayac++) {
    Serial.print(rfid.uid.uidByte[sayac]);
    Serial.print(" ");
  }
}
