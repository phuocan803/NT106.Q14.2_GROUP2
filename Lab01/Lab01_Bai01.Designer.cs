namespace NT106_Lab01
{
    partial class Lab01_Bai01
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
            this.label_so_thu_nhat = new System.Windows.Forms.Label();
            this.label_so_thu_hai = new System.Windows.Forms.Label();
            this.label_ket_qua = new System.Windows.Forms.Label();
            this.textBox_so_thu_nhat = new System.Windows.Forms.TextBox();
            this.textBox_so_thu_hai = new System.Windows.Forms.TextBox();
            this.textBox_ket_qua = new System.Windows.Forms.TextBox();
            this.button_tinh_toan = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_so_thu_nhat
            // 
            this.label_so_thu_nhat.AutoSize = true;
            this.label_so_thu_nhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_so_thu_nhat.Location = new System.Drawing.Point(50, 50);
            this.label_so_thu_nhat.Name = "label_so_thu_nhat";
            this.label_so_thu_nhat.Size = new System.Drawing.Size(82, 17);
            this.label_so_thu_nhat.TabIndex = 0;
            this.label_so_thu_nhat.Text = "Số thứ nhất:";
            this.label_so_thu_nhat.Click += new System.EventHandler(this.label_so_thu_nhat_Click);
            // 
            // label_so_thu_hai
            // 
            this.label_so_thu_hai.AutoSize = true;
            this.label_so_thu_hai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_so_thu_hai.Location = new System.Drawing.Point(50, 90);
            this.label_so_thu_hai.Name = "label_so_thu_hai";
            this.label_so_thu_hai.Size = new System.Drawing.Size(75, 17);
            this.label_so_thu_hai.TabIndex = 1;
            this.label_so_thu_hai.Text = "Số thứ hai:";
            this.label_so_thu_hai.Click += new System.EventHandler(this.label_so_thu_hai_Click);
            // 
            // label_ket_qua
            // 
            this.label_ket_qua.AutoSize = true;
            this.label_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ket_qua.Location = new System.Drawing.Point(50, 130);
            this.label_ket_qua.Name = "label_ket_qua";
            this.label_ket_qua.Size = new System.Drawing.Size(64, 17);
            this.label_ket_qua.TabIndex = 2;
            this.label_ket_qua.Text = "Kết quả:";
            this.label_ket_qua.Click += new System.EventHandler(this.label_ket_qua_Click);
            // 
            // textBox_so_thu_nhat
            // 
            this.textBox_so_thu_nhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_so_thu_nhat.Location = new System.Drawing.Point(160, 47);
            this.textBox_so_thu_nhat.Name = "textBox_so_thu_nhat";
            this.textBox_so_thu_nhat.Size = new System.Drawing.Size(150, 23);
            this.textBox_so_thu_nhat.TabIndex = 1;
            this.textBox_so_thu_nhat.TextChanged += new System.EventHandler(this.textBox_so_thu_nhat_TextChanged);
            // 
            // textBox_so_thu_hai
            // 
            this.textBox_so_thu_hai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_so_thu_hai.Location = new System.Drawing.Point(160, 87);
            this.textBox_so_thu_hai.Name = "textBox_so_thu_hai";
            this.textBox_so_thu_hai.Size = new System.Drawing.Size(150, 23);
            this.textBox_so_thu_hai.TabIndex = 2;
            this.textBox_so_thu_hai.TextChanged += new System.EventHandler(this.textBox_so_thu_hai_TextChanged);
            // 
            // textBox_ket_qua
            // 
            this.textBox_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ket_qua.Location = new System.Drawing.Point(160, 127);
            this.textBox_ket_qua.Name = "textBox_ket_qua";
            this.textBox_ket_qua.ReadOnly = true;
            this.textBox_ket_qua.Size = new System.Drawing.Size(150, 23);
            this.textBox_ket_qua.TabIndex = 5;
            this.textBox_ket_qua.TextChanged += new System.EventHandler(this.textBox_ket_qua_TextChanged);
            // 
            // button_tinh_toan
            // 
            this.button_tinh_toan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_tinh_toan.Location = new System.Drawing.Point(80, 180);
            this.button_tinh_toan.Name = "button_tinh_toan";
            this.button_tinh_toan.Size = new System.Drawing.Size(100, 35);
            this.button_tinh_toan.TabIndex = 3;
            this.button_tinh_toan.Text = "Tính toán";
            this.button_tinh_toan.UseVisualStyleBackColor = true;
            this.button_tinh_toan.Click += new System.EventHandler(this.button_ket_qua_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(210, 180);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(100, 35);
            this.button_xoa.TabIndex = 4;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // Lab01_Bai01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_tinh_toan);
            this.Controls.Add(this.textBox_ket_qua);
            this.Controls.Add(this.textBox_so_thu_hai);
            this.Controls.Add(this.textBox_so_thu_nhat);
            this.Controls.Add(this.label_ket_qua);
            this.Controls.Add(this.label_so_thu_hai);
            this.Controls.Add(this.label_so_thu_nhat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lab01_Bai01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 01 - Tổng của hai số";
            this.Load += new System.EventHandler(this.Lab01_Bai01_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_so_thu_nhat;
        private System.Windows.Forms.Label label_so_thu_hai;
        private System.Windows.Forms.Label label_ket_qua;
        private System.Windows.Forms.TextBox textBox_so_thu_nhat;
        private System.Windows.Forms.TextBox textBox_so_thu_hai;
        private System.Windows.Forms.TextBox textBox_ket_qua;
        private System.Windows.Forms.Button button_tinh_toan;
        private System.Windows.Forms.Button button_xoa;
    }
}