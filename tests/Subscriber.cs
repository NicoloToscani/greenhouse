using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Thingspeak
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Configure MQTT X to subscribe to updates of field1 from your channel 1666592 using mqtt3.thingspeak.com and port 1883.
            MqttClient mqttClient;

            String brokerURL = "mqtt3.thingspeak.com";
            mqttClient = new MqttClient(brokerURL);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            string clientId = "";   // client ID
            string username = "";   // username
            string password = "";  // password

            Console.WriteLine("--- SUBSCRIBER ---");


            try {

                // Connect to MQTT broker
                mqttClient.Connect(clientId, username, password);
                
                // Subscribe to MQTT broker
                mqttClient.Subscribe(new string[] { "channels/xxxxxxx/subscribe/fields/field1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            
            }
            catch (Exception exception){

                Console.WriteLine(exception.ToString());
            }

            // // Console remain open
            while (Console.Read() != 'q');

        }

        // When arrived new data
        private static void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine("Temperature: " + message + " °C");
        }
    }
}
