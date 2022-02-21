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

namespace Progetto_Supervisione_ITIS
{
    public partial class Main_Window : Form
    {

        private readonly System.Timers.Timer _timer;

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

        private bool stato_luce_2;


        //private IS7PlcService _plcService;

        S7PlcService s7PlcService = new S7PlcService();


        public Main_Window()
        {
            InitializeComponent();

            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();

            this.ledBulb1.On = false;
            this.ledBulb2.On = false;


        }

        // Chiamata timer
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnPlcServiceValuesRefreshed();
        }


        private void Main_Window_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Pluto");
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

        private async void BT_Start_2_Click(object sender, EventArgs e)
        {
            Start_BT_2();
        }

        private async void BT_Stop_2_Click(object sender, EventArgs e)
        {
            Stop_BT_2();
        }

        private async Task Start_BT_2()
        {
            await s7PlcService.Start_BT_2();

        }

        private async Task Stop_BT_2()
        {
            await s7PlcService.Stop_BT_2();
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

                    stato_luce_2 = s7PlcService.TBX_segnalazione_2;

                    if (stato_luce_1 == true)
                    {
                        // Accensione led sinottico 
                        ledBulb1.On = true;
                    }
                    else if (stato_luce_1 == false)
                    {
                        // Spengo led sinottico
                        ledBulb1.On = false;
                    }

                    if (stato_luce_2 == true)
                    {
                        // Accensione led sinottico 
                        ledBulb2.On = true;
                    }
                    else if (stato_luce_2 == false)
                    {
                        // Spengo led sinottico
                        ledBulb2.On = false;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ledBulb1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
