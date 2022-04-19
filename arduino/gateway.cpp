#include <Platform.h>
#include "Settimino.h"

byte mac[] = { 0xA8, 0x61, 0x0A, 0xAE, 0x84, 0xAE }; //remamber to set the unique MAC address to each of Your Arduino that is connected to the network
IPAddress Local(192,168,100,10); // The IP address of Arduino
IPAddress PLC(192,168,100,1);   // The IP address of PLC
IPAddress Gateway(192, 168, 100, 1);// check it by typing IPCONFIG in CMD
IPAddress Subnet(255, 255, 255, 0); // check it by typing IPCONFIG in CMD

int DBNum = 1; // This DB must be present in your PLC
byte Buffer[20]; //this is the array of bytes that will be send to PLC or will be red from PLC
byte PLC_inputs_byte = 0;
byte Compare_old_PLC_inputs_byte = 0;

S7Client Client; //the name "Client" means that if we will use this name it will be related to our PLC. It's like calling PLC by settimino library



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
              // pinMode(41,INPUT);
              }

bool Connect() //this is the function of connection to PLC, but first have a look at first line in LOOP!
              {
              int Result=Client.ConnectTo(PLC,0,1); // (PLC IP address, RACK number, SLOT number)
              Serial.print("Connecting to ");Serial.println(PLC);  // Displaing the information that our Arduino is trying to establish the connection with PLC
              if (Result==0){Serial.print("You are connected to the PLC S7_1200");}// if everytfing was fine Arduino displays "You are connected to the PLC S7_1200"
              else {Serial.println("Connection error");} //otherwise it displays "Connection error"
              return Result; //if we are connected we return 0, otherwise we return 1
              }


void loop() //OB1
            { 

            // If PLC is connected
            while (!Client.Connected){
              if (Connect()==0){delay(500);}  
              }  //if everything is fine this line schould be made only once. It is checking are we connected with PLC, if not then the program is jumping to CONNECT function
            
            PLC_Inputs(); // Read from PLC

            // Read sensor data

            // After read sensor data send values to PLC
            WriteToPLC(); // Write values to PLC
            
            delay(500);  
            }


// Read PLC Input
void PLC_Inputs(){
                  PLC_inputs_byte = 0;
                  if(!digitalRead(34)){PLC_inputs_byte = PLC_inputs_byte | 1;}
                  if(!digitalRead(41)){PLC_inputs_byte = PLC_inputs_byte | 2;}
                  if(PLC_inputs_byte != Compare_old_PLC_inputs_byte){ //if the value of those two bytes are different...
                                                                    WriteToPLC(); //then jump to WriteToPlc function
                                                                    }
                  Compare_old_PLC_inputs_byte = PLC_inputs_byte; //write current value to compare variable
                  }

// Write value to PLC
void WriteToPLC(){
                  Buffer[0] = PLC_inputs_byte;
                  int Result=Client.WriteArea(S7AreaDB,1,0,1,Buffer);  //we are trying to write one byte to PLC (DB_area,DB1,from address 0, from Buffer array)
                  if (Result==0){Serial.println("DB write OK");}
                  else {Serial.println("DB write NOK");}
                   }