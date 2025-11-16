namespace NT106_Lab01
{
    partial class Lab01_Bai09
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
            this.label_nhap_mon_an = new System.Windows.Forms.Label();
            this.textBox_nhap_mon_an = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.listBox_mon_an = new System.Windows.Forms.ListBox();
            this.button_tim_mon_an = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.label_ket_qua = new System.Windows.Forms.Label();
            this.textBox_ket_qua = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_nhap_mon_an
            // 
            this.label_nhap_mon_an.AutoSize = true;
            this.label_nhap_mon_an.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nhap_mon_an.Location = new System.Drawing.Point(30, 30);
            this.label_nhap_mon_an.Name = "label_nhap_mon_an";
            this.label_nhap_mon_an.Size = new System.Drawing.Size(97, 17);
            this.label_nhap_mon_an.TabIndex = 0;
            this.label_nhap_mon_an.Text = "Nhập món ăn:";
            // 
            // textBox_nhap_mon_an
            // 
            this.textBox_nhap_mon_an.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nhap_mon_an.Location = new System.Drawing.Point(30, 55);
            this.textBox_nhap_mon_an.Name = "textBox_nhap_mon_an";
            this.textBox_nhap_mon_an.Size = new System.Drawing.Size(200, 23);
            this.textBox_nhap_mon_an.TabIndex = 1;
            this.textBox_nhap_mon_an.TextChanged += new System.EventHandler(this.textBox_nhap_mon_an_TextChanged);
            this.textBox_nhap_mon_an.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nhap_mon_an_KeyPress);
            // 
            // button_them
            // 
            this.button_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.Location = new System.Drawing.Point(155, 90);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(75, 30);
            this.button_them.TabIndex = 2;
            this.button_them.Text = "Thêm";
            this.button_them.UseVisualStyleBackColor = true;
            this.button_them.Click += new System.EventHandler(this.button_them_Click);
            // 
            // listBox_mon_an
            // 
            this.listBox_mon_an.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_mon_an.FormattingEnabled = true;
            this.listBox_mon_an.ItemHeight = 16;
            this.listBox_mon_an.Location = new System.Drawing.Point(280, 55);
            this.listBox_mon_an.Name = "listBox_mon_an";
            this.listBox_mon_an.Size = new System.Drawing.Size(250, 132);
            this.listBox_mon_an.TabIndex = 3;
            // 
            // button_tim_mon_an
            // 
            this.button_tim_mon_an.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_tim_mon_an.Location = new System.Drawing.Point(30, 220);
            this.button_tim_mon_an.Name = "button_tim_mon_an";
            this.button_tim_mon_an.Size = new System.Drawing.Size(100, 35);
            this.button_tim_mon_an.TabIndex = 4;
            this.button_tim_mon_an.Text = "Tìm món ăn";
            this.button_tim_mon_an.UseVisualStyleBackColor = true;
            this.button_tim_mon_an.Click += new System.EventHandler(this.button_tim_mon_an_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(280, 220);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(75, 35);
            this.button_xoa.TabIndex = 5;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(455, 220);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(75, 35);
            this.button_thoat.TabIndex = 6;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = true;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // label_ket_qua
            // 
            this.label_ket_qua.AutoSize = true;
            this.label_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ket_qua.Location = new System.Drawing.Point(220, 280);
            this.label_ket_qua.Name = "label_ket_qua";
            this.label_ket_qua.Size = new System.Drawing.Size(150, 17);
            this.label_ket_qua.TabIndex = 7;
            this.label_ket_qua.Text = "Món ăn hôm nay là:";
            // 
            // textBox_ket_qua
            // 
            this.textBox_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ket_qua.Location = new System.Drawing.Point(130, 310);
            this.textBox_ket_qua.Name = "textBox_ket_qua";
            this.textBox_ket_qua.ReadOnly = true;
            this.textBox_ket_qua.Size = new System.Drawing.Size(300, 26);
            this.textBox_ket_qua.TabIndex = 8;
            this.textBox_ket_qua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lab01_Bai09
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 380);
            this.Controls.Add(this.textBox_ket_qua);
            this.Controls.Add(this.label_ket_qua);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_tim_mon_an);
            this.Controls.Add(this.listBox_mon_an);
            this.Controls.Add(this.button_them);
            this.Controls.Add(this.textBox_nhap_mon_an);
            this.Controls.Add(this.label_nhap_mon_an);
            this.Name = "Lab01_Bai09";
            this.Text = "Bài 09 - Hôm nay ăn gì?";
            this.Load += new System.EventHandler(this.Lab01_Bai09_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nhap_mon_an;
        private System.Windows.Forms.TextBox textBox_nhap_mon_an;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.ListBox listBox_mon_an;
        private System.Windows.Forms.Button button_tim_mon_an;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_thoat;
        private System.Windows.Forms.Label label_ket_qua;
        private System.Windows.Forms.TextBox textBox_ket_qua;
    }
}