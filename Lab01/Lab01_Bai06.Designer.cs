namespace NT106_Lab01
{
    partial class Lab01_Bai06
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
            this.label_nhap_a = new System.Windows.Forms.Label();
            this.label_nhap_b = new System.Windows.Forms.Label();
            this.label_chon_loai = new System.Windows.Forms.Label();
            this.label_ket_qua = new System.Windows.Forms.Label();
            this.textBox_nhap_a = new System.Windows.Forms.TextBox();
            this.textBox_nhap_b = new System.Windows.Forms.TextBox();
            this.comboBox_loai = new System.Windows.Forms.ComboBox();
            this.textBox_ket_qua = new System.Windows.Forms.TextBox();
            this.button_tinh = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_nhap_a
            // 
            this.label_nhap_a.AutoSize = true;
            this.label_nhap_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nhap_a.Location = new System.Drawing.Point(50, 50);
            this.label_nhap_a.Name = "label_nhap_a";
            this.label_nhap_a.Size = new System.Drawing.Size(68, 17);
            this.label_nhap_a.TabIndex = 0;
            this.label_nhap_a.Text = "Nhập A:";
            // 
            // label_nhap_b
            // 
            this.label_nhap_b.AutoSize = true;
            this.label_nhap_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nhap_b.Location = new System.Drawing.Point(350, 50);
            this.label_nhap_b.Name = "label_nhap_b";
            this.label_nhap_b.Size = new System.Drawing.Size(68, 17);
            this.label_nhap_b.TabIndex = 1;
            this.label_nhap_b.Text = "Nhập B:";
            this.label_nhap_b.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_chon_loai
            // 
            this.label_chon_loai.AutoSize = true;
            this.label_chon_loai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_chon_loai.Location = new System.Drawing.Point(50, 100);
            this.label_chon_loai.Name = "label_chon_loai";
            this.label_chon_loai.Size = new System.Drawing.Size(176, 17);
            this.label_chon_loai.TabIndex = 2;
            this.label_chon_loai.Text = "Chọn loại phương trình:";
            // 
            // label_ket_qua
            // 
            this.label_ket_qua.AutoSize = true;
            this.label_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ket_qua.Location = new System.Drawing.Point(50, 200);
            this.label_ket_qua.Name = "label_ket_qua";
            this.label_ket_qua.Size = new System.Drawing.Size(78, 17);
            this.label_ket_qua.TabIndex = 3;
            this.label_ket_qua.Text = "KẾT QUẢ:";
            // 
            // textBox_nhap_a
            // 
            this.textBox_nhap_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nhap_a.Location = new System.Drawing.Point(130, 47);
            this.textBox_nhap_a.Name = "textBox_nhap_a";
            this.textBox_nhap_a.Size = new System.Drawing.Size(120, 23);
            this.textBox_nhap_a.TabIndex = 1;
            // 
            // textBox_nhap_b
            // 
            this.textBox_nhap_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nhap_b.Location = new System.Drawing.Point(430, 47);
            this.textBox_nhap_b.Name = "textBox_nhap_b";
            this.textBox_nhap_b.Size = new System.Drawing.Size(120, 23);
            this.textBox_nhap_b.TabIndex = 2;
            // 
            // comboBox_loai
            // 
            this.comboBox_loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_loai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_loai.FormattingEnabled = true;
            this.comboBox_loai.Location = new System.Drawing.Point(250, 97);
            this.comboBox_loai.Name = "comboBox_loai";
            this.comboBox_loai.Size = new System.Drawing.Size(200, 24);
            this.comboBox_loai.TabIndex = 3;
            this.comboBox_loai.SelectedIndexChanged += new System.EventHandler(this.comboBox_loai_SelectedIndexChanged);
            // 
            // textBox_ket_qua
            // 
            this.textBox_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ket_qua.Location = new System.Drawing.Point(50, 230);
            this.textBox_ket_qua.Multiline = true;
            this.textBox_ket_qua.Name = "textBox_ket_qua";
            this.textBox_ket_qua.ReadOnly = true;
            this.textBox_ket_qua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ket_qua.Size = new System.Drawing.Size(500, 120);
            this.textBox_ket_qua.TabIndex = 7;
            this.textBox_ket_qua.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button_tinh
            // 
            this.button_tinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_tinh.Location = new System.Drawing.Point(150, 150);
            this.button_tinh.Name = "button_tinh";
            this.button_tinh.Size = new System.Drawing.Size(120, 35);
            this.button_tinh.TabIndex = 4;
            this.button_tinh.Text = "Tính toán";
            this.button_tinh.UseVisualStyleBackColor = true;
            this.button_tinh.Click += new System.EventHandler(this.button_tinh_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(300, 150);
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
            this.button_thoat.Location = new System.Drawing.Point(430, 150);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(100, 35);
            this.button_thoat.TabIndex = 6;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = true;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // Lab01_Bai06
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 380);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_tinh);
            this.Controls.Add(this.textBox_ket_qua);
            this.Controls.Add(this.comboBox_loai);
            this.Controls.Add(this.textBox_nhap_b);
            this.Controls.Add(this.textBox_nhap_a);
            this.Controls.Add(this.label_ket_qua);
            this.Controls.Add(this.label_chon_loai);
            this.Controls.Add(this.label_nhap_b);
            this.Controls.Add(this.label_nhap_a);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lab01_Bai06";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 06 - Giải phương trình";
            this.Load += new System.EventHandler(this.Lab01_Bai06_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nhap_a;
        private System.Windows.Forms.Label label_nhap_b;
        private System.Windows.Forms.Label label_chon_loai;
        private System.Windows.Forms.Label label_ket_qua;
        private System.Windows.Forms.TextBox textBox_nhap_a;
        private System.Windows.Forms.TextBox textBox_nhap_b;
        private System.Windows.Forms.ComboBox comboBox_loai;
        private System.Windows.Forms.TextBox textBox_ket_qua;
        private System.Windows.Forms.Button button_tinh;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_thoat;
    }
}