using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Progetto_Supervisione_ITIS
{
    class Subscriber_MQTT
    {
            // Configure MQTT X to subscribe to updates of field1 from your channel 1666592 using mqtt3.thingspeak.com and port 1883.
            MqttClient mqttClient;

            String brokerURL = "broker.hivemq.com";

            string clientId = "Ciao";   // client ID

            public List<float> values;
            public List<float> temperature;
            public List<float> humidity;


        public Subscriber_MQTT()
        {
            mqttClient = new MqttClient(brokerURL);
            mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;

            values = new List<float>();
            temperature = new List<float>();
            humidity = new List<float>();

            Console.WriteLine("--- SUBSCRIBER ---");

            try
            {

                // Connect to MQTT broker
                mqttClient.Connect(clientId);

                // Subscribe to MQTT broker
                mqttClient.Subscribe(new string[] { "/itis_GG/light" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });                
                mqttClient.Subscribe(new string[] { "/itis_GG/temperature" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
                mqttClient.Subscribe(new string[] { "/itis_GG/humidity" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });


            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.ToString());
            }

            // // Console remain open
            // while (Console.Read() != 'q') ;
        }

        // Get values
        public List<float> getValues()
        {
            return this.values;
        }

        public List<float> getTemperature()
        {
            return this.temperature;
        }

        public List<float> getHumidity()
        {
            return this.humidity;
        }

        // When arrived new data
        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);

            //Console.WriteLine("Light: " + message + " Lux");

            if(e.Topic == "/itis_GG/light")
            {
                values.Add(float.Parse(message));
            }
            
            else if (e.Topic == "/itis_GG/temperature")
            {
                temperature.Add(float.Parse(message));
            }
            
            else if (e.Topic == "/itis_GG/humidity")
            {
                humidity.Add(float.Parse(message));
            }
            
        }
    }
}

