namespace Lab03
{
    partial class Lab03_Bai01_UDP_Client
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
            this.lblIPRemoteHost = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIPRemoteHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIPRemoteHost
            // 
            this.lblIPRemoteHost.AutoSize = true;
            this.lblIPRemoteHost.Location = new System.Drawing.Point(36, 46);
            this.lblIPRemoteHost.Name = "lblIPRemoteHost";
            this.lblIPRemoteHost.Size = new System.Drawing.Size(80, 13);
            this.lblIPRemoteHost.TabIndex = 0;
            this.lblIPRemoteHost.Text = "IP Remote host";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(363, 46);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port";
            // 
            // txtIPRemoteHost
            // 
            this.txtIPRemoteHost.Location = new System.Drawing.Point(36, 62);
            this.txtIPRemoteHost.Name = "txtIPRemoteHost";
            this.txtIPRemoteHost.Size = new System.Drawing.Size(300, 20);
            this.txtIPRemoteHost.TabIndex = 2;
            this.txtIPRemoteHost.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(363, 62);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(130, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8080";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(36, 109);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(36, 125);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(457, 90);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.Text = "Đây là Bài 01 - Lab 3 - Lập trình mạng căn bản";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(36, 227);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 30);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Lab03_Bai01_UDP_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 288);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIPRemoteHost);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIPRemoteHost);
            this.Name = "Lab03_Bai01_UDP_Client";
            this.Text = "UDP Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIPRemoteHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIPRemoteHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
    }
}