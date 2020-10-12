unsigned long last_time = 0; 

void setup()
{
    pinMode(13, OUTPUT);
    
    Serial.begin(9600);
}

void loop()
{
    digitalWrite(13, HIGH); 
    
    int analogValue = analogRead(A0);

    // Print a heartbeat
    if (millis() > last_time + 2000)
    {
        Serial.println("Arduino is alive!!");
        last_time = millis();
    }

    switch (Serial.read())
    {
        case 'A':
            Serial.println("Bloop");
            break;
        case 'Z':
            Serial.println("Blip");
            break;
        case 'Q':
            Serial.println("Analog reading = "); 
            Serial.println(analogValue);

            if (analogValue < 10) {
            Serial.println(" - Dark");
            } else if (analogValue < 200) {
            Serial.println(" - Dim");
            } else if (analogValue < 500) {
            Serial.println(" - Light");
            } else if (analogValue < 800) {
            Serial.println(" - Bright");
            } else {
            Serial.println(" - Very bright");
            }
            break;
        
    }
}
