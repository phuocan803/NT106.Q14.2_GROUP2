namespace Lab05_Bai02_Bai03
{
    partial class ReadMail
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
            this.groupBox_Login = new System.Windows.Forms.GroupBox();
            this.button_Login_POP3 = new System.Windows.Forms.Button();
            this.button_Login_IMAP = new System.Windows.Forms.Button();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_Email = new System.Windows.Forms.Label();
            this.listView_Mails = new System.Windows.Forms.ListView();
            this.label_Total = new System.Windows.Forms.Label();
            this.label_Recent = new System.Windows.Forms.Label();
            this.groupBox_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Login
            // 
            this.groupBox_Login.Controls.Add(this.button_Login_POP3);
            this.groupBox_Login.Controls.Add(this.button_Login_IMAP);
            this.groupBox_Login.Controls.Add(this.textBox_Email);
            this.groupBox_Login.Controls.Add(this.textBox_Password);
            this.groupBox_Login.Controls.Add(this.label_Password);
            this.groupBox_Login.Controls.Add(this.label_Email);
            this.groupBox_Login.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Login.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Login.Name = "groupBox_Login";
            this.groupBox_Login.Size = new System.Drawing.Size(501, 90);
            this.groupBox_Login.TabIndex = 0;
            this.groupBox_Login.TabStop = false;
            this.groupBox_Login.Text = "Login";
            // 
            // button_Login_POP3
            // 
            this.button_Login_POP3.Location = new System.Drawing.Point(349, 55);
            this.button_Login_POP3.Name = "button_Login_POP3";
            this.button_Login_POP3.Size = new System.Drawing.Size(146, 26);
            this.button_Login_POP3.TabIndex = 5;
            this.button_Login_POP3.Text = "Đăng nhập (POP3)";
            this.button_Login_POP3.UseVisualStyleBackColor = true;
            this.button_Login_POP3.Click += new System.EventHandler(this.button_Login_POP3_Click);
            // 
            // button_Login_IMAP
            // 
            this.button_Login_IMAP.Location = new System.Drawing.Point(349, 25);
            this.button_Login_IMAP.Name = "button_Login_IMAP";
            this.button_Login_IMAP.Size = new System.Drawing.Size(146, 26);
            this.button_Login_IMAP.TabIndex = 4;
            this.button_Login_IMAP.Text = "Đăng nhập (IMAP)";
            this.button_Login_IMAP.UseVisualStyleBackColor = true;
            this.button_Login_IMAP.Click += new System.EventHandler(this.button_Login_IMAP_Click);
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(93, 24);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(250, 26);
            this.textBox_Email.TabIndex = 3;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(93, 56);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(250, 26);
            this.textBox_Password.TabIndex = 2;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(6, 59);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(71, 18);
            this.label_Password.TabIndex = 1;
            this.label_Password.Text = "Password:";
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(6, 27);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(49, 18);
            this.label_Email.TabIndex = 0;
            this.label_Email.Text = "Email: ";
            // 
            // listView_Mails
            // 
            this.listView_Mails.HideSelection = false;
            this.listView_Mails.Location = new System.Drawing.Point(12, 134);
            this.listView_Mails.Name = "listView_Mails";
            this.listView_Mails.Size = new System.Drawing.Size(501, 304);
            this.listView_Mails.TabIndex = 1;
            this.listView_Mails.UseCompatibleStateImageBehavior = false;
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Total.Location = new System.Drawing.Point(18, 109);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(75, 18);
            this.label_Total.TabIndex = 6;
            this.label_Total.Text = "Total Mail: ";
            // 
            // label_Recent
            // 
            this.label_Recent.AutoSize = true;
            this.label_Recent.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Recent.Location = new System.Drawing.Point(157, 109);
            this.label_Recent.Name = "label_Recent";
            this.label_Recent.Size = new System.Drawing.Size(85, 18);
            this.label_Recent.TabIndex = 7;
            this.label_Recent.Text = "Recent Mail:";
            // 
            // ReadMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 450);
            this.Controls.Add(this.label_Recent);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.listView_Mails);
            this.Controls.Add(this.groupBox_Login);
            this.Name = "ReadMail";
            this.Text = "ReadMail";
            this.Load += new System.EventHandler(this.ReadMail_Load);
            this.groupBox_Login.ResumeLayout(false);
            this.groupBox_Login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Login;
        private System.Windows.Forms.Button button_Login_IMAP;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Button button_Login_POP3;
        private System.Windows.Forms.ListView listView_Mails;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Label label_Recent;
    }
}

