namespace Lab03_Bai04_Server
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_Server = new System.Windows.Forms.GroupBox();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Listen = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_IP_Address = new System.Windows.Forms.TextBox();
            this.label_IP_Address = new System.Windows.Forms.Label();
            this.groupBox_Clients = new System.Windows.Forms.GroupBox();
            this.listBox_Clients = new System.Windows.Forms.ListBox();
            this.groupBox_Log = new System.Windows.Forms.GroupBox();
            this.textBox_Logs = new System.Windows.Forms.TextBox();
            this.groupBox_Server.SuspendLayout();
            this.groupBox_Clients.SuspendLayout();
            this.groupBox_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Server
            // 
            this.groupBox_Server.Controls.Add(this.button_Stop);
            this.groupBox_Server.Controls.Add(this.button_Listen);
            this.groupBox_Server.Controls.Add(this.textBox_Port);
            this.groupBox_Server.Controls.Add(this.label1);
            this.groupBox_Server.Controls.Add(this.textBox_IP_Address);
            this.groupBox_Server.Controls.Add(this.label_IP_Address);
            this.groupBox_Server.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Server.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Server.Name = "groupBox_Server";
            this.groupBox_Server.Size = new System.Drawing.Size(443, 87);
            this.groupBox_Server.TabIndex = 0;
            this.groupBox_Server.TabStop = false;
            this.groupBox_Server.Text = "Server";
            // 
            // button_Stop
            // 
            this.button_Stop.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stop.Location = new System.Drawing.Point(342, 53);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(95, 26);
            this.button_Stop.TabIndex = 5;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Listen
            // 
            this.button_Listen.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Listen.Location = new System.Drawing.Point(342, 22);
            this.button_Listen.Name = "button_Listen";
            this.button_Listen.Size = new System.Drawing.Size(95, 26);
            this.button_Listen.TabIndex = 4;
            this.button_Listen.Text = "Listen";
            this.button_Listen.UseVisualStyleBackColor = true;
            this.button_Listen.Click += new System.EventHandler(this.button_Listen_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Port.Location = new System.Drawing.Point(108, 53);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(227, 26);
            this.textBox_Port.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // textBox_IP_Address
            // 
            this.textBox_IP_Address.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_IP_Address.Location = new System.Drawing.Point(108, 22);
            this.textBox_IP_Address.Name = "textBox_IP_Address";
            this.textBox_IP_Address.Size = new System.Drawing.Size(227, 26);
            this.textBox_IP_Address.TabIndex = 1;
            // 
            // label_IP_Address
            // 
            this.label_IP_Address.AutoSize = true;
            this.label_IP_Address.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IP_Address.Location = new System.Drawing.Point(6, 25);
            this.label_IP_Address.Name = "label_IP_Address";
            this.label_IP_Address.Size = new System.Drawing.Size(73, 18);
            this.label_IP_Address.TabIndex = 0;
            this.label_IP_Address.Text = "IP Address";
            // 
            // groupBox_Clients
            // 
            this.groupBox_Clients.Controls.Add(this.listBox_Clients);
            this.groupBox_Clients.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Clients.Location = new System.Drawing.Point(12, 105);
            this.groupBox_Clients.Name = "groupBox_Clients";
            this.groupBox_Clients.Size = new System.Drawing.Size(443, 196);
            this.groupBox_Clients.TabIndex = 6;
            this.groupBox_Clients.TabStop = false;
            this.groupBox_Clients.Text = "Connected Client";
            // 
            // listBox_Clients
            // 
            this.listBox_Clients.FormattingEnabled = true;
            this.listBox_Clients.ItemHeight = 22;
            this.listBox_Clients.Location = new System.Drawing.Point(6, 28);
            this.listBox_Clients.Name = "listBox_Clients";
            this.listBox_Clients.Size = new System.Drawing.Size(431, 158);
            this.listBox_Clients.TabIndex = 0;
            // 
            // groupBox_Log
            // 
            this.groupBox_Log.Controls.Add(this.textBox_Logs);
            this.groupBox_Log.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox_Log.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Log.Location = new System.Drawing.Point(12, 307);
            this.groupBox_Log.Name = "groupBox_Log";
            this.groupBox_Log.Size = new System.Drawing.Size(443, 205);
            this.groupBox_Log.TabIndex = 7;
            this.groupBox_Log.TabStop = false;
            this.groupBox_Log.Text = "Logs";
            // 
            // textBox_Logs
            // 
            this.textBox_Logs.Location = new System.Drawing.Point(6, 28);
            this.textBox_Logs.Multiline = true;
            this.textBox_Logs.Name = "textBox_Logs";
            this.textBox_Logs.ReadOnly = true;
            this.textBox_Logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Logs.Size = new System.Drawing.Size(431, 171);
            this.textBox_Logs.TabIndex = 0;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 524);
            this.Controls.Add(this.groupBox_Log);
            this.Controls.Add(this.groupBox_Clients);
            this.Controls.Add(this.groupBox_Server);
            this.Name = "Server";
            this.Text = "Server";
            this.groupBox_Server.ResumeLayout(false);
            this.groupBox_Server.PerformLayout();
            this.groupBox_Clients.ResumeLayout(false);
            this.groupBox_Log.ResumeLayout(false);
            this.groupBox_Log.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Server;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_IP_Address;
        private System.Windows.Forms.Label label_IP_Address;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Listen;
        private System.Windows.Forms.GroupBox groupBox_Clients;
        private System.Windows.Forms.ListBox listBox_Clients;
        private System.Windows.Forms.GroupBox groupBox_Log;
        private System.Windows.Forms.TextBox textBox_Logs;
    }
}

