namespace Lab04_Bai07.SignIn
{
    partial class SignIn
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel_Sign_Up = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Sign_In = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Calibri", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_Title.Location = new System.Drawing.Point(115, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(219, 39);
            this.label_Title.TabIndex = 1;
            this.label_Title.Text = "Hôm nay ăn gì?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel_Sign_Up);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_Sign_In);
            this.groupBox1.Controls.Add(this.textBox_Password);
            this.groupBox1.Controls.Add(this.textBox_Username);
            this.groupBox1.Controls.Add(this.label_Username);
            this.groupBox1.Controls.Add(this.label_Password);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 162);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng nhập";
            // 
            // linkLabel_Sign_Up
            // 
            this.linkLabel_Sign_Up.AutoSize = true;
            this.linkLabel_Sign_Up.Location = new System.Drawing.Point(372, 103);
            this.linkLabel_Sign_Up.Name = "linkLabel_Sign_Up";
            this.linkLabel_Sign_Up.Size = new System.Drawing.Size(56, 18);
            this.linkLabel_Sign_Up.TabIndex = 12;
            this.linkLabel_Sign_Up.TabStop = true;
            this.linkLabel_Sign_Up.Text = "Đăng ký";
            this.linkLabel_Sign_Up.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Sign_Up_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chưa có tài khoản?";
            // 
            // button_Sign_In
            // 
            this.button_Sign_In.Location = new System.Drawing.Point(6, 125);
            this.button_Sign_In.Name = "button_Sign_In";
            this.button_Sign_In.Size = new System.Drawing.Size(421, 28);
            this.button_Sign_In.TabIndex = 10;
            this.button_Sign_In.Text = "Đăng nhập";
            this.button_Sign_In.UseVisualStyleBackColor = true;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(110, 70);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(317, 26);
            this.textBox_Password.TabIndex = 9;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(110, 25);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(317, 26);
            this.textBox_Username.TabIndex = 8;
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(6, 33);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(90, 18);
            this.label_Username.TabIndex = 7;
            this.label_Username.Text = "Tên tài khoản";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(6, 73);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(65, 18);
            this.label_Password.TabIndex = 6;
            this.label_Password.Text = "Mật khẩu";
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 219);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_Title);
            this.Name = "SignIn";
            this.Text = "Hôm nay ăn gì? - Sign In";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Sign_In;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.LinkLabel linkLabel_Sign_Up;
        private System.Windows.Forms.Label label1;
    }
}