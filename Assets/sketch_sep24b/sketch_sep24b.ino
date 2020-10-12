#define LOWPASS_ANALOG_IN analogRead(A0)

float lowpass_prev_output = LOWPASS_ANALOG_IN, lowpass_cur_output = LOWPASS_ANALOG_IN;
int lowpass_input = LOWPASS_ANALOG_IN;

int lowpass_sample(int sample_rate, int sampleAmount, float alpha, char previousValue){

   float minusAlpha = 1.0 - alpha; 
   int sampleDelay = max(100, (100000/sample_rate) - 160); 

   if(!previousValue){
    lowpass_input = analogRead(A0); 
    lowpass_prev_output = lowpass_input; 
   }

   
for (int i = sampleAmount; i > 0; i--){
  delayMicroseconds(sampleDelay); 
  lowpass_input = analogRead(A0);
  lowpass_cur_output = alpha * lowpass_input + minusAlpha * lowpass_prev_output;
  lowpass_prev_output = lowpass_cur_output; 
  }
  return lowpass_cur_output; 

}


void setup() {
  Serial.begin(115200); 
  pinMode(13, OUTPUT); 

  lowpass_sample(1000, 300, 0.015, false); 
}

void loop() {
  digitalWrite(13, HIGH);
   int resulting_value = lowpass_sample(1000,     //sampleRate
                                        50,       //sampleAmount
                                        0.015,    //alpha
                                        true);    //adapt from stored value
    
  Serial.println(resulting_value); 
}
