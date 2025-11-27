namespace NT106_Lab01
{
    partial class Lab01_Bai04
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
            this.label_nhap_so_nguyen = new System.Windows.Forms.Label();
            this.label_ket_qua = new System.Windows.Forms.Label();
            this.textBox_nhap_so = new System.Windows.Forms.TextBox();
            this.textBox_ket_qua = new System.Windows.Forms.TextBox();
            this.button_doc = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_nhap_so_nguyen
            // 
            this.label_nhap_so_nguyen.AutoSize = true;
            this.label_nhap_so_nguyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nhap_so_nguyen.Location = new System.Drawing.Point(50, 50);
            this.label_nhap_so_nguyen.Name = "label_nhap_so_nguyen";
            this.label_nhap_so_nguyen.Size = new System.Drawing.Size(319, 17);
            this.label_nhap_so_nguyen.TabIndex = 0;
            this.label_nhap_so_nguyen.Text = "Nhập vào một số có 12 chữ số (tối đa 12 chữ số):";
            this.label_nhap_so_nguyen.Click += new System.EventHandler(this.label_nhap_so_nguyen_Click);
            // 
            // label_ket_qua
            // 
            this.label_ket_qua.AutoSize = true;
            this.label_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ket_qua.Location = new System.Drawing.Point(50, 110);
            this.label_ket_qua.Name = "label_ket_qua";
            this.label_ket_qua.Size = new System.Drawing.Size(61, 17);
            this.label_ket_qua.TabIndex = 1;
            this.label_ket_qua.Text = "Kết quả:";
            // 
            // textBox_nhap_so
            // 
            this.textBox_nhap_so.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nhap_so.Location = new System.Drawing.Point(369, 48);
            this.textBox_nhap_so.Name = "textBox_nhap_so";
            this.textBox_nhap_so.Size = new System.Drawing.Size(200, 23);
            this.textBox_nhap_so.TabIndex = 1;
            // 
            // textBox_ket_qua
            // 
            this.textBox_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ket_qua.Location = new System.Drawing.Point(50, 140);
            this.textBox_ket_qua.Multiline = true;
            this.textBox_ket_qua.Name = "textBox_ket_qua";
            this.textBox_ket_qua.ReadOnly = true;
            this.textBox_ket_qua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ket_qua.Size = new System.Drawing.Size(500, 100);
            this.textBox_ket_qua.TabIndex = 6;
            // 
            // button_doc
            // 
            this.button_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_doc.Location = new System.Drawing.Point(580, 40);
            this.button_doc.Name = "button_doc";
            this.button_doc.Size = new System.Drawing.Size(100, 35);
            this.button_doc.TabIndex = 2;
            this.button_doc.Text = "Đọc";
            this.button_doc.UseVisualStyleBackColor = true;
            this.button_doc.Click += new System.EventHandler(this.button_doc_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(580, 90);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(100, 35);
            this.button_xoa.TabIndex = 3;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_thoat
            // 
            this.button_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thoat.Location = new System.Drawing.Point(580, 140);
            this.button_thoat.Name = "button_thoat";
            this.button_thoat.Size = new System.Drawing.Size(100, 35);
            this.button_thoat.TabIndex = 4;
            this.button_thoat.Text = "Thoát";
            this.button_thoat.UseVisualStyleBackColor = true;
            this.button_thoat.Click += new System.EventHandler(this.button_thoat_Click);
            // 
            // Lab01_Bai04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 280);
            this.Controls.Add(this.button_thoat);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_doc);
            this.Controls.Add(this.textBox_ket_qua);
            this.Controls.Add(this.textBox_nhap_so);
            this.Controls.Add(this.label_ket_qua);
            this.Controls.Add(this.label_nhap_so_nguyen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lab01_Bai04";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 04 - Đọc số lớn";
            this.Load += new System.EventHandler(this.Lab01_Bai04_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nhap_so_nguyen;
        private System.Windows.Forms.Label label_ket_qua;
        private System.Windows.Forms.TextBox textBox_nhap_so;
        private System.Windows.Forms.TextBox textBox_ket_qua;
        private System.Windows.Forms.Button button_doc;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_thoat;
    }
}