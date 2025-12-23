namespace Lab05_Bai02
{
    partial class Mail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.Panel_Left = new System.Windows.Forms.Panel();
            this.groupBox_Settings = new System.Windows.Forms.GroupBox();
            this.labelSSL = new System.Windows.Forms.Label();
            this.labelSMTPPort = new System.Windows.Forms.Label();
            this.labelSMTP = new System.Windows.Forms.Label();
            this.labelIMAPPort = new System.Windows.Forms.Label();
            this.labelIMAP = new System.Windows.Forms.Label();
            this.Button_Stop = new System.Windows.Forms.Button();
            this.Button_Compose = new System.Windows.Forms.Button();
            this.TextBox_Search = new System.Windows.Forms.TextBox();
            this.Button_Search = new System.Windows.Forms.Button();
            this.Panel_MailList = new System.Windows.Forms.Panel();
            this.ListView_Mails = new System.Windows.Forms.ListView();
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label_Total = new System.Windows.Forms.Label();
            this.Panel_MailContent = new System.Windows.Forms.Panel();
            this.Button_ReplyAll = new System.Windows.Forms.Button();
            this.Button_Reply = new System.Windows.Forms.Button();
            this.ViewMail = new System.Windows.Forms.WebBrowser();
            this.Label_Date = new System.Windows.Forms.Label();
            this.Label_From = new System.Windows.Forms.Label();
            this.Label_Subject = new System.Windows.Forms.Label();
            this.Button_Down = new System.Windows.Forms.Button();
            this.Panel_Left.SuspendLayout();
            this.groupBox_Settings.SuspendLayout();
            this.Panel_MailList.SuspendLayout();
            this.Panel_MailContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Left
            // 
            this.Panel_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.Panel_Left.Controls.Add(this.groupBox_Settings);
            this.Panel_Left.Controls.Add(this.Button_Stop);
            this.Panel_Left.Controls.Add(this.Button_Compose);
            this.Panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_Left.Location = new System.Drawing.Point(0, 0);
            this.Panel_Left.Name = "Panel_Left";
            this.Panel_Left.Size = new System.Drawing.Size(220, 750);
            this.Panel_Left.TabIndex = 5;
            // 
            // groupBox_Settings
            // 
            this.groupBox_Settings.Controls.Add(this.labelSSL);
            this.groupBox_Settings.Controls.Add(this.labelSMTPPort);
            this.groupBox_Settings.Controls.Add(this.labelSMTP);
            this.groupBox_Settings.Controls.Add(this.labelIMAPPort);
            this.groupBox_Settings.Controls.Add(this.labelIMAP);
            this.groupBox_Settings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox_Settings.ForeColor = System.Drawing.Color.Navy;
            this.groupBox_Settings.Location = new System.Drawing.Point(10, 140);
            this.groupBox_Settings.Name = "groupBox_Settings";
            this.groupBox_Settings.Size = new System.Drawing.Size(200, 200);
            this.groupBox_Settings.TabIndex = 0;
            this.groupBox_Settings.TabStop = false;
            this.groupBox_Settings.Text = "Cài đặt";
            // 
            // labelSSL
            // 
            this.labelSSL.Location = new System.Drawing.Point(10, 140);
            this.labelSSL.Name = "labelSSL";
            this.labelSSL.Size = new System.Drawing.Size(100, 23);
            this.labelSSL.TabIndex = 0;
            this.labelSSL.Text = "SSL : Enabled";
            // 
            // labelSMTPPort
            // 
            this.labelSMTPPort.Location = new System.Drawing.Point(10, 110);
            this.labelSMTPPort.Name = "labelSMTPPort";
            this.labelSMTPPort.Size = new System.Drawing.Size(100, 23);
            this.labelSMTPPort.TabIndex = 1;
            this.labelSMTPPort.Text = "Port : 465";
            // 
            // labelSMTP
            // 
            this.labelSMTP.Location = new System.Drawing.Point(10, 85);
            this.labelSMTP.Name = "labelSMTP";
            this.labelSMTP.Size = new System.Drawing.Size(100, 23);
            this.labelSMTP.TabIndex = 2;
            this.labelSMTP.Text = "SMTP : smtp.gmail.com";
            // 
            // labelIMAPPort
            // 
            this.labelIMAPPort.Location = new System.Drawing.Point(10, 55);
            this.labelIMAPPort.Name = "labelIMAPPort";
            this.labelIMAPPort.Size = new System.Drawing.Size(100, 23);
            this.labelIMAPPort.TabIndex = 3;
            this.labelIMAPPort.Text = "Port : 993";
            // 
            // labelIMAP
            // 
            this.labelIMAP.Location = new System.Drawing.Point(10, 30);
            this.labelIMAP.Name = "labelIMAP";
            this.labelIMAP.Size = new System.Drawing.Size(100, 23);
            this.labelIMAP.TabIndex = 4;
            this.labelIMAP.Text = "IMAP : imap.gmail.com";
            // 
            // Button_Stop
            // 
            this.Button_Stop.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Button_Stop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Button_Stop.ForeColor = System.Drawing.Color.Navy;
            this.Button_Stop.Location = new System.Drawing.Point(20, 75);
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Size = new System.Drawing.Size(180, 35);
            this.Button_Stop.TabIndex = 1;
            this.Button_Stop.Text = "Stop";
            this.Button_Stop.UseVisualStyleBackColor = false;
            // 
            // Button_Compose
            // 
            this.Button_Compose.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_Compose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Button_Compose.ForeColor = System.Drawing.Color.Navy;
            this.Button_Compose.Location = new System.Drawing.Point(20, 20);
            this.Button_Compose.Name = "Button_Compose";
            this.Button_Compose.Size = new System.Drawing.Size(180, 40);
            this.Button_Compose.TabIndex = 2;
            this.Button_Compose.Text = "Compose";
            this.Button_Compose.UseVisualStyleBackColor = false;
            // 
            // TextBox_Search
            // 
            this.TextBox_Search.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_Search.Location = new System.Drawing.Point(250, 20);
            this.TextBox_Search.Name = "TextBox_Search";
            this.TextBox_Search.Size = new System.Drawing.Size(500, 30);
            this.TextBox_Search.TabIndex = 4;
            // 
            // Button_Search
            // 
            this.Button_Search.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_Search.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Button_Search.ForeColor = System.Drawing.Color.White;
            this.Button_Search.Location = new System.Drawing.Point(760, 20);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(100, 30);
            this.Button_Search.TabIndex = 3;
            this.Button_Search.Text = "Search";
            this.Button_Search.UseVisualStyleBackColor = false;
            // 
            // Panel_MailList
            // 
            this.Panel_MailList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel_MailList.Controls.Add(this.ListView_Mails);
            this.Panel_MailList.Location = new System.Drawing.Point(250, 70);
            this.Panel_MailList.Name = "Panel_MailList";
            this.Panel_MailList.Size = new System.Drawing.Size(400, 660);
            this.Panel_MailList.TabIndex = 1;
            // 
            // ListView_Mails
            // 
            this.ListView_Mails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFrom,
            this.colSubject,
            this.colDate});
            this.ListView_Mails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_Mails.FullRowSelect = true;
            this.ListView_Mails.HideSelection = false;
            this.ListView_Mails.Location = new System.Drawing.Point(0, 0);
            this.ListView_Mails.Name = "ListView_Mails";
            this.ListView_Mails.Size = new System.Drawing.Size(400, 660);
            this.ListView_Mails.TabIndex = 0;
            this.ListView_Mails.UseCompatibleStateImageBehavior = false;
            this.ListView_Mails.View = System.Windows.Forms.View.Details;
            // 
            // colFrom
            // 
            this.colFrom.Text = "From";
            this.colFrom.Width = 120;
            // 
            // colSubject
            // 
            this.colSubject.Text = "Subject";
            this.colSubject.Width = 180;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // Label_Total
            // 
            this.Label_Total.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Label_Total.ForeColor = System.Drawing.Color.Navy;
            this.Label_Total.Location = new System.Drawing.Point(880, 25);
            this.Label_Total.Name = "Label_Total";
            this.Label_Total.Size = new System.Drawing.Size(300, 25);
            this.Label_Total.TabIndex = 2;
            this.Label_Total.Text = "Total: 0 emails";
            // 
            // Panel_MailContent
            // 
            this.Panel_MailContent.BackColor = System.Drawing.Color.White;
            this.Panel_MailContent.Controls.Add(this.Button_Down);
            this.Panel_MailContent.Controls.Add(this.Button_ReplyAll);
            this.Panel_MailContent.Controls.Add(this.Button_Reply);
            this.Panel_MailContent.Controls.Add(this.ViewMail);
            this.Panel_MailContent.Controls.Add(this.Label_Date);
            this.Panel_MailContent.Controls.Add(this.Label_From);
            this.Panel_MailContent.Controls.Add(this.Label_Subject);
            this.Panel_MailContent.Location = new System.Drawing.Point(660, 70);
            this.Panel_MailContent.Name = "Panel_MailContent";
            this.Panel_MailContent.Size = new System.Drawing.Size(680, 660);
            this.Panel_MailContent.TabIndex = 0;
            // 
            // Button_ReplyAll
            // 
            this.Button_ReplyAll.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_ReplyAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Button_ReplyAll.ForeColor = System.Drawing.Color.White;
            this.Button_ReplyAll.Location = new System.Drawing.Point(556, 612);
            this.Button_ReplyAll.Name = "Button_ReplyAll";
            this.Button_ReplyAll.Size = new System.Drawing.Size(110, 35);
            this.Button_ReplyAll.TabIndex = 0;
            this.Button_ReplyAll.Text = "Reply All";
            this.Button_ReplyAll.UseVisualStyleBackColor = false;
            // 
            // Button_Reply
            // 
            this.Button_Reply.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Button_Reply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Button_Reply.ForeColor = System.Drawing.Color.Navy;
            this.Button_Reply.Location = new System.Drawing.Point(430, 612);
            this.Button_Reply.Name = "Button_Reply";
            this.Button_Reply.Size = new System.Drawing.Size(110, 35);
            this.Button_Reply.TabIndex = 1;
            this.Button_Reply.Text = "Reply";
            this.Button_Reply.UseVisualStyleBackColor = false;
            // 
            // ViewMail
            // 
            this.ViewMail.Location = new System.Drawing.Point(10, 110);
            this.ViewMail.Name = "ViewMail";
            this.ViewMail.Size = new System.Drawing.Size(656, 486);
            this.ViewMail.TabIndex = 2;
            // 
            // Label_Date
            // 
            this.Label_Date.Location = new System.Drawing.Point(10, 75);
            this.Label_Date.Name = "Label_Date";
            this.Label_Date.Size = new System.Drawing.Size(656, 25);
            this.Label_Date.TabIndex = 3;
            // 
            // Label_From
            // 
            this.Label_From.Location = new System.Drawing.Point(10, 50);
            this.Label_From.Name = "Label_From";
            this.Label_From.Size = new System.Drawing.Size(656, 25);
            this.Label_From.TabIndex = 4;
            // 
            // Label_Subject
            // 
            this.Label_Subject.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.Label_Subject.Location = new System.Drawing.Point(10, 10);
            this.Label_Subject.Name = "Label_Subject";
            this.Label_Subject.Size = new System.Drawing.Size(656, 40);
            this.Label_Subject.TabIndex = 5;
            // 
            // Button_Down
            // 
            this.Button_Down.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Button_Down.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Button_Down.ForeColor = System.Drawing.Color.Navy;
            this.Button_Down.Location = new System.Drawing.Point(300, 612);
            this.Button_Down.Name = "Button_Down";
            this.Button_Down.Size = new System.Drawing.Size(110, 35);
            this.Button_Down.TabIndex = 6;
            this.Button_Down.Text = "Attachment";
            this.Button_Down.UseVisualStyleBackColor = false;
            // 
            // Mail
            // 
            this.ClientSize = new System.Drawing.Size(1374, 750);
            this.Controls.Add(this.Panel_MailContent);
            this.Controls.Add(this.Panel_MailList);
            this.Controls.Add(this.Label_Total);
            this.Controls.Add(this.Button_Search);
            this.Controls.Add(this.TextBox_Search);
            this.Controls.Add(this.Panel_Left);
            this.Name = "Mail";
            this.Text = "Lab05 - Email Client";
            this.Panel_Left.ResumeLayout(false);
            this.groupBox_Settings.ResumeLayout(false);
            this.Panel_MailList.ResumeLayout(false);
            this.Panel_MailContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Left;
        private System.Windows.Forms.Button Button_Compose;
        private System.Windows.Forms.Button Button_Stop;

        private System.Windows.Forms.GroupBox groupBox_Settings;
        private System.Windows.Forms.Label labelIMAP;
        private System.Windows.Forms.Label labelIMAPPort;
        private System.Windows.Forms.Label labelSMTP;
        private System.Windows.Forms.Label labelSMTPPort;
        private System.Windows.Forms.Label labelSSL;

        private System.Windows.Forms.TextBox TextBox_Search;
        private System.Windows.Forms.Button Button_Search;

        private System.Windows.Forms.Panel Panel_MailList;
        private System.Windows.Forms.ListView ListView_Mails;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colSubject;
        private System.Windows.Forms.ColumnHeader colDate;

        private System.Windows.Forms.Label Label_Total;

        private System.Windows.Forms.Panel Panel_MailContent;
        private System.Windows.Forms.Label Label_Subject;
        private System.Windows.Forms.Label Label_From;
        private System.Windows.Forms.Label Label_Date;
        private System.Windows.Forms.WebBrowser ViewMail;

        private System.Windows.Forms.Button Button_Reply;
        private System.Windows.Forms.Button Button_ReplyAll;
        private System.Windows.Forms.Button Button_Down;
    }
}
