namespace Lab03_Bai04
{
    partial class Client
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
            this.label_FullName = new System.Windows.Forms.Label();
            this.label_MovieName = new System.Windows.Forms.Label();
            this.label_Room = new System.Windows.Forms.Label();
            this.textBox_FullName = new System.Windows.Forms.TextBox();
            this.comboBox_MovieName = new System.Windows.Forms.ComboBox();
            this.comboBox_Room = new System.Windows.Forms.ComboBox();
            this.checkedListBox_Seat = new System.Windows.Forms.CheckedListBox();
            this.label_Seat = new System.Windows.Forms.Label();
            this.groupBox_BuyTicket = new System.Windows.Forms.GroupBox();
            this.button_Buy = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Layout = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_IP_Remote_Host = new System.Windows.Forms.TextBox();
            this.label_IP_Remote_Host = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox_Connect = new System.Windows.Forms.GroupBox();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.groupBox_BuyTicket.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox_Connect.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_FullName
            // 
            this.label_FullName.AutoSize = true;
            this.label_FullName.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FullName.Location = new System.Drawing.Point(6, 28);
            this.label_FullName.Name = "label_FullName";
            this.label_FullName.Size = new System.Drawing.Size(66, 18);
            this.label_FullName.TabIndex = 0;
            this.label_FullName.Text = "Họ và tên";
            // 
            // label_MovieName
            // 
            this.label_MovieName.AutoSize = true;
            this.label_MovieName.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MovieName.Location = new System.Drawing.Point(2, 60);
            this.label_MovieName.Name = "label_MovieName";
            this.label_MovieName.Size = new System.Drawing.Size(84, 18);
            this.label_MovieName.TabIndex = 1;
            this.label_MovieName.Text = "Tên bộ phim";
            // 
            // label_Room
            // 
            this.label_Room.AutoSize = true;
            this.label_Room.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Room.Location = new System.Drawing.Point(6, 92);
            this.label_Room.Name = "label_Room";
            this.label_Room.Size = new System.Drawing.Size(47, 18);
            this.label_Room.TabIndex = 2;
            this.label_Room.Text = "Phòng";
            // 
            // textBox_FullName
            // 
            this.textBox_FullName.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FullName.Location = new System.Drawing.Point(141, 25);
            this.textBox_FullName.Name = "textBox_FullName";
            this.textBox_FullName.Size = new System.Drawing.Size(238, 26);
            this.textBox_FullName.TabIndex = 3;
            // 
            // comboBox_MovieName
            // 
            this.comboBox_MovieName.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_MovieName.FormattingEnabled = true;
            this.comboBox_MovieName.Items.AddRange(new object[] {
            "Đào, phở và piano",
            "Mai",
            "Gặp lại chị bầu",
            "Tarot"});
            this.comboBox_MovieName.Location = new System.Drawing.Point(141, 57);
            this.comboBox_MovieName.Name = "comboBox_MovieName";
            this.comboBox_MovieName.Size = new System.Drawing.Size(238, 26);
            this.comboBox_MovieName.TabIndex = 4;
            this.comboBox_MovieName.SelectedIndexChanged += new System.EventHandler(this.comboBox_MovieName_SelectedIndexChanged);
            // 
            // comboBox_Room
            // 
            this.comboBox_Room.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Room.FormattingEnabled = true;
            this.comboBox_Room.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBox_Room.Location = new System.Drawing.Point(141, 89);
            this.comboBox_Room.Name = "comboBox_Room";
            this.comboBox_Room.Size = new System.Drawing.Size(238, 26);
            this.comboBox_Room.TabIndex = 5;
            this.comboBox_Room.SelectedIndexChanged += new System.EventHandler(this.comboBox_Room_SelectedIndexChanged);
            // 
            // checkedListBox_Seat
            // 
            this.checkedListBox_Seat.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox_Seat.FormattingEnabled = true;
            this.checkedListBox_Seat.Items.AddRange(new object[] {
            " "});
            this.checkedListBox_Seat.Location = new System.Drawing.Point(5, 156);
            this.checkedListBox_Seat.Name = "checkedListBox_Seat";
            this.checkedListBox_Seat.Size = new System.Drawing.Size(143, 109);
            this.checkedListBox_Seat.TabIndex = 6;
            // 
            // label_Seat
            // 
            this.label_Seat.AutoSize = true;
            this.label_Seat.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seat.Location = new System.Drawing.Point(1, 131);
            this.label_Seat.Name = "label_Seat";
            this.label_Seat.Size = new System.Drawing.Size(41, 23);
            this.label_Seat.TabIndex = 7;
            this.label_Seat.Text = "Ghế";
            // 
            // groupBox_BuyTicket
            // 
            this.groupBox_BuyTicket.Controls.Add(this.button_Buy);
            this.groupBox_BuyTicket.Controls.Add(this.textBox_FullName);
            this.groupBox_BuyTicket.Controls.Add(this.comboBox_MovieName);
            this.groupBox_BuyTicket.Controls.Add(this.comboBox_Room);
            this.groupBox_BuyTicket.Controls.Add(this.button_Exit);
            this.groupBox_BuyTicket.Controls.Add(this.label1);
            this.groupBox_BuyTicket.Controls.Add(this.label_Layout);
            this.groupBox_BuyTicket.Controls.Add(this.checkedListBox_Seat);
            this.groupBox_BuyTicket.Controls.Add(this.label_Seat);
            this.groupBox_BuyTicket.Controls.Add(this.label_FullName);
            this.groupBox_BuyTicket.Controls.Add(this.label_MovieName);
            this.groupBox_BuyTicket.Controls.Add(this.label_Room);
            this.groupBox_BuyTicket.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_BuyTicket.Location = new System.Drawing.Point(12, 109);
            this.groupBox_BuyTicket.Name = "groupBox_BuyTicket";
            this.groupBox_BuyTicket.Size = new System.Drawing.Size(385, 364);
            this.groupBox_BuyTicket.TabIndex = 8;
            this.groupBox_BuyTicket.TabStop = false;
            this.groupBox_BuyTicket.Text = "Đặt vé";
            // 
            // button_Buy
            // 
            this.button_Buy.Location = new System.Drawing.Point(246, 320);
            this.button_Buy.Name = "button_Buy";
            this.button_Buy.Size = new System.Drawing.Size(90, 36);
            this.button_Buy.TabIndex = 10;
            this.button_Buy.Text = "Đặt vé";
            this.button_Buy.UseVisualStyleBackColor = true;
            this.button_Buy.Click += new System.EventHandler(this.button_Buy_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(36, 320);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(90, 36);
            this.button_Exit.TabIndex = 9;
            this.button_Exit.Text = "Thoát";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sơ đồ";
            // 
            // label_Layout
            // 
            this.label_Layout.AutoSize = true;
            this.label_Layout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_Layout.Font = new System.Drawing.Font("Calibri", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Layout.Location = new System.Drawing.Point(200, 156);
            this.label_Layout.Name = "label_Layout";
            this.label_Layout.Size = new System.Drawing.Size(179, 161);
            this.label_Layout.TabIndex = 8;
            this.label_Layout.Text = "         MÀN HÌNH\r\n\r\nA1    A2    A3    A4    A5\r\nB1    B2    B3    B4    B5\r\nC1  " +
    "  C2    C3    C4    C5\r\n\r\n          MÁY CHIẾU\r\n";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Port.Location = new System.Drawing.Point(115, 51);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(166, 26);
            this.textBox_Port.TabIndex = 14;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Port.Location = new System.Drawing.Point(8, 54);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(34, 18);
            this.label_Port.TabIndex = 13;
            this.label_Port.Text = "Port";
            // 
            // textBox_IP_Remote_Host
            // 
            this.textBox_IP_Remote_Host.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_IP_Remote_Host.Location = new System.Drawing.Point(115, 19);
            this.textBox_IP_Remote_Host.Name = "textBox_IP_Remote_Host";
            this.textBox_IP_Remote_Host.Size = new System.Drawing.Size(166, 26);
            this.textBox_IP_Remote_Host.TabIndex = 12;
            // 
            // label_IP_Remote_Host
            // 
            this.label_IP_Remote_Host.AutoSize = true;
            this.label_IP_Remote_Host.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IP_Remote_Host.Location = new System.Drawing.Point(6, 22);
            this.label_IP_Remote_Host.Name = "label_IP_Remote_Host";
            this.label_IP_Remote_Host.Size = new System.Drawing.Size(103, 18);
            this.label_IP_Remote_Host.TabIndex = 11;
            this.label_IP_Remote_Host.Text = "IP Remote Host";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(403, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 461);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phim";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox3);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox4);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(420, 430);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Lab03_Bai04.Properties.Resources.Dao_Pho_va_Piano;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::Lab03_Bai04.Properties.Resources.Mai;
            this.pictureBox2.Location = new System.Drawing.Point(212, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(203, 296);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = global::Lab03_Bai04.Properties.Resources.Gap_lai_chi_Bau;
            this.pictureBox3.Location = new System.Drawing.Point(3, 305);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(203, 296);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = global::Lab03_Bai04.Properties.Resources.tarot;
            this.pictureBox4.Location = new System.Drawing.Point(212, 305);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(203, 296);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // groupBox_Connect
            // 
            this.groupBox_Connect.Controls.Add(this.button_Disconnect);
            this.groupBox_Connect.Controls.Add(this.button_Connect);
            this.groupBox_Connect.Controls.Add(this.label_IP_Remote_Host);
            this.groupBox_Connect.Controls.Add(this.label_Port);
            this.groupBox_Connect.Controls.Add(this.textBox_IP_Remote_Host);
            this.groupBox_Connect.Controls.Add(this.textBox_Port);
            this.groupBox_Connect.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Connect.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Connect.Name = "groupBox_Connect";
            this.groupBox_Connect.Size = new System.Drawing.Size(379, 91);
            this.groupBox_Connect.TabIndex = 15;
            this.groupBox_Connect.TabStop = false;
            this.groupBox_Connect.Text = "Kết nối";
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(283, 50);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(90, 26);
            this.button_Disconnect.TabIndex = 15;
            this.button_Disconnect.Text = "Ngắt";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(283, 19);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(90, 26);
            this.button_Connect.TabIndex = 11;
            this.button_Connect.Text = "Kết nối";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 481);
            this.Controls.Add(this.groupBox_Connect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_BuyTicket);
            this.Name = "Client";
            this.Text = "Buy Ticket";
            this.groupBox_BuyTicket.ResumeLayout(false);
            this.groupBox_BuyTicket.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox_Connect.ResumeLayout(false);
            this.groupBox_Connect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_FullName;
        private System.Windows.Forms.Label label_MovieName;
        private System.Windows.Forms.Label label_Room;
        private System.Windows.Forms.TextBox textBox_FullName;
        private System.Windows.Forms.ComboBox comboBox_MovieName;
        private System.Windows.Forms.ComboBox comboBox_Room;
        private System.Windows.Forms.CheckedListBox checkedListBox_Seat;
        private System.Windows.Forms.Label label_Seat;
        private System.Windows.Forms.GroupBox groupBox_BuyTicket;
        private System.Windows.Forms.Label label_Layout;
        private System.Windows.Forms.Button button_Buy;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label_IP_Remote_Host;
        private System.Windows.Forms.TextBox textBox_IP_Remote_Host;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.GroupBox groupBox_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Connect;
    }
}

