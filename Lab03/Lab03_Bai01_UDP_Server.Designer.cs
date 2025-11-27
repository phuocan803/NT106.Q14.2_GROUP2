namespace Lab03
{
    partial class Lab03_Bai01_UDP_Server
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
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.lblReceivedMessages = new System.Windows.Forms.Label();
            this.txtReceivedMessages = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(26, 37);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(60, 34);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(115, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8080";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(410, 30);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(85, 28);
            this.btnListen.TabIndex = 2;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // lblReceivedMessages
            // 
            this.lblReceivedMessages.AutoSize = true;
            this.lblReceivedMessages.Location = new System.Drawing.Point(26, 75);
            this.lblReceivedMessages.Name = "lblReceivedMessages";
            this.lblReceivedMessages.Size = new System.Drawing.Size(103, 13);
            this.lblReceivedMessages.TabIndex = 3;
            this.lblReceivedMessages.Text = "Received messages";
            // 
            // txtReceivedMessages
            // 
            this.txtReceivedMessages.Location = new System.Drawing.Point(29, 102);
            this.txtReceivedMessages.Multiline = true;
            this.txtReceivedMessages.Name = "txtReceivedMessages";
            this.txtReceivedMessages.ReadOnly = true;
            this.txtReceivedMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceivedMessages.Size = new System.Drawing.Size(469, 230);
            this.txtReceivedMessages.TabIndex = 4;
            // 
            // Lab03_Bai01_UDP_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 356);
            this.Controls.Add(this.txtReceivedMessages);
            this.Controls.Add(this.lblReceivedMessages);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Name = "Lab03_Bai01_UDP_Server";
            this.Text = "UDP Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label lblReceivedMessages;
        private System.Windows.Forms.TextBox txtReceivedMessages;
    }
}
