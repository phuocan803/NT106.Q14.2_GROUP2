namespace NT106_Lab01
{
    partial class Lab01_Bai07
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label_data = new System.Windows.Forms.Label();
            this.button_xem = new System.Windows.Forms.Button();
            this.textBox_ket_qua = new System.Windows.Forms.TextBox();
            this.label_ket_qua = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(300, 120);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label_data
            // 
            this.label_data.AutoSize = true;
            this.label_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_data.Location = new System.Drawing.Point(137, 122);
            this.label_data.Name = "label_data";
            this.label_data.Size = new System.Drawing.Size(155, 17);
            this.label_data.TabIndex = 1;
            this.label_data.Text = "Ngày Tháng Năm Sinh:";
            // 
            // button_xem
            // 
            this.button_xem.BackColor = System.Drawing.Color.LavenderBlush;
            this.button_xem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xem.Location = new System.Drawing.Point(300, 170);
            this.button_xem.Name = "button_xem";
            this.button_xem.Size = new System.Drawing.Size(200, 35);
            this.button_xem.TabIndex = 2;
            this.button_xem.Text = "Xem Cung Hoàng Đạo";
            this.button_xem.UseVisualStyleBackColor = false;
            this.button_xem.Click += new System.EventHandler(this.button_xem_Click);
            // 
            // textBox_ket_qua
            // 
            this.textBox_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ket_qua.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox_ket_qua.Location = new System.Drawing.Point(300, 250);
            this.textBox_ket_qua.Name = "textBox_ket_qua";
            this.textBox_ket_qua.ReadOnly = true;
            this.textBox_ket_qua.Size = new System.Drawing.Size(200, 26);
            this.textBox_ket_qua.TabIndex = 3;
            this.textBox_ket_qua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_ket_qua
            // 
            this.label_ket_qua.AutoSize = true;
            this.label_ket_qua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ket_qua.Location = new System.Drawing.Point(150, 253);
            this.label_ket_qua.Name = "label_ket_qua";
            this.label_ket_qua.Size = new System.Drawing.Size(117, 17);
            this.label_ket_qua.TabIndex = 4;
            this.label_ket_qua.Text = "Cung hoàng đạo:";
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_title.Location = new System.Drawing.Point(250, 50);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(343, 26);
            this.label_title.TabIndex = 5;
            this.label_title.Text = "TRA CỨU CUNG HOÀNG ĐẠO";
            // 
            // Lab01_Bai07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_ket_qua);
            this.Controls.Add(this.textBox_ket_qua);
            this.Controls.Add(this.button_xem);
            this.Controls.Add(this.label_data);
            this.Controls.Add(this.dateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Lab01_Bai07";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab01_Bai07";
            this.Load += new System.EventHandler(this.Lab01_Bai07_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label_data;
        private System.Windows.Forms.Button button_xem;
        private System.Windows.Forms.TextBox textBox_ket_qua;
        private System.Windows.Forms.Label label_ket_qua;
        private System.Windows.Forms.Label label_title;
    }
}