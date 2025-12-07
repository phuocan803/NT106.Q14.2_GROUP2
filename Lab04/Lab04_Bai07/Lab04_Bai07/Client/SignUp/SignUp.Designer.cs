namespace Lab04_Bai07.SignUp
{
    partial class SignUp
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
            this.label_Title = new System.Windows.Forms.Label();
            this.groupBox_Sign_Up = new System.Windows.Forms.GroupBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.groupBox_UserInformation = new System.Windows.Forms.GroupBox();
            this.label_Gender = new System.Windows.Forms.Label();
            this.panel_Gender = new System.Windows.Forms.Panel();
            this.radioButton_Female = new System.Windows.Forms.RadioButton();
            this.radioButton_Male = new System.Windows.Forms.RadioButton();
            this.comboBox_Language = new System.Windows.Forms.ComboBox();
            this.label_Language = new System.Windows.Forms.Label();
            this.dateTimePicker_Birthday = new System.Windows.Forms.DateTimePicker();
            this.label_Birthday = new System.Windows.Forms.Label();
            this.label_Phone_Number = new System.Windows.Forms.Label();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_FullName = new System.Windows.Forms.TextBox();
            this.label_Fullname = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.button_Sign_Up = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel_Sign_In = new System.Windows.Forms.LinkLabel();
            this.groupBox_Sign_Up.SuspendLayout();
            this.groupBox_UserInformation.SuspendLayout();
            this.panel_Gender.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Calibri", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_Title.Location = new System.Drawing.Point(118, 18);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(192, 35);
            this.label_Title.TabIndex = 0;
            this.label_Title.Text = "Hôm nay ăn gì?";
            // 
            // groupBox_Sign_Up
            // 
            this.groupBox_Sign_Up.Controls.Add(this.textBox_Password);
            this.groupBox_Sign_Up.Controls.Add(this.textBox_Username);
            this.groupBox_Sign_Up.Controls.Add(this.label_Username);
            this.groupBox_Sign_Up.Controls.Add(this.label_Password);
            this.groupBox_Sign_Up.Font = new System.Drawing.Font("Calibri", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Sign_Up.Location = new System.Drawing.Point(12, 59);
            this.groupBox_Sign_Up.Name = "groupBox_Sign_Up";
            this.groupBox_Sign_Up.Size = new System.Drawing.Size(431, 123);
            this.groupBox_Sign_Up.TabIndex = 1;
            this.groupBox_Sign_Up.TabStop = false;
            this.groupBox_Sign_Up.Text = "Đăng ký";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(142, 80);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(276, 26);
            this.textBox_Password.TabIndex = 5;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(142, 35);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(276, 26);
            this.textBox_Username.TabIndex = 4;
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(19, 38);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(90, 18);
            this.label_Username.TabIndex = 3;
            this.label_Username.Text = "Tên tài khoản";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(19, 83);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(65, 18);
            this.label_Password.TabIndex = 2;
            this.label_Password.Text = "Mật khẩu";
            // 
            // groupBox_UserInformation
            // 
            this.groupBox_UserInformation.Controls.Add(this.label_Gender);
            this.groupBox_UserInformation.Controls.Add(this.panel_Gender);
            this.groupBox_UserInformation.Controls.Add(this.comboBox_Language);
            this.groupBox_UserInformation.Controls.Add(this.label_Language);
            this.groupBox_UserInformation.Controls.Add(this.dateTimePicker_Birthday);
            this.groupBox_UserInformation.Controls.Add(this.label_Birthday);
            this.groupBox_UserInformation.Controls.Add(this.label_Phone_Number);
            this.groupBox_UserInformation.Controls.Add(this.textBox_Phone);
            this.groupBox_UserInformation.Controls.Add(this.textBox_FullName);
            this.groupBox_UserInformation.Controls.Add(this.label_Fullname);
            this.groupBox_UserInformation.Controls.Add(this.textBox_Email);
            this.groupBox_UserInformation.Controls.Add(this.label_Email);
            this.groupBox_UserInformation.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_UserInformation.Location = new System.Drawing.Point(12, 188);
            this.groupBox_UserInformation.Name = "groupBox_UserInformation";
            this.groupBox_UserInformation.Size = new System.Drawing.Size(431, 326);
            this.groupBox_UserInformation.TabIndex = 2;
            this.groupBox_UserInformation.TabStop = false;
            this.groupBox_UserInformation.Text = "Thông tin người dùng";
            // 
            // label_Gender
            // 
            this.label_Gender.AutoSize = true;
            this.label_Gender.Location = new System.Drawing.Point(19, 289);
            this.label_Gender.Name = "label_Gender";
            this.label_Gender.Size = new System.Drawing.Size(65, 19);
            this.label_Gender.TabIndex = 17;
            this.label_Gender.Text = "Giới tính";
            // 
            // panel_Gender
            // 
            this.panel_Gender.Controls.Add(this.radioButton_Female);
            this.panel_Gender.Controls.Add(this.radioButton_Male);
            this.panel_Gender.Location = new System.Drawing.Point(136, 284);
            this.panel_Gender.Name = "panel_Gender";
            this.panel_Gender.Size = new System.Drawing.Size(282, 29);
            this.panel_Gender.TabIndex = 16;
            // 
            // radioButton_Female
            // 
            this.radioButton_Female.AutoSize = true;
            this.radioButton_Female.Location = new System.Drawing.Point(158, 3);
            this.radioButton_Female.Name = "radioButton_Female";
            this.radioButton_Female.Size = new System.Drawing.Size(47, 23);
            this.radioButton_Female.TabIndex = 16;
            this.radioButton_Female.TabStop = true;
            this.radioButton_Female.Text = "Nữ";
            this.radioButton_Female.UseVisualStyleBackColor = true;
            // 
            // radioButton_Male
            // 
            this.radioButton_Male.AutoSize = true;
            this.radioButton_Male.Location = new System.Drawing.Point(6, 3);
            this.radioButton_Male.Name = "radioButton_Male";
            this.radioButton_Male.Size = new System.Drawing.Size(57, 23);
            this.radioButton_Male.TabIndex = 15;
            this.radioButton_Male.TabStop = true;
            this.radioButton_Male.Text = "Nam";
            this.radioButton_Male.UseVisualStyleBackColor = true;
            // 
            // comboBox_Language
            // 
            this.comboBox_Language.FormattingEnabled = true;
            this.comboBox_Language.Items.AddRange(new object[] {
            "Tiếng Việt",
            "Tiếng Anh"});
            this.comboBox_Language.Location = new System.Drawing.Point(136, 241);
            this.comboBox_Language.Name = "comboBox_Language";
            this.comboBox_Language.Size = new System.Drawing.Size(282, 27);
            this.comboBox_Language.TabIndex = 14;
            // 
            // label_Language
            // 
            this.label_Language.AutoSize = true;
            this.label_Language.Location = new System.Drawing.Point(19, 244);
            this.label_Language.Name = "label_Language";
            this.label_Language.Size = new System.Drawing.Size(73, 19);
            this.label_Language.TabIndex = 13;
            this.label_Language.Text = "Ngôn ngữ";
            // 
            // dateTimePicker_Birthday
            // 
            this.dateTimePicker_Birthday.Location = new System.Drawing.Point(136, 193);
            this.dateTimePicker_Birthday.Name = "dateTimePicker_Birthday";
            this.dateTimePicker_Birthday.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker_Birthday.Size = new System.Drawing.Size(282, 27);
            this.dateTimePicker_Birthday.TabIndex = 12;
            // 
            // label_Birthday
            // 
            this.label_Birthday.AutoSize = true;
            this.label_Birthday.Location = new System.Drawing.Point(19, 198);
            this.label_Birthday.Name = "label_Birthday";
            this.label_Birthday.Size = new System.Drawing.Size(69, 19);
            this.label_Birthday.TabIndex = 11;
            this.label_Birthday.Text = "Sinh nhật";
            // 
            // label_Phone_Number
            // 
            this.label_Phone_Number.AutoSize = true;
            this.label_Phone_Number.Location = new System.Drawing.Point(19, 146);
            this.label_Phone_Number.Name = "label_Phone_Number";
            this.label_Phone_Number.Size = new System.Drawing.Size(94, 19);
            this.label_Phone_Number.TabIndex = 10;
            this.label_Phone_Number.Text = "Số điện thoại";
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(136, 143);
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(282, 27);
            this.textBox_Phone.TabIndex = 9;
            // 
            // textBox_FullName
            // 
            this.textBox_FullName.Location = new System.Drawing.Point(136, 89);
            this.textBox_FullName.Name = "textBox_FullName";
            this.textBox_FullName.Size = new System.Drawing.Size(282, 27);
            this.textBox_FullName.TabIndex = 8;
            // 
            // label_Fullname
            // 
            this.label_Fullname.AutoSize = true;
            this.label_Fullname.Location = new System.Drawing.Point(19, 92);
            this.label_Fullname.Name = "label_Fullname";
            this.label_Fullname.Size = new System.Drawing.Size(71, 19);
            this.label_Fullname.TabIndex = 7;
            this.label_Fullname.Text = "Họ và tên";
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(136, 40);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(282, 27);
            this.textBox_Email.TabIndex = 6;
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(19, 43);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(45, 19);
            this.label_Email.TabIndex = 0;
            this.label_Email.Text = "Email";
            // 
            // button_Sign_Up
            // 
            this.button_Sign_Up.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Sign_Up.Location = new System.Drawing.Point(331, 520);
            this.button_Sign_Up.Name = "button_Sign_Up";
            this.button_Sign_Up.Size = new System.Drawing.Size(112, 31);
            this.button_Sign_Up.TabIndex = 3;
            this.button_Sign_Up.Text = "Đăng ký";
            this.button_Sign_Up.UseVisualStyleBackColor = true;
            this.button_Sign_Up.Click += new System.EventHandler(this.button_Sign_Up_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Clear.Location = new System.Drawing.Point(213, 520);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(112, 31);
            this.button_Clear.TabIndex = 4;
            this.button_Clear.Text = "Xóa";
            this.button_Clear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 526);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Đã có tài khoản?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // linkLabel_Sign_In
            // 
            this.linkLabel_Sign_In.AutoSize = true;
            this.linkLabel_Sign_In.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_Sign_In.Location = new System.Drawing.Point(122, 526);
            this.linkLabel_Sign_In.Name = "linkLabel_Sign_In";
            this.linkLabel_Sign_In.Size = new System.Drawing.Size(69, 17);
            this.linkLabel_Sign_In.TabIndex = 6;
            this.linkLabel_Sign_In.TabStop = true;
            this.linkLabel_Sign_In.Text = "Đăng nhập";
            this.linkLabel_Sign_In.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Sign_In_LinkClicked);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 559);
            this.Controls.Add(this.linkLabel_Sign_In);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Sign_Up);
            this.Controls.Add(this.groupBox_UserInformation);
            this.Controls.Add(this.groupBox_Sign_Up);
            this.Controls.Add(this.label_Title);
            this.Name = "SignUp";
            this.Text = "Hôm nay ăn gì? - Đăng ký";
            this.groupBox_Sign_Up.ResumeLayout(false);
            this.groupBox_Sign_Up.PerformLayout();
            this.groupBox_UserInformation.ResumeLayout(false);
            this.groupBox_UserInformation.PerformLayout();
            this.panel_Gender.ResumeLayout(false);
            this.panel_Gender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.GroupBox groupBox_Sign_Up;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.GroupBox groupBox_UserInformation;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.TextBox textBox_FullName;
        private System.Windows.Forms.Label label_Fullname;
        private System.Windows.Forms.Label label_Birthday;
        private System.Windows.Forms.Label label_Phone_Number;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.Panel panel_Gender;
        private System.Windows.Forms.RadioButton radioButton_Male;
        private System.Windows.Forms.ComboBox comboBox_Language;
        private System.Windows.Forms.Label label_Language;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Birthday;
        private System.Windows.Forms.Label label_Gender;
        private System.Windows.Forms.RadioButton radioButton_Female;
        private System.Windows.Forms.Button button_Sign_Up;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel_Sign_In;
    }
}