using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;



namespace Progetto_Supervisione_ITIS
{
    public partial class Main_Window : Form
    {
        float light = 0;

        private readonly System.Timers.Timer _timer;

        // Timer aggiorna grafico
        private readonly System.Timers.Timer _chartTimer;

        public ChartValues<ObservableValue> Values { get; set; }
        public ChartValues<ObservableValue> Temperature { get; set; }
        public ChartValues<ObservableValue> Humidity { get; set; }

        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }
        private string _ipAddress;

        public string PlcConnectionState
        {
            get { return _plcConnectionState; }
            set { _plcConnectionState = value; }
        }
        private string _plcConnectionState;


        public int Rack
        {
            get { return _rack; }
            set { _rack = value; }
        }
        private int _rack;

        public int Slot
        {
            get { return _slot; }
            set { _slot = value; }
        }
        private int _slot;

        public ConnectionStates ConnectionState
        {
            get { return _connectionState; }
            set { _connectionState = value; }
        }
        private ConnectionStates _connectionState;


        public bool TBX_IP
        {
            get { return _tbxIP; }
            set { _tbxIP = value; }
        }
        private bool _tbxIP;
        
        public bool TBX_Rack
        {
            get { return _tbxRack; }
            set { _tbxRack = value; }
        }
        private bool _tbxRack;

        public bool TBX_Slot
        {
            get { return _tbxSlot; }
            set { _tbxSlot = value; }
        }
        private bool _tbxSlot;

        private bool stato_luce_1;


        //private IS7PlcService _plcService;

        S7PlcService s7PlcService = new S7PlcService();

        // MQTT service: riceve le 2 liste da plottare
        //Rest MQTTSubscriber = new Rest();

        Subscriber_MQTT subscriber_MQTT = new Subscriber_MQTT();


        // Liste ricezione dati da servizio MQTT
        List<String> temperatureValues;
        List<String> timestampValues;
        List<float> values;
        List<float> temperature;
        List<float> humidity;


        public Main_Window()
        {
            InitializeComponent();

            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();

            // Timer aggiornamento grafico
            _chartTimer = new System.Timers.Timer();
            _chartTimer.Interval = 30000;
            _chartTimer.Elapsed += OnTimerElapsedChart;
            _chartTimer.Start();

            Values = new ChartValues<ObservableValue>
            {

            };

            Temperature = new ChartValues<ObservableValue>
            {

            };

            Humidity = new ChartValues<ObservableValue>
            {

            };

            //cartesianChart1.LegendLocation = LegendLocation.Right;

            // definisco valore gauge
            SD_light.From = 0;
            SD_light.To = 100;

            SD_temperature.From = 0;
            SD_temperature.To = 100;

            SD_humidity.From = 0;
            SD_humidity.To = 100;



        }

        private void OnTimerElapsedChart(object sender, ElapsedEventArgs e)
        {
            // Se c'è almeno un dato
            if (this.values.Count > 0)
            {
                Values.Add(new ObservableValue(this.values.Last()));
            }

            // Se c'è almeno un dato
            if (this.temperature.Count > 0)
            {
                Temperature.Add(new ObservableValue(this.temperature.Last()));
            }

            // Se c'è almeno un dato
            if (this.humidity.Count > 0)
            {
                Humidity.Add(new ObservableValue(this.humidity.Last()));
            }
        }

        // Chiamata timer
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnPlcServiceValuesRefreshed();
        }


        private void Main_Window_Load(object sender, EventArgs e)
        {
            TXB_temperature.Text = "Low";
            TXB_humidity.Text = "Low";

            // Grafico luce
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = Values,
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Title = "Light"


            });

            
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Lux",
                
            });

            // Grafico temperatura
            LVCHART_temperature.Series.Add(new LineSeries
            {
                Values = Temperature,
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Title = "Temperature"

            });

            LVCHART_temperature.AxisY.Add(new Axis
            {
                Title = "°C"
            });

            // Grafico umidità
            LVCHART_Humid.Series.Add(new LineSeries
            {
                Values = Humidity,
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Title = "Humidity"

            });

            LVCHART_Humid.AxisY.Add(new Axis
            {
                Title = "%"
            });


        }

        

        private async void BT_Start_Click_1(object sender, EventArgs e)
        {
            Start_BT_1();
        }

        private async void BT_Stop_Click_1(object sender, EventArgs e)
        {
            Stop_BT_1();
        }

        private async Task Start_BT_1()
        {
             await s7PlcService.Start_BT_1();
           
        }

        private async Task Stop_BT_1()
        {
            await s7PlcService.Stop_BT_1();
        }

        private async Task BT_reset_1()
        {
            await s7PlcService.BT_reset_plc();
        }


        private async Task Start_Light()
        {
            await s7PlcService.Start_light();
        }


        private async Task Stop_Light()
        {
            await s7PlcService.Stop_light();
        }


        /*
        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {
            Console.WriteLine("Chiamato OnPlcservice");
            ConnectionState = s7PlcService.ConnectionState;

            TBX_IP = s7PlcService.TBX_segnalazione;
          
            if (TBX_IP == true) TBX_Segnalazione.Text = "Acceso";
            else if (TBX_IP == false) TBX_Segnalazione.Text = "Spento";

        }*/


        // Aggiorno la grafica
        public void OnPlcServiceValuesRefreshed()
        {
            // Stato connessione
            ConnectionState = s7PlcService.ConnectionState;


            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    if (ConnectionState == ConnectionStates.Online)
                    {
                        TBX_Connection_State.Text = "Connesso";
                    }
                    else if (ConnectionState == ConnectionStates.Offline)
                    {
                        TBX_Connection_State.Text = "Disconnesso";
                    }
                    else if (ConnectionState == ConnectionStates.Connecting)
                    {
                        TBX_Connection_State.Text = "In connessione";
                    }

                    // Gestione aggiornamento UI bit lampade

                    ConnectionState = s7PlcService.ConnectionState;

                    stato_luce_1 = s7PlcService.TBX_segnalazione;

                    if (stato_luce_1 == true)
                    {
                        ledBulb1.On = true;
                    }
                    else if (stato_luce_1 == false)
                    {
                        ledBulb1.On = false;
                    }

                    // Conteggio sensore
                    TBX_sensore.Text = s7PlcService.TBX_sensore;

                    // Aggiorno il grafico , ottengo le liste aaggiornate popolate in ricezione MQTT
                    // this.temperatureValues = MQTTSubscriber.getTemperature();
                    // this.timestampValues = MQTTSubscriber.getTimestamp();
                    this.values = subscriber_MQTT.getValues();
                    this.temperature = subscriber_MQTT.getTemperature();
                    this.humidity = subscriber_MQTT.getHumidity();

                    // Aggiungo il valore ottenuto ai gauge
                    if (this.values.Count > 0)
                    {
                        light = this.values.Last();
                        SD_light.Value = light;
                    }

                    if (this.temperature.Count > 0)
                    {
                        float temperature = this.temperature.Last();
                        SD_temperature.Value = temperature;

                        if(temperature <= 29)
                        {
                            TXB_temperature.Text = "Medium";
                        }
                        else if(temperature >= 30)
                        {
                            TXB_temperature.Text = "High";
                        }
                    }

                    if (this.humidity.Count > 0)
                    {
                        float humidity = this.humidity.Last();
                        SD_humidity.Value = humidity;

                        if (humidity <= 35)
                        {
                            TXB_humidity.Text = "Medium";
                        }
                        else if (humidity >= 36)
                        {
                            TXB_humidity.Text = "High";
                        }
                    }

                    if (light <= 50)
                    {
                        LB_light.On = true;
                        Start_Light();
                    }
                    else if (light > 50)
                    {
                        LB_light.On = false;
                        Stop_Light();
                    }

                });
            }catch(Exception e)
            {
                Console.WriteLine("Arresto in corso");
            }

        }

        public void Connect()
        {
            s7PlcService.Connect(IpAddress, Rack, Slot);
            
        }

        private void Disconnect()
        {
            s7PlcService.Disconnect();
          
        }

        private void BT_Connessione_Click(object sender, EventArgs e)
        {
            IpAddress = TBX_IP_Plc.Text;
            Rack = Int32.Parse(TBX_Rack_1.Text);
            Slot = Int32.Parse(TBX_Slot_1.Text);
            Connect();
        }

        private void BT_Disconnetti_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void BT_reset_Click(object sender, EventArgs e)
        {
           BT_reset_1();   
        }

        private void lb_cont_Click(object sender, EventArgs e)
        {

        }

        private void TBX_sensore_TextChanged(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
