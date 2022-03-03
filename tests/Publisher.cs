using System;
using System.Net;
using System.Timers;

namespace Thingspeak_Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Timer
            Timer measureTimer = new Timer();
            measureTimer.Elapsed += new ElapsedEventHandler(MeasureGeneration);
            measureTimer.Interval = 30000; // 30 s
            measureTimer.Start();

            Console.WriteLine("--- PUBLISHER ---");

            // Console remain open
            while (Console.Read() != 'q');

        }

        private static void MeasureGeneration(object sender, ElapsedEventArgs e)
        {
            // Generate new measure
            Random random = new Random();
            float temperature = (random.Next(0, 150));
            Console.WriteLine("Temperature: " + temperature + " °C");

            // Send measure to Thingspeak
            const string WRITEKEY = "";
            string strUpdateBase = "http://api.thingspeak.com/update";
            string strUpdateURI = strUpdateBase + "?key=" + WRITEKEY;
            string strField1 = temperature.ToString();
            HttpWebRequest ThingsSpeakReq;
            HttpWebResponse ThingsSpeakResp;

            strUpdateURI += "&field1=" + strField1;

            try
            {
                ThingsSpeakReq = (HttpWebRequest)WebRequest.Create(strUpdateURI);

                ThingsSpeakResp = (HttpWebResponse)ThingsSpeakReq.GetResponse();

                // If response is not "OK"
                if (!(string.Equals(ThingsSpeakResp.StatusDescription, "OK")))
                {
                    Exception exData = new Exception(ThingsSpeakResp.StatusDescription);
                    throw exData;
                }

                // If response is "OK"
                else if(string.Equals(ThingsSpeakResp.StatusDescription, "OK"))
                {
                    Console.WriteLine("Sended to Thingspeak: " + temperature + " °C");
                }
            
            }catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }


        }
    }
}
