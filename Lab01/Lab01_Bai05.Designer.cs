namespace NT106_Lab01
{
    partial class Lab01_Bai05
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
            this.label_ho_ten = new System.Windows.Forms.Label();
            this.label_phim = new System.Windows.Forms.Label();
            this.label_phong_chieu = new System.Windows.Forms.Label();
            this.label_ket_qua = new System.Windows.Forms.Label();
            this.textBox_ho_ten = new System.Windows.Forms.TextBox();
            this.comboBox_phim = new System.Windows.Forms.ComboBox();
            this.comboBox_phong_chieu = new System.Windows.Forms.ComboBox();
            this.textBox_ket_qua = new System.Windows.Forms.TextBox();
            this.button_dat_ve = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.label_screen = new System.Windows.Forms.Label();
            this.panel_seating = new System.Windows.Forms.Panel();
            this.label_legend = new System.Windows.Forms.Label();
            this.label_available = new System.Windows.Forms.Label();
            this.label_selected = new System.Windows.Forms.Label();
            this.label_booked = new System.Windows.Forms.Label();
            this.label_vip = new System.Windows.Forms.Label();
            this.label_normal = new System.Windows.Forms.Label();
            this.label_budget = new System.Windows.Forms.Label();
            this.panel_available = new System.Windows.Forms.Panel();
            this.panel_selected = new System.Windows.Forms.Panel();
            this.panel_booked = new System.Windows.Forms.Panel();
            this.panel_vip = new System.Windows.Forms.Panel();
            this.panel_normal = new System.Windows.Forms.Panel();
            this.panel_budget = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label_ho_ten
            // 
            this.label_ho_ten.AutoSize = true;
            this.label_ho_ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ho_ten.Location = new System.Drawing.Point(20, 20);
            this.label_ho_ten.Name = "label_ho_ten";
            this.label_ho_ten.Size = new System.Drawing.Size(73, 17);
            this.label_ho_ten.TabIndex = 0;
            this.label_ho_ten.Text = "Họ và tên:";
            // 
            // label_phim
            // 
            this.label_phim.AutoSize = true;
            this.label_phim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_phim.Location = new System.Drawing.Point(20, 55);
            this.label_phim.Name = "label_phim";
            this.label_phim.Size = new System.Drawing.Size(79, 17);
            this.label_phim.TabIndex = 1;
            this.label_phim.Text = "Chọn phim:";
            // 
            // label_phong_chieu
            // 
            this.label_phong_chieu.AutoSize = true;
            this.label_phong_chieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_phong_chieu.Location = new System.Drawing.Point(20, 90);
            this.label_phong_chieu.Name = "label_phong_chieu";
            this.label_phong_chieu.Size = new System.Drawing.Size(91, 17);
            this.label_phong_chieu.TabIndex = 2;
            this.label_phong_chieu.Text = "Phòng chiếu:";
            // 
            // label_ket_qua
            // 
            this.label_ket_qua.AutoSize = true;
            this.label_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ket_qua.Location = new System.Drawing.Point(694, 26);
            this.label_ket_qua.Name = "label_ket_qua";
            this.label_ket_qua.Size = new System.Drawing.Size(61, 17);
            this.label_ket_qua.TabIndex = 3;
            this.label_ket_qua.Text = "Kết quả:";
            // 
            // textBox_ho_ten
            // 
            this.textBox_ho_ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ho_ten.Location = new System.Drawing.Point(120, 17);
            this.textBox_ho_ten.Name = "textBox_ho_ten";
            this.textBox_ho_ten.Size = new System.Drawing.Size(200, 23);
            this.textBox_ho_ten.TabIndex = 1;
            // 
            // comboBox_phim
            // 
            this.comboBox_phim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_phim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_phim.FormattingEnabled = true;
            this.comboBox_phim.Location = new System.Drawing.Point(120, 52);
            this.comboBox_phim.Name = "comboBox_phim";
            this.comboBox_phim.Size = new System.Drawing.Size(200, 24);
            this.comboBox_phim.TabIndex = 2;
            this.comboBox_phim.SelectedIndexChanged += new System.EventHandler(this.comboBox_phim_SelectedIndexChanged);
            // 
            // comboBox_phong_chieu
            // 
            this.comboBox_phong_chieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_phong_chieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_phong_chieu.FormattingEnabled = true;
            this.comboBox_phong_chieu.Location = new System.Drawing.Point(120, 87);
            this.comboBox_phong_chieu.Name = "comboBox_phong_chieu";
            this.comboBox_phong_chieu.Size = new System.Drawing.Size(200, 24);
            this.comboBox_phong_chieu.TabIndex = 3;
            this.comboBox_phong_chieu.SelectedIndexChanged += new System.EventHandler(this.comboBox_phong_chieu_SelectedIndexChanged);
            // 
            // textBox_ket_qua
            // 
            this.textBox_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ket_qua.Location = new System.Drawing.Point(694, 46);
            this.textBox_ket_qua.Multiline = true;
            this.textBox_ket_qua.Name = "textBox_ket_qua";
            this.textBox_ket_qua.ReadOnly = true;
            this.textBox_ket_qua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ket_qua.Size = new System.Drawing.Size(350, 200);
            this.textBox_ket_qua.TabIndex = 7;
            // 
            // button_dat_ve
            // 
            this.button_dat_ve.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dat_ve.Location = new System.Drawing.Point(350, 40);
            this.button_dat_ve.Name = "button_dat_ve";
            this.button_dat_ve.Size = new System.Drawing.Size(100, 35);
            this.button_dat_ve.TabIndex = 4;
            this.button_dat_ve.Text = "Đặt vé";
            this.button_dat_ve.UseVisualStyleBackColor = true;
            this.button_dat_ve.Click += new System.EventHandler(this.button_dat_ve_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(470, 40);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(100, 35);
            this.button_xoa.TabIndex = 5;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(470, 90);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(100, 35);
            this.button_thoat.TabIndex = 6;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = true;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // label_screen
            // 
            this.label_screen.BackColor = System.Drawing.Color.Gray;
            this.label_screen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_screen.ForeColor = System.Drawing.Color.White;
            this.label_screen.Location = new System.Drawing.Point(20, 140);
            this.label_screen.Name = "label_screen";
            this.label_screen.Size = new System.Drawing.Size(650, 30);
            this.label_screen.TabIndex = 8;
            this.label_screen.Text = "SCREEN";
            this.label_screen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_seating
            // 
            this.panel_seating.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_seating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_seating.Location = new System.Drawing.Point(20, 180);
            this.panel_seating.Name = "panel_seating";
            this.panel_seating.Size = new System.Drawing.Size(650, 380);
            this.panel_seating.TabIndex = 9;
            // 
            // label_legend
            // 
            this.label_legend.AutoSize = true;
            this.label_legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_legend.Location = new System.Drawing.Point(694, 266);
            this.label_legend.Name = "label_legend";
            this.label_legend.Size = new System.Drawing.Size(81, 17);
            this.label_legend.TabIndex = 10;
            this.label_legend.Text = "Chú thích:";
            // 
            // label_available
            // 
            this.label_available.AutoSize = true;
            this.label_available.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_available.Location = new System.Drawing.Point(734, 296);
            this.label_available.Name = "label_available";
            this.label_available.Size = new System.Drawing.Size(61, 15);
            this.label_available.TabIndex = 11;
            this.label_available.Text = "Ghế trống";
            // 
            // label_selected
            // 
            this.label_selected.AutoSize = true;
            this.label_selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_selected.Location = new System.Drawing.Point(734, 326);
            this.label_selected.Name = "label_selected";
            this.label_selected.Size = new System.Drawing.Size(67, 15);
            this.label_selected.TabIndex = 12;
            this.label_selected.Text = "Đang chọn";
            // 
            // label_booked
            // 
            this.label_booked.AutoSize = true;
            this.label_booked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_booked.Location = new System.Drawing.Point(734, 356);
            this.label_booked.Name = "label_booked";
            this.label_booked.Size = new System.Drawing.Size(43, 15);
            this.label_booked.TabIndex = 13;
            this.label_booked.Text = "Đã đặt";
            // 
            // label_vip
            // 
            this.label_vip.AutoSize = true;
            this.label_vip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vip.Location = new System.Drawing.Point(734, 386);
            this.label_vip.Name = "label_vip";
            this.label_vip.Size = new System.Drawing.Size(86, 15);
            this.label_vip.TabIndex = 14;
            this.label_vip.Text = "Vé VIP (2x giá)";
            // 
            // label_normal
            // 
            this.label_normal.AutoSize = true;
            this.label_normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_normal.Location = new System.Drawing.Point(734, 416);
            this.label_normal.Name = "label_normal";
            this.label_normal.Size = new System.Drawing.Size(110, 15);
            this.label_normal.TabIndex = 15;
            this.label_normal.Text = "Vé Thường (1x giá)";
            // 
            // label_budget
            // 
            this.label_budget.AutoSize = true;
            this.label_budget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_budget.Location = new System.Drawing.Point(734, 446);
            this.label_budget.Name = "label_budget";
            this.label_budget.Size = new System.Drawing.Size(89, 15);
            this.label_budget.TabIndex = 16;
            this.label_budget.Text = "Vé Vớt (1/4 giá)";
            // 
            // panel_available
            // 
            this.panel_available.BackColor = System.Drawing.Color.LightGray;
            this.panel_available.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_available.Location = new System.Drawing.Point(704, 293);
            this.panel_available.Name = "panel_available";
            this.panel_available.Size = new System.Drawing.Size(20, 20);
            this.panel_available.TabIndex = 17;
            // 
            // panel_selected
            // 
            this.panel_selected.BackColor = System.Drawing.Color.Orange;
            this.panel_selected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_selected.Location = new System.Drawing.Point(704, 323);
            this.panel_selected.Name = "panel_selected";
            this.panel_selected.Size = new System.Drawing.Size(20, 20);
            this.panel_selected.TabIndex = 18;
            // 
            // panel_booked
            // 
            this.panel_booked.BackColor = System.Drawing.Color.Red;
            this.panel_booked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_booked.Location = new System.Drawing.Point(704, 353);
            this.panel_booked.Name = "panel_booked";
            this.panel_booked.Size = new System.Drawing.Size(20, 20);
            this.panel_booked.TabIndex = 19;
            // 
            // panel_vip
            // 
            this.panel_vip.BackColor = System.Drawing.Color.Gold;
            this.panel_vip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_vip.Location = new System.Drawing.Point(704, 383);
            this.panel_vip.Name = "panel_vip";
            this.panel_vip.Size = new System.Drawing.Size(20, 20);
            this.panel_vip.TabIndex = 20;
            // 
            // panel_normal
            // 
            this.panel_normal.BackColor = System.Drawing.Color.LightGreen;
            this.panel_normal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_normal.Location = new System.Drawing.Point(704, 413);
            this.panel_normal.Name = "panel_normal";
            this.panel_normal.Size = new System.Drawing.Size(20, 20);
            this.panel_normal.TabIndex = 21;
            // 
            // panel_budget
            // 
            this.panel_budget.BackColor = System.Drawing.Color.LightBlue;
            this.panel_budget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_budget.Location = new System.Drawing.Point(704, 443);
            this.panel_budget.Name = "panel_budget";
            this.panel_budget.Size = new System.Drawing.Size(20, 20);
            this.panel_budget.TabIndex = 22;
            // 
            // Lab01_Bai05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 600);
            this.Controls.Add(this.panel_budget);
            this.Controls.Add(this.panel_normal);
            this.Controls.Add(this.panel_vip);
            this.Controls.Add(this.panel_booked);
            this.Controls.Add(this.panel_selected);
            this.Controls.Add(this.panel_available);
            this.Controls.Add(this.label_budget);
            this.Controls.Add(this.label_normal);
            this.Controls.Add(this.label_vip);
            this.Controls.Add(this.label_booked);
            this.Controls.Add(this.label_selected);
            this.Controls.Add(this.label_available);
            this.Controls.Add(this.label_legend);
            this.Controls.Add(this.panel_seating);
            this.Controls.Add(this.label_screen);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_dat_ve);
            this.Controls.Add(this.textBox_ket_qua);
            this.Controls.Add(this.comboBox_phong_chieu);
            this.Controls.Add(this.comboBox_phim);
            this.Controls.Add(this.textBox_ho_ten);
            this.Controls.Add(this.label_ket_qua);
            this.Controls.Add(this.label_phong_chieu);
            this.Controls.Add(this.label_phim);
            this.Controls.Add(this.label_ho_ten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lab01_Bai05";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 05 - Đặt vé phim";
            this.Load += new System.EventHandler(this.Lab01_Bai05_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ho_ten;
        private System.Windows.Forms.Label label_phim;
        private System.Windows.Forms.Label label_phong_chieu;
        private System.Windows.Forms.Label label_ket_qua;
        private System.Windows.Forms.TextBox textBox_ho_ten;
        private System.Windows.Forms.ComboBox comboBox_phim;
        private System.Windows.Forms.ComboBox comboBox_phong_chieu;
        private System.Windows.Forms.TextBox textBox_ket_qua;
        private System.Windows.Forms.Button button_dat_ve;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.Label label_screen;
        private System.Windows.Forms.Panel panel_seating;
        private System.Windows.Forms.Label label_legend;
        private System.Windows.Forms.Label label_available;
        private System.Windows.Forms.Label label_selected;
        private System.Windows.Forms.Label label_booked;
        private System.Windows.Forms.Label label_vip;
        private System.Windows.Forms.Label label_normal;
        private System.Windows.Forms.Label label_budget;
        private System.Windows.Forms.Panel panel_available;
        private System.Windows.Forms.Panel panel_selected;
        private System.Windows.Forms.Panel panel_booked;
        private System.Windows.Forms.Panel panel_vip;
        private System.Windows.Forms.Panel panel_normal;
        private System.Windows.Forms.Panel panel_budget;
    }
}