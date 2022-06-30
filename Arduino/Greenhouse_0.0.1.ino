#include <Servo.h>
#include <SimpleDHT.h>
#include <Platform.h>
#include <Settimino.h>


// Inizializzo variabili sensore luce
int light;
int data;
int temperature_int;
int humidity_int;
int earth_rain;

// Inizializzo variabili sensore DHT11 (temperatura, umidità)
int pinDHT11 = 4;
SimpleDHT11 dht11(pinDHT11);


byte mac[] = { 0xA8, 0x61, 0x0A, 0xAE, 0x84, 0xAE }; //remamber to set the unique MAC address to each of Your Arduino that is connected to the network
IPAddress Local(192, 168, 100, 10); // The IP address of Arduino
IPAddress PLC(192, 168, 100, 1); // The IP address of PLC
IPAddress Gateway(192, 168, 100, 1);// check it by typing IPCONFIG in CMD
IPAddress Subnet(255, 255, 255, 0); // check it by typing IPCONFIG in CMD

int DBNum = 1; // This DB must be present in your PLC
byte Buffer[20]; //this is the array of bytes that will be send to PLC or will be red from PLC
byte PLC_inputs_byte = 0;
byte Compare_old_PLC_inputs_byte = 0;

S7Client Client; //the name "Client" means that if we will use this name it will be related to our PLC. It's like calling PLC by settimino library

// Servomotore
Servo servo_dx;
Servo servo_sx;
int pos = 0;

// Comando velocità servomotori
int Servo_Dx_cmd;
int Servo_Sx_cmd;

void setup() {
  Serial.print("Setup");
  Serial.begin(115200);  //thanks to this we will be able to display some mesages on Arduino "Serial Monitor"
  EthernetInit(mac, Local); //initialization of Ethernet library
  delay(2000); //not nessesery, but it is good to wait some time after starting the initialization
  Serial.println("");
  Serial.println("Cable connected");  //those two lines are just the information on Serial Monitor that we are connected to the network by the cable
  Serial.print("Local IP address : "); //but after loading the program to Arduino, You schould open CMD and type "ping 192.168.0.51" or Your Arduino IP to see is it connected
  Serial.println(Ethernet.localIP()); //this will display Your Arduino IP
  // pinMode(34,INPUT);
  pinMode(6,OUTPUT);  //MOTORE SX
  pinMode(9,OUTPUT);  //MOTORE DX

  //POSIZIONE SERVOMOTORI
  // Motore 1

  // Motore 2
  //servo_sx.attach(9);
  //servo_sx.write(Servo_Dx_cmd);
}

bool Connect() //this is the function of connection to PLC, but first have a look at first line in LOOP!
{
  int Result = Client.ConnectTo(PLC, 0, 1); // (PLC IP address, RACK number, SLOT number)
  Serial.print("Connecting to "); Serial.println(PLC); // Displaing the information that our Arduino is trying to establish the connection with PLC
  if (Result == 0) {
    Serial.print("You are connected to the PLC S7_1200"); // if everytfing was fine Arduino displays "You are connected to the PLC S7_1200"
  }
  else {
    Serial.println("Connection error"); //otherwise it displays "Connection error"
  }
  return Result; //if we are connected we return 0, otherwise we return 1
}


void loop() //OB1
{

  // Motore pin 8
  // chiuso: 170
  // aperto: 5

  // servo_dx.write(Servo_Dx_cmd);
  // servo_sx.write(Servo_Sx_cmd);

  // If PLC is connected
  while (!Client.Connected) {
    if (Connect() == 0) {
      delay(500);
    }
  }  //if everything is fine this line schould be made only once. It is checking are we connected with PLC, if not then the program is jumping to CONNECT function

  // PLC_Inputs(); // Read from PLC

  // Read sensor data

  // lettura valori sensore luce
  light = analogRead(A0);
  data = map(light, 0, 1024, 0, 100);

  // lettura valore umidità terreno
  int earthHumidity = analogRead(A1);
  earth_rain = map(earthHumidity, 0, 1023, 100, 0);

  // lettura valori sensore DHT11
  byte temperature = 0;
  byte humidity = 0;
  int err = SimpleDHTErrSuccess;
  if ((err = dht11.read(&temperature, &humidity, NULL)) != SimpleDHTErrSuccess) {
    Serial.print("Errore DHT, err="); Serial.print(SimpleDHTErrCode(err));
    Serial.print(","); Serial.println(SimpleDHTErrDuration(err)); delay(1000);
    // return;
  } else {
    temperature_int = (int)temperature;
    humidity_int = (int)humidity;

    Serial.print("\n\nLETTURA DATI:");
    Serial.print("\nLight: ");
    Serial.println(data);
    Serial.print("Temperature: ");
    Serial.println(temperature_int);
    Serial.print("Humidity: ");
    Serial.println(humidity_int);
    Serial.print("Earth rain: ");
    Serial.println(earth_rain);
    Serial.print("\n\n");
    delay(4000);

  }

/*
  if(temperature_int >= 31)
  {
    servo_sx.write(180);
  }
  else
  {
    servo_sx.write(0);
  }*/

  // Read data from PLC
  ReadFromPLC();
  WriteToPLC(); // Write values to PLC

  

  //Connect();
   

  

  // After read sensor data send values to PLC
  



}


// Read PLC Input
void PLC_Inputs() {
  PLC_inputs_byte = 0;
  if (!digitalRead(34)) {
    PLC_inputs_byte = PLC_inputs_byte | 1;
  }
  if (!digitalRead(41)) {
    PLC_inputs_byte = PLC_inputs_byte | 2;
  }
  if (PLC_inputs_byte != Compare_old_PLC_inputs_byte) { //if the value of those two bytes are different...
    WriteToPLC(); //then jump to WriteToPlc function
  }
  Compare_old_PLC_inputs_byte = PLC_inputs_byte; //write current value to compare variable
}

// Write value to PLC
void WriteToPLC() {

  while (!Client.Connected) {
    if (Connect() == 0) {
      delay(500);
    }
  }

  Serial.print("Write to PLC");

  // int ReadArea(int Area, uint16_t DBNumber, uint16_t Start, uint16_t Amount, void *pUsrData);
  // Area: Area identifier
  // DBNumber: DB Number if  Area = S7AreaDB, otherwise is ignored.
  // Start: Offset to start
  // Amount: Amount of words to read (1)
  // pUsrData: Address of user buffer.

  Buffer[4] = 0;

  // Valore di prova 1
  float f = 123.45;
  byte* bytes = (byte*)&f;

  // Valore di prova 2
  float f2 = 656.99;

  // Valore di prova intero
  int pippo = 5528;

  // Reverse4 exchanges (Big<->Little endian) the bytes inside a float/dword/dint (4 bytes variable)
  Reverse4(&f);
  Reverse4(&f2);

  // Reverse2 exchanges (Big<->Little endian) the bytes inside a word/int (2 bytes variable)
  Reverse2(&data);
  Reverse2(&temperature_int);
  Reverse2(&humidity_int);
  Reverse2(&earth_rain);


  //Scrittura luce
  int ResultLight = Client.WriteArea(S7AreaDB, 2, 0, sizeof(int), &data); //we are trying to write one byte to PLC (DB_area,DB1,from address 0, from Buffer array)
  if (ResultLight == 0) {
    Serial.println("DB write OK");
  }
  else {
    Serial.println("DB write NOK");
  }

  //Scrittura temperatura
  int ResultTemperature = Client.WriteArea(S7AreaDB, 2, 4, sizeof(int), &temperature_int); //we are trying to write one byte to PLC (DB_area,DB1,from address 0, from Buffer array)
  if (ResultTemperature == 0) {
    Serial.println("DB write OK");
  }
  else {
    Serial.println("DB write NOK");
  }

  //Scrittura umidità
  int ResultHumidity = Client.WriteArea(S7AreaDB, 2, 2, sizeof(int), &humidity_int); //we are trying to write one byte to PLC (DB_area,DB1,from address 0, from Buffer array)
  if (ResultHumidity == 0) {
    Serial.println("DB write OK");
  }
  else {
    Serial.println("DB write NOK");
  }

  //Scrittura umidità terra
  int ResultEarthRain = Client.WriteArea(S7AreaDB, 2, 6, sizeof(int), &earth_rain); //we are trying to write one byte to PLC (DB_area,DB1,from address 0, from Buffer array)
  if (ResultEarthRain == 0) {
    Serial.println("DB write OK");
  }
  else {
    Serial.println("DB write NOK");
  }

}

void ReadFromPLC() {

  delay(1000);


 // byte MyBuffer_DX[2];
  byte MyBuffer_SX[2];
  byte MyBuffer_Man[2];
  byte MyBuffer_State[2];

  int servo_man_cmd;
  int cycle_state;  // 0:Man, 1:Auto


  // int ReadArea(int Area, uint16_t DBNumber, uint16_t Start, uint16_t Amount, void *pUsrData);
  // Area: Area identifier
  // DBNumber: DB Number if  Area = S7AreaDB, otherwise is ignored.
  // Start: Offset to start
  // Amount: Amount of words to read (1)
  // pUsrData: Address of user buffer.


/*
  int Result_Servo_DX = Client.ReadArea(S7AreaDB, // We are requesting DB access
                                     2,        // DB Number = 1
                                     8,        // Start from byte N.0
                                     2,     // We need "Size" bytes
                                     &MyBuffer_DX);  // Put them into our target (Buffer or PDU)

  Servo_Dx_cmd = S7.IntegerAt(&MyBuffer_DX, 0);

  if(Servo_Dx_cmd == 0)
  {
    digitalWrite(9,LOW);
  }
  else if(Servo_Dx_cmd == 180)
  {
    digitalWrite(9,HIGH);
  }*/

  

    //Motor command for automatic cycle
   int Result_Servo_SX = Client.ReadArea(S7AreaDB, // We are requesting DB access
                                     2,        // DB Number = 1
                                     10,        // Start from byte N.0
                                     2,     // We need "Size" bytes
                                     &MyBuffer_SX);  // Put them into our target (Buffer or PDU)

  //Manual Servo State
  int Result_Servo_Manual_cmd = Client.ReadArea(S7AreaDB, // We are requesting DB access
                                     1,        // DB Number = 1
                                     18,        // Start from byte N.0
                                     2,     // We need "Size" bytes
                                     &MyBuffer_Man);  // Put them into our target (Buffer or PDU)
                                     

  int Result_Man_Aut_cmd = Client.ReadArea(S7AreaDB, // We are requesting DB access
                                     1,        // DB Number = 1
                                     20,        // Start from byte N.0
                                     2,     // We need "Size" bytes
                                     &MyBuffer_State);  // Put them into our target (Buffer or PDU)

  

  Servo_Sx_cmd = S7.IntegerAt(&MyBuffer_SX, 0);
  servo_man_cmd = S7.IntegerAt(&MyBuffer_Man, 0);
  cycle_state = S7.IntegerAt(&MyBuffer_State, 0);

  //Serial.println("\nMANUALE: ");
  //Serial.println(servo_man_cmd);


  if(cycle_state == 0)
  {
    if(servo_man_cmd == 0)
    {
      digitalWrite(6,LOW);
    }
    else if(servo_man_cmd == 180)
    {
      digitalWrite(6,HIGH);
    }
  }
  else if(cycle_state == 1)
  {
      if(Servo_Sx_cmd == 0)
      {
       digitalWrite(6,LOW);
      }
      else if(Servo_Sx_cmd == 180)
      {
       digitalWrite(6,HIGH);
      }
  }

  

  //int Result = Client.ConnectTo(PLC, 0, 1); // (PLC IP address, RACK number, SLOT number)

  // delay(2000);
  /*
    Servo_Sx_cmd = S7.IntegerAt(&MyBuffer, 2);
    Serial.print("Servo_Sx_cmd: ");
    Serial.print(Servo_Sx_cmd);
  */




}


//----------------------------------------------------------------------
// Reverse float/dword/dint
//----------------------------------------------------------------------
void Reverse4(void *ptr)
{
  byte *pb;
  byte tmp;
  pb = (byte*)(ptr);
  // Swap byte 4 with byte 1
  tmp = *(pb + 3);
  *(pb + 3) = *pb;
  *pb = tmp;
  // Swap byte 3 with byte 2
  tmp = *(pb + 2);
  *(pb + 2) = *(pb + 1);
  *(pb + 1) = tmp;
}
//----------------------------------------------------------------------
// Reverse word/int
//----------------------------------------------------------------------
void Reverse2(void *ptr)
{
  byte *pb;
  byte tmp;
  pb = (byte*)(ptr);
  // Swap byte 2 with byte 1
  tmp = *(pb + 1);
  *(pb + 1) = *pb;
  *pb = tmp;
}
