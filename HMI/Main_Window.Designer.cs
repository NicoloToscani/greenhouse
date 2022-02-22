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
            this.components = new System.ComponentModel.Container();
            this.BT_Start = new System.Windows.Forms.Button();
            this.BT_Stop = new System.Windows.Forms.Button();
            this.TBX_Segnalazione = new System.Windows.Forms.TextBox();
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
            
            this.SuspendLayout();
            // 
            // BT_Start
            // 
            this.BT_Start.Location = new System.Drawing.Point(85, 281);
            this.BT_Start.Name = "BT_Start";
            this.BT_Start.Size = new System.Drawing.Size(75, 23);
            this.BT_Start.TabIndex = 0;
            this.BT_Start.Text = "Start";
            this.BT_Start.UseVisualStyleBackColor = true;
            this.BT_Start.Click += new System.EventHandler(this.BT_Start_Click_1);
            // 
            // BT_Stop
            // 
            this.BT_Stop.Location = new System.Drawing.Point(85, 328);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(75, 23);
            this.BT_Stop.TabIndex = 1;
            this.BT_Stop.Text = "Stop";
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click_1);
            // 
            // TBX_Segnalazione
            // 
            this.TBX_Segnalazione.Location = new System.Drawing.Point(188, 308);
            this.TBX_Segnalazione.Name = "TBX_Segnalazione";
            this.TBX_Segnalazione.Size = new System.Drawing.Size(100, 22);
            this.TBX_Segnalazione.TabIndex = 2;
            // 
            // BT_Connessione
            // 
            this.BT_Connessione.Location = new System.Drawing.Point(237, 39);
            this.BT_Connessione.Name = "BT_Connessione";
            this.BT_Connessione.Size = new System.Drawing.Size(100, 23);
            this.BT_Connessione.TabIndex = 3;
            this.BT_Connessione.Text = "Connetti";
            this.BT_Connessione.UseVisualStyleBackColor = true;
            this.BT_Connessione.Click += new System.EventHandler(this.BT_Connessione_Click);
            // 
            // BT_Disconnetti
            // 
            this.BT_Disconnetti.Location = new System.Drawing.Point(417, 40);
            this.BT_Disconnetti.Name = "BT_Disconnetti";
            this.BT_Disconnetti.Size = new System.Drawing.Size(100, 23);
            this.BT_Disconnetti.TabIndex = 4;
            this.BT_Disconnetti.Text = "Disconnetti";
            this.BT_Disconnetti.UseVisualStyleBackColor = true;
            this.BT_Disconnetti.Click += new System.EventHandler(this.BT_Disconnetti_Click);
            // 
            // TBX_IP_Plc
            // 
            this.TBX_IP_Plc.Location = new System.Drawing.Point(39, 40);
            this.TBX_IP_Plc.Name = "TBX_IP_Plc";
            this.TBX_IP_Plc.Size = new System.Drawing.Size(121, 22);
            this.TBX_IP_Plc.TabIndex = 5;
            this.TBX_IP_Plc.Text = "192.168.100.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "IPv4 PLC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Slot";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // TBX_Rack_1
            // 
            this.TBX_Rack_1.Location = new System.Drawing.Point(237, 106);
            this.TBX_Rack_1.Name = "TBX_Rack_1";
            this.TBX_Rack_1.Size = new System.Drawing.Size(100, 22);
            this.TBX_Rack_1.TabIndex = 11;
            this.TBX_Rack_1.Text = "0";
            // 
            // TBX_Slot_1
            // 
            this.TBX_Slot_1.Location = new System.Drawing.Point(417, 107);
            this.TBX_Slot_1.Name = "TBX_Slot_1";
            this.TBX_Slot_1.Size = new System.Drawing.Size(100, 22);
            this.TBX_Slot_1.TabIndex = 12;
            this.TBX_Slot_1.Text = "0";
            // 
            // TBX_Connection_State
            // 
            this.TBX_Connection_State.Location = new System.Drawing.Point(39, 106);
            this.TBX_Connection_State.Name = "TBX_Connection_State";
            this.TBX_Connection_State.Size = new System.Drawing.Size(100, 22);
            this.TBX_Connection_State.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stato Connessione PLC";
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Controls.Add(this.TBX_Segnalazione);
            this.Controls.Add(this.BT_Stop);
            this.Controls.Add(this.BT_Start);
            this.Name = "Main_Window";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_Start;
        private System.Windows.Forms.Button BT_Stop;
        private System.Windows.Forms.TextBox TBX_Segnalazione;
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
      
    }
}

