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

        private readonly System.Timers.Timer _timer;

        // Timer aggiorna grafico
        private readonly System.Timers.Timer _chartTimer;

        public ChartValues<ObservableValue> Values { get; set; }
        public ChartValues<ObservableValue> Values_temp { get; set; }
        public ChartValues<ObservableValue> Values_hum { get; set; }

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
        Rest MQTTSubscriber = new Rest();

        // Liste ricezione dati da servizio MQTT
        List<String> temperatureValues;
        List<String> timestampValues;
        List<float> values;
        List<float> values_temp;
        List<float> values_hum;


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

            cartesianChart1.LegendLocation = LegendLocation.Right;


        }

        private void OnTimerElapsedChart(object sender, ElapsedEventArgs e)
        {
            // Se c'è almeno un dato
            if (this.values.Count > 0)
            {
                Values.Add(new ObservableValue(this.values.Last()));
            }

            if (this.values_temp.Count > 0)
            {
                Values_temp.Add(new ObservableValue(this.values_temp.Last()));
            }

            if (this.values_hum.Count > 0)
            {
                Values_hum.Add(new ObservableValue(this.values_hum.Last()));
            }
        }

        // Chiamata timer
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnPlcServiceValuesRefreshed();
        }


        private void Main_Window_Load(object sender, EventArgs e)
        {
            /*
            // live chart light
            cartesianChart1.Series.Add(new LineSeries
            {
                Values = Values,
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Title = "Light"

            });

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Timestamp",
                ShowLabels = false,

            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Lux"
            });*/
            
            // live chart temperature
            LIVEC_temperature.Series.Add(new LineSeries
            {
                Values = Values_temp,
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Title = "Temperature"

            });

            LIVEC_temperature.AxisX.Add(new Axis
            {
                Title = "Timestamp",
                ShowLabels = false,

            });

            LIVEC_temperature.AxisY.Add(new Axis
            {
                Title = "°C"
            });

            // live chart humidity
            LIVEC_humidity.Series.Add(new LineSeries
            {
                Values = Values_hum,
                StrokeThickness = 4,
                PointGeometrySize = 0,
                DataLabels = true,
                Title = "Humidity"

            });

            LIVEC_humidity.AxisX.Add(new Axis
            {
                Title = "Timestamp",
                ShowLabels = false,

            });

            LIVEC_humidity.AxisY.Add(new Axis
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
                    this.values = MQTTSubscriber.getValues();



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
    }
}
