namespace Lab05_Bai06
{
    partial class Sent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sent));
            this.groupMail = new System.Windows.Forms.GroupBox();
            this.Check_HTML = new System.Windows.Forms.CheckBox();
            this.labelAttach = new System.Windows.Forms.Label();
            this.TextBox_Attach = new System.Windows.Forms.TextBox();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.labelTo = new System.Windows.Forms.Label();
            this.User_To = new System.Windows.Forms.TextBox();
            this.labelCC = new System.Windows.Forms.Label();
            this.User_CC = new System.Windows.Forms.TextBox();
            this.labelBCC = new System.Windows.Forms.Label();
            this.User_BCC = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.TextBox_Subject = new System.Windows.Forms.TextBox();
            this.labelBody = new System.Windows.Forms.Label();
            this.TextBox_Content = new System.Windows.Forms.TextBox();
            this.Button_Send = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupMail
            // 
            this.groupMail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupMail.Controls.Add(this.Check_HTML);
            this.groupMail.Controls.Add(this.labelAttach);
            this.groupMail.Controls.Add(this.TextBox_Attach);
            this.groupMail.Controls.Add(this.Button_Browse);
            this.groupMail.Controls.Add(this.labelTo);
            this.groupMail.Controls.Add(this.User_To);
            this.groupMail.Controls.Add(this.labelCC);
            this.groupMail.Controls.Add(this.User_CC);
            this.groupMail.Controls.Add(this.labelBCC);
            this.groupMail.Controls.Add(this.User_BCC);
            this.groupMail.Controls.Add(this.labelSubject);
            this.groupMail.Controls.Add(this.TextBox_Subject);
            this.groupMail.Controls.Add(this.labelBody);
            this.groupMail.Controls.Add(this.TextBox_Content);
            this.groupMail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupMail.ForeColor = System.Drawing.Color.Navy;
            this.groupMail.Location = new System.Drawing.Point(30, 28);
            this.groupMail.Name = "groupMail";
            this.groupMail.Size = new System.Drawing.Size(937, 543);
            this.groupMail.TabIndex = 1;
            this.groupMail.TabStop = false;
            this.groupMail.Text = "EMAIL CONTENT";
            // 
            // Check_HTML
            // 
            this.Check_HTML.AutoSize = true;
            this.Check_HTML.Location = new System.Drawing.Point(24, 510);
            this.Check_HTML.Name = "Check_HTML";
            this.Check_HTML.Size = new System.Drawing.Size(80, 27);
            this.Check_HTML.TabIndex = 0;
            this.Check_HTML.Text = "HTML";
            // 
            // labelAttach
            // 
            this.labelAttach.AutoSize = true;
            this.labelAttach.Location = new System.Drawing.Point(20, 468);
            this.labelAttach.Name = "labelAttach";
            this.labelAttach.Size = new System.Drawing.Size(110, 23);
            this.labelAttach.TabIndex = 1;
            this.labelAttach.Text = "Attachment:";
            // 
            // TextBox_Attach
            // 
            this.TextBox_Attach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBox_Attach.Location = new System.Drawing.Point(150, 468);
            this.TextBox_Attach.Name = "TextBox_Attach";
            this.TextBox_Attach.ReadOnly = true;
            this.TextBox_Attach.Size = new System.Drawing.Size(620, 27);
            this.TextBox_Attach.TabIndex = 2;
            // 
            // Button_Browse
            // 
            this.Button_Browse.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Button_Browse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Button_Browse.ForeColor = System.Drawing.Color.Navy;
            this.Button_Browse.Location = new System.Drawing.Point(790, 465);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(122, 30);
            this.Button_Browse.TabIndex = 3;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.UseVisualStyleBackColor = false;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(20, 40);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(33, 23);
            this.labelTo.TabIndex = 4;
            this.labelTo.Text = "To:";
            // 
            // User_To
            // 
            this.User_To.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.User_To.Location = new System.Drawing.Point(150, 37);
            this.User_To.Name = "User_To";
            this.User_To.Size = new System.Drawing.Size(762, 30);
            this.User_To.TabIndex = 5;
            // 
            // labelCC
            // 
            this.labelCC.AutoSize = true;
            this.labelCC.Location = new System.Drawing.Point(20, 90);
            this.labelCC.Name = "labelCC";
            this.labelCC.Size = new System.Drawing.Size(36, 23);
            this.labelCC.TabIndex = 6;
            this.labelCC.Text = "CC:";
            // 
            // User_CC
            // 
            this.User_CC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.User_CC.Location = new System.Drawing.Point(150, 87);
            this.User_CC.Name = "User_CC";
            this.User_CC.Size = new System.Drawing.Size(762, 30);
            this.User_CC.TabIndex = 7;
            // 
            // labelBCC
            // 
            this.labelBCC.AutoSize = true;
            this.labelBCC.Location = new System.Drawing.Point(20, 140);
            this.labelBCC.Name = "labelBCC";
            this.labelBCC.Size = new System.Drawing.Size(47, 23);
            this.labelBCC.TabIndex = 8;
            this.labelBCC.Text = "BCC:";
            // 
            // User_BCC
            // 
            this.User_BCC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.User_BCC.Location = new System.Drawing.Point(150, 137);
            this.User_BCC.Name = "User_BCC";
            this.User_BCC.Size = new System.Drawing.Size(762, 30);
            this.User_BCC.TabIndex = 9;
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(20, 190);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(75, 23);
            this.labelSubject.TabIndex = 10;
            this.labelSubject.Text = "Subject:";
            // 
            // TextBox_Subject
            // 
            this.TextBox_Subject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_Subject.Location = new System.Drawing.Point(150, 187);
            this.TextBox_Subject.Name = "TextBox_Subject";
            this.TextBox_Subject.Size = new System.Drawing.Size(762, 30);
            this.TextBox_Subject.TabIndex = 11;
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(20, 240);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(56, 23);
            this.labelBody.TabIndex = 12;
            this.labelBody.Text = "Body:";
            // 
            // TextBox_Content
            // 
            this.TextBox_Content.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.TextBox_Content.Location = new System.Drawing.Point(24, 266);
            this.TextBox_Content.Multiline = true;
            this.TextBox_Content.Name = "TextBox_Content";
            this.TextBox_Content.Size = new System.Drawing.Size(888, 173);
            this.TextBox_Content.TabIndex = 13;
            // 
            // Button_Send
            // 
            this.Button_Send.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_Send.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Button_Send.ForeColor = System.Drawing.Color.Navy;
            this.Button_Send.Location = new System.Drawing.Point(767, 595);
            this.Button_Send.Name = "Button_Send";
            this.Button_Send.Size = new System.Drawing.Size(200, 40);
            this.Button_Send.TabIndex = 0;
            this.Button_Send.Text = "Send Email";
            this.Button_Send.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-250, -29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1258, 679);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // Sent
            // 
            this.ClientSize = new System.Drawing.Size(1002, 647);
            this.Controls.Add(this.Button_Send);
            this.Controls.Add(this.groupMail);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Sent";
            this.Text = "Lab05 - Send Email";
            this.groupMail.ResumeLayout(false);
            this.groupMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupMail;
        private System.Windows.Forms.Label labelTo, labelCC, labelBCC, labelSubject, labelBody, labelAttach;
        private System.Windows.Forms.TextBox User_To, User_CC, User_BCC;
        private System.Windows.Forms.TextBox TextBox_Subject, TextBox_Content, TextBox_Attach;
        private System.Windows.Forms.Button Button_Browse, Button_Send;
        private System.Windows.Forms.CheckBox Check_HTML;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
