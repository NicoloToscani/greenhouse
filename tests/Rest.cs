using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace Progetto_Supervisione_ITIS
{
    class Rest
    {


        const string READKEY = "GCIDJicGCzsQLz03BygSIDo";
        //string strUpdateBase = "http://api.thingspeak.com/channels/1663304/fields/1.json?api_key=MSO3J9WPKF6XRPRO&results=2";

        public List<float> values;
        public List<float> values_temp;
        public List<float> values_hum;

        // Timer
        System.Timers.Timer _chartTimer = new System.Timers.Timer();


        public List<float> getValues()
        {
            return this.values;
        }

        public List<float> getValues_temp()
        {
            return this.values_temp;
        }

        public List<float> getValues_hum()
        {
            return this.values_hum;
        }


        public Rest()
        {

            _chartTimer = new System.Timers.Timer();
            _chartTimer.Interval = 1000;
            _chartTimer.Elapsed += OnTimerElapsedChart;
            _chartTimer.Start();

            // // Console remain open
            // while (Console.Read() != 'q') ;

            this.values = new List<float>();
            this.values_temp = new List<float>();
            this.values_hum = new List<float>();
        }

        private void OnTimerElapsedChart(object sender, ElapsedEventArgs e)
        {
            string strUpdateBase = "http://api.thingspeak.com/channels/1663304/fields/1.json?api_key=MSO3J9WPKF6XRPRO&results=2";

            WebRequest ThingsSpeakReq;
            HttpWebResponse ThingsSpeakResp;

            ThingsSpeakReq = WebRequest.Create(strUpdateBase);
            ThingsSpeakResp = (HttpWebResponse)ThingsSpeakReq.GetResponse();

            Stream stream = ThingsSpeakResp.GetResponseStream();
            StreamReader Reader = new StreamReader(stream);
            String value = Reader.ReadToEnd();

            int start = value.LastIndexOf("field1");
            int start2 = value.LastIndexOf("created_at");
            int start3 = value.LastIndexOf("created_at");
            string segments = value.Substring(start + 9, 2);
            Console.WriteLine(segments);
            string time = value.Substring(start2 + 15, 8);
            string ora = value.Substring(start3 + 24, 8);
            Console.WriteLine("VALORE: " + segments + "\nDATA: " + time + "\nORA: " + ora + "\n\n");
            Console.ReadLine();
            values.Add(float.Parse(segments));
            Thread.Sleep(20000);

            //=================== 2
            strUpdateBase = "http://api.thingspeak.com/channels/1663304/fields/2.json?api_key=MSO3J9WPKF6XRPRO&results=2";

            ThingsSpeakReq = WebRequest.Create(strUpdateBase);
            ThingsSpeakResp = (HttpWebResponse)ThingsSpeakReq.GetResponse();

            stream = ThingsSpeakResp.GetResponseStream();
            Reader = new StreamReader(stream);
            value = Reader.ReadToEnd();

            start = value.LastIndexOf("field2");
            start2 = value.LastIndexOf("created_at");
            start3 = value.LastIndexOf("created_at");
            segments = value.Substring(start + 9, 2);
            Console.WriteLine(segments);
            time = value.Substring(start2 + 15, 8);
            ora = value.Substring(start3 + 24, 8);
            Console.WriteLine("VALORE: " + segments + "\nDATA: " + time + "\nORA: " + ora + "\n\n");
            Console.ReadLine();
            values_temp.Add(float.Parse(segments));
            Thread.Sleep(20000);

            //=================== 3
            strUpdateBase = "http://api.thingspeak.com/channels/1663304/fields/3.json?api_key=MSO3J9WPKF6XRPRO&results=2";

            ThingsSpeakReq = WebRequest.Create(strUpdateBase);
            ThingsSpeakResp = (HttpWebResponse)ThingsSpeakReq.GetResponse();

            stream = ThingsSpeakResp.GetResponseStream();
            Reader = new StreamReader(stream);
            value = Reader.ReadToEnd();

            start = value.LastIndexOf("field3");
            start2 = value.LastIndexOf("created_at");
            start3 = value.LastIndexOf("created_at");
            segments = value.Substring(start + 9, 2);
            Console.WriteLine(segments);
            time = value.Substring(start2 + 15, 8);
            ora = value.Substring(start3 + 24, 8);
            Console.WriteLine("VALORE: " + segments + "\nDATA: " + time + "\nORA: " + ora + "\n\n");
            Console.ReadLine();
            values_hum.Add(float.Parse(segments));
        }

        
    }
}
