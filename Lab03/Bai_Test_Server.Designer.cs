namespace Lab03
{
    partial class Bai_Test_Server
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
            this.grpServerInfo = new System.Windows.Forms.GroupBox();
            this.txtPublicIP = new System.Windows.Forms.TextBox();
            this.lblPublicIP = new System.Windows.Forms.Label();
            this.txtPrivateIP = new System.Windows.Forms.TextBox();
            this.lblPrivateIP = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.grpServerInfo.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServerInfo
            // 
            this.grpServerInfo.Controls.Add(this.txtPublicIP);
            this.grpServerInfo.Controls.Add(this.lblPublicIP);
            this.grpServerInfo.Controls.Add(this.txtPrivateIP);
            this.grpServerInfo.Controls.Add(this.lblPrivateIP);
            this.grpServerInfo.Controls.Add(this.txtPort);
            this.grpServerInfo.Controls.Add(this.lblPort);
            this.grpServerInfo.Controls.Add(this.btnStart);
            this.grpServerInfo.Controls.Add(this.btnStop);
            this.grpServerInfo.Location = new System.Drawing.Point(12, 12);
            this.grpServerInfo.Name = "grpServerInfo";
            this.grpServerInfo.Size = new System.Drawing.Size(660, 130);
            this.grpServerInfo.TabIndex = 0;
            this.grpServerInfo.TabStop = false;
            this.grpServerInfo.Text = "Thông tin Server - GCP VM";
            // 
            // txtPublicIP
            // 
            this.txtPublicIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtPublicIP.Location = new System.Drawing.Point(110, 52);
            this.txtPublicIP.Name = "txtPublicIP";
            this.txtPublicIP.ReadOnly = true;
            this.txtPublicIP.Size = new System.Drawing.Size(200, 20);
            this.txtPublicIP.TabIndex = 7;
            this.txtPublicIP.Text = "34.60.110.222";
            // 
            // lblPublicIP
            // 
            this.lblPublicIP.AutoSize = true;
            this.lblPublicIP.Location = new System.Drawing.Point(15, 55);
            this.lblPublicIP.Name = "lblPublicIP";
            this.lblPublicIP.Size = new System.Drawing.Size(89, 13);
            this.lblPublicIP.TabIndex = 6;
            this.lblPublicIP.Text = "Public IP (GCP):";
            // 
            // txtPrivateIP
            // 
            this.txtPrivateIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrivateIP.Location = new System.Drawing.Point(110, 25);
            this.txtPrivateIP.Name = "txtPrivateIP";
            this.txtPrivateIP.ReadOnly = true;
            this.txtPrivateIP.Size = new System.Drawing.Size(200, 20);
            this.txtPrivateIP.TabIndex = 0;
            // 
            // lblPrivateIP
            // 
            this.lblPrivateIP.AutoSize = true;
            this.lblPrivateIP.Location = new System.Drawing.Point(15, 28);
            this.lblPrivateIP.Name = "lblPrivateIP";
            this.lblPrivateIP.Size = new System.Drawing.Size(89, 13);
            this.lblPrivateIP.TabIndex = 1;
            this.lblPrivateIP.Text = "Private IP (VM):";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(110, 79);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8080";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(15, 82);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(340, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 35);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Kh?i ??ng Server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(340, 75);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 35);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "D?ng Server";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Controls.Add(this.btnClearLog);
            this.grpLog.Location = new System.Drawing.Point(12, 188);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(660, 320);
            this.grpLog.TabIndex = 1;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Nh?t ký Server";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(18, 25);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(623, 249);
            this.txtLog.TabIndex = 0;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(506, 280);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(135, 25);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Xóa nh?t ký";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Blue;
            this.lblNote.Location = new System.Drawing.Point(15, 155);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(626, 26);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "L?u ý: Server l?ng nghe trên 0.0.0.0 (t?t c? interfaces). Client t? Internet dùng Public IP, client trong VPC dùng Private IP.\r\n??m b?o Firewall Rules trên GCP ?ã m? port cho traffic ??n.";
            // 
            // Bai_Test_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 520);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.grpServerInfo);
            this.Name = "Bai_Test_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài Test - TCP Server (GCP VM)";
            this.grpServerInfo.ResumeLayout(false);
            this.grpServerInfo.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpServerInfo;
        private System.Windows.Forms.TextBox txtPrivateIP;
        private System.Windows.Forms.Label lblPrivateIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.TextBox txtPublicIP;
        private System.Windows.Forms.Label lblPublicIP;
        private System.Windows.Forms.Label lblNote;
    }
}
