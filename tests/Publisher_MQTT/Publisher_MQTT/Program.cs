using System;
using System.Net;
using System.Timers;
using System.Threading;

namespace Thingspeak_Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- PUBLISHER ---");

            do {
                Random random1 = new Random();
                Random random2 = new Random();
                Random random3 = new Random();
                float light = (random1.Next(0, 150));
                float temperature = (random2.Next(0, 150));
                float humidity = (random3.Next(0, 150));
                //Console.WriteLine("Temperature: " + temperature + " °C");

                // Send measure to Thingspeak //light
                const string WRITEKEY = "0V77AVSPAOLE5AQH";
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
                    else if (string.Equals(ThingsSpeakResp.StatusDescription, "OK"))
                    {
                        Console.WriteLine("Sended field 1: " + light + " °C\n\n");
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
                Thread.Sleep(20000);


                //==== PUBB 2====
                strUpdateURI += "&field2=" + strField1;

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
                    else if (string.Equals(ThingsSpeakResp.StatusDescription, "OK"))
                    {
                        Console.WriteLine("Sended field 2: " + temperature + " °C\n\n");
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
                Thread.Sleep(20000);

                //==== PUBB 3====
                strUpdateURI += "&field3=" + strField1;

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
                    else if (string.Equals(ThingsSpeakResp.StatusDescription, "OK"))
                    {
                        Console.WriteLine("Sended field 3: " + humidity + " °C\n\n");
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
                Thread.Sleep(20000);
            } while (true);            
        }          
    }
}