namespace Lab03
{
    partial class Bai_Test_DashBoard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.lblServerInfo = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblPrivateIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblPublicIP = new System.Windows.Forms.Label();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(85, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bài Test - TCP Client/Server";
            // 
            // btnClient
            // 
            this.btnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClient.Location = new System.Drawing.Point(50, 250);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(180, 60);
            this.btnClient.TabIndex = 1;
            this.btnClient.Text = "M? TCP Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnServer
            // 
            this.btnServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServer.Location = new System.Drawing.Point(270, 250);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(180, 60);
            this.btnServer.TabIndex = 2;
            this.btnServer.Text = "M? TCP Server\r\n(Ch?y trên GCP VM)";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // lblServerInfo
            // 
            this.lblServerInfo.AutoSize = true;
            this.lblServerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerInfo.Location = new System.Drawing.Point(15, 25);
            this.lblServerInfo.Name = "lblServerInfo";
            this.lblServerInfo.Size = new System.Drawing.Size(202, 17);
            this.lblServerInfo.TabIndex = 3;
            this.lblServerInfo.Text = "Thông tin GCP VM Server";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblNote);
            this.grpInfo.Controls.Add(this.lblPrivateIP);
            this.grpInfo.Controls.Add(this.lblPort);
            this.grpInfo.Controls.Add(this.lblPublicIP);
            this.grpInfo.Controls.Add(this.lblServerInfo);
            this.grpInfo.Location = new System.Drawing.Point(50, 70);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(400, 160);
            this.grpInfo.TabIndex = 4;
            this.grpInfo.TabStop = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(15, 110);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(364, 39);
            this.lblNote.TabIndex = 7;
            this.lblNote.Text = "L?u ý:\r\n- Server l?ng nghe trên 0.0.0.0 (t?t c? interfaces)\r\n- Client t? Internet dùng Public IP, client trong VPC dùng Private IP";
            // 
            // lblPrivateIP
            // 
            this.lblPrivateIP.AutoSize = true;
            this.lblPrivateIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateIP.Location = new System.Drawing.Point(15, 65);
            this.lblPrivateIP.Name = "lblPrivateIP";
            this.lblPrivateIP.Size = new System.Drawing.Size(188, 15);
            this.lblPrivateIP.TabIndex = 6;
            this.lblPrivateIP.Text = "Private IP (VM): 10.128.0.2";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(15, 85);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(74, 15);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port: 8080";
            // 
            // lblPublicIP
            // 
            this.lblPublicIP.AutoSize = true;
            this.lblPublicIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublicIP.Location = new System.Drawing.Point(15, 45);
            this.lblPublicIP.Name = "lblPublicIP";
            this.lblPublicIP.Size = new System.Drawing.Size(216, 15);
            this.lblPublicIP.TabIndex = 4;
            this.lblPublicIP.Text = "Public IP (External): 34.60.110.222";
            // 
            // Bai_Test_DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 340);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.btnServer);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai_Test_DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài Test - Dashboard (GCP VM)";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Label lblServerInfo;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblPublicIP;
        private System.Windows.Forms.Label lblPrivateIP;
        private System.Windows.Forms.Label lblNote;
    }
}
