namespace Progetto_Supervisione_ITIS
{
    partial class Main_Window
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.BT_Start = new System.Windows.Forms.Button();
            this.BT_Stop = new System.Windows.Forms.Button();
            this.BT_Connessione = new System.Windows.Forms.Button();
            this.BT_Disconnetti = new System.Windows.Forms.Button();
            this.TBX_IP_Plc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBX_Rack_1 = new System.Windows.Forms.TextBox();
            this.TBX_Slot_1 = new System.Windows.Forms.TextBox();
            this.TBX_Connection_State = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BT_Start_2 = new System.Windows.Forms.Button();
            this.BT_Stop_2 = new System.Windows.Forms.Button();
            this.ledBulb1 = new Bulb.LedBulb();
            this.ledBulb2 = new Bulb.LedBulb();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_Start
            // 
            this.BT_Start.Location = new System.Drawing.Point(29, 228);
            this.BT_Start.Margin = new System.Windows.Forms.Padding(2);
            this.BT_Start.Name = "BT_Start";
            this.BT_Start.Size = new System.Drawing.Size(56, 19);
            this.BT_Start.TabIndex = 0;
            this.BT_Start.Text = "Start";
            this.BT_Start.UseVisualStyleBackColor = true;
            this.BT_Start.Click += new System.EventHandler(this.BT_Start_Click_1);
            // 
            // BT_Stop
            // 
            this.BT_Stop.Location = new System.Drawing.Point(29, 261);
            this.BT_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(56, 19);
            this.BT_Stop.TabIndex = 1;
            this.BT_Stop.Text = "Stop";
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click_1);
            // 
            // BT_Connessione
            // 
            this.BT_Connessione.Location = new System.Drawing.Point(178, 32);
            this.BT_Connessione.Margin = new System.Windows.Forms.Padding(2);
            this.BT_Connessione.Name = "BT_Connessione";
            this.BT_Connessione.Size = new System.Drawing.Size(75, 19);
            this.BT_Connessione.TabIndex = 3;
            this.BT_Connessione.Text = "Connetti";
            this.BT_Connessione.UseVisualStyleBackColor = true;
            this.BT_Connessione.Click += new System.EventHandler(this.BT_Connessione_Click);
            // 
            // BT_Disconnetti
            // 
            this.BT_Disconnetti.Location = new System.Drawing.Point(313, 32);
            this.BT_Disconnetti.Margin = new System.Windows.Forms.Padding(2);
            this.BT_Disconnetti.Name = "BT_Disconnetti";
            this.BT_Disconnetti.Size = new System.Drawing.Size(75, 19);
            this.BT_Disconnetti.TabIndex = 4;
            this.BT_Disconnetti.Text = "Disconnetti";
            this.BT_Disconnetti.UseVisualStyleBackColor = true;
            this.BT_Disconnetti.Click += new System.EventHandler(this.BT_Disconnetti_Click);
            // 
            // TBX_IP_Plc
            // 
            this.TBX_IP_Plc.Location = new System.Drawing.Point(29, 32);
            this.TBX_IP_Plc.Margin = new System.Windows.Forms.Padding(2);
            this.TBX_IP_Plc.Name = "TBX_IP_Plc";
            this.TBX_IP_Plc.Size = new System.Drawing.Size(92, 20);
            this.TBX_IP_Plc.TabIndex = 5;
            this.TBX_IP_Plc.Text = "192.168.100.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "IPv4 PLC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Slot";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TBX_Rack_1
            // 
            this.TBX_Rack_1.Location = new System.Drawing.Point(178, 86);
            this.TBX_Rack_1.Margin = new System.Windows.Forms.Padding(2);
            this.TBX_Rack_1.Name = "TBX_Rack_1";
            this.TBX_Rack_1.Size = new System.Drawing.Size(76, 20);
            this.TBX_Rack_1.TabIndex = 11;
            this.TBX_Rack_1.Text = "0";
            // 
            // TBX_Slot_1
            // 
            this.TBX_Slot_1.Location = new System.Drawing.Point(313, 87);
            this.TBX_Slot_1.Margin = new System.Windows.Forms.Padding(2);
            this.TBX_Slot_1.Name = "TBX_Slot_1";
            this.TBX_Slot_1.Size = new System.Drawing.Size(76, 20);
            this.TBX_Slot_1.TabIndex = 12;
            this.TBX_Slot_1.Text = "0";
            // 
            // TBX_Connection_State
            // 
            this.TBX_Connection_State.Location = new System.Drawing.Point(29, 86);
            this.TBX_Connection_State.Margin = new System.Windows.Forms.Padding(2);
            this.TBX_Connection_State.Name = "TBX_Connection_State";
            this.TBX_Connection_State.Size = new System.Drawing.Size(76, 20);
            this.TBX_Connection_State.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stato Connessione PLC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Luce 1";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // BT_Start_2
            // 
            this.BT_Start_2.Location = new System.Drawing.Point(339, 223);
            this.BT_Start_2.Name = "BT_Start_2";
            this.BT_Start_2.Size = new System.Drawing.Size(75, 23);
            this.BT_Start_2.TabIndex = 17;
            this.BT_Start_2.Text = "Start";
            this.BT_Start_2.UseVisualStyleBackColor = true;
            this.BT_Start_2.Click += new System.EventHandler(this.BT_Start_2_Click);
            // 
            // BT_Stop_2
            // 
            this.BT_Stop_2.Location = new System.Drawing.Point(339, 256);
            this.BT_Stop_2.Name = "BT_Stop_2";
            this.BT_Stop_2.Size = new System.Drawing.Size(75, 23);
            this.BT_Stop_2.TabIndex = 18;
            this.BT_Stop_2.Text = "Stop";
            this.BT_Stop_2.UseVisualStyleBackColor = true;
            this.BT_Stop_2.Click += new System.EventHandler(this.BT_Stop_2_Click);
            // 
            // ledBulb1
            // 
            this.ledBulb1.Location = new System.Drawing.Point(105, 232);
            this.ledBulb1.Name = "ledBulb1";
            this.ledBulb1.On = true;
            this.ledBulb1.Size = new System.Drawing.Size(75, 34);
            this.ledBulb1.TabIndex = 19;
            this.ledBulb1.Text = "ledBulb1";
            // 
            // ledBulb2
            // 
            this.ledBulb2.Location = new System.Drawing.Point(433, 232);
            this.ledBulb2.Name = "ledBulb2";
            this.ledBulb2.On = true;
            this.ledBulb2.Size = new System.Drawing.Size(95, 34);
            this.ledBulb2.TabIndex = 20;
            this.ledBulb2.Text = "ledBulb2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 195);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Luce 2";
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ledBulb2);
            this.Controls.Add(this.ledBulb1);
            this.Controls.Add(this.BT_Stop_2);
            this.Controls.Add(this.BT_Start_2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBX_Connection_State);
            this.Controls.Add(this.TBX_Slot_1);
            this.Controls.Add(this.TBX_Rack_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBX_IP_Plc);
            this.Controls.Add(this.BT_Disconnetti);
            this.Controls.Add(this.BT_Connessione);
            this.Controls.Add(this.BT_Stop);
            this.Controls.Add(this.BT_Start);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main_Window";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_Start;
        private System.Windows.Forms.Button BT_Stop;
        private System.Windows.Forms.Button BT_Connessione;
        private System.Windows.Forms.Button BT_Disconnetti;
        private System.Windows.Forms.TextBox TBX_IP_Plc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBX_Rack_1;
        private System.Windows.Forms.TextBox TBX_Slot_1;
        private System.Windows.Forms.TextBox TBX_Connection_State;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BT_Start_2;
        private System.Windows.Forms.Button BT_Stop_2;
        private Bulb.LedBulb ledBulb1;
        private Bulb.LedBulb ledBulb2;
        private System.Windows.Forms.Label label6;
    }
}

