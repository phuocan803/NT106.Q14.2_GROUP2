namespace Lab05_Bai02
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_Login = new System.Windows.Forms.Button();
            this.TextBox_User = new System.Windows.Forms.TextBox();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.Label_User = new System.Windows.Forms.Label();
            this.Label_Pass = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-60, -10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1100, 620);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Button_Login
            // 
            this.Button_Login.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Button_Login.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Button_Login.ForeColor = System.Drawing.Color.Navy;
            this.Button_Login.Location = new System.Drawing.Point(373, 183);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(201, 39);
            this.Button_Login.TabIndex = 6;
            this.Button_Login.Text = "Login";
            this.Button_Login.UseVisualStyleBackColor = false;
            // 
            // TextBox_User
            // 
            this.TextBox_User.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_User.Location = new System.Drawing.Point(208, 42);
            this.TextBox_User.Name = "TextBox_User";
            this.TextBox_User.Size = new System.Drawing.Size(366, 30);
            this.TextBox_User.TabIndex = 3;
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Password.Location = new System.Drawing.Point(208, 119);
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.Size = new System.Drawing.Size(366, 30);
            this.TextBox_Password.TabIndex = 5;
            this.TextBox_Password.UseSystemPasswordChar = true;
            // 
            // Label_User
            // 
            this.Label_User.AutoSize = true;
            this.Label_User.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Label_User.ForeColor = System.Drawing.Color.Navy;
            this.Label_User.Location = new System.Drawing.Point(30, 42);
            this.Label_User.Name = "Label_User";
            this.Label_User.Size = new System.Drawing.Size(59, 23);
            this.Label_User.TabIndex = 2;
            this.Label_User.Text = "Email:";
            // 
            // Label_Pass
            // 
            this.Label_Pass.AutoSize = true;
            this.Label_Pass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Label_Pass.ForeColor = System.Drawing.Color.Navy;
            this.Label_Pass.Location = new System.Drawing.Point(30, 119);
            this.Label_Pass.Name = "Label_Pass";
            this.Label_Pass.Size = new System.Drawing.Size(130, 23);
            this.Label_Pass.TabIndex = 4;
            this.Label_Pass.Text = "App password:";
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(594, 234);
            this.Controls.Add(this.Label_User);
            this.Controls.Add(this.TextBox_User);
            this.Controls.Add(this.Label_Pass);
            this.Controls.Add(this.TextBox_Password);
            this.Controls.Add(this.Button_Login);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Lab04_Bai05";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Button_Login;
        private System.Windows.Forms.TextBox TextBox_User;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.Label Label_User;
        private System.Windows.Forms.Label Label_Pass;
    }
}
