namespace NT106_Lab02
{
    partial class Lab02_Bai02
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
            this.button_docfile = new System.Windows.Forms.Button();
            this.richtextbox_noidung = new System.Windows.Forms.RichTextBox();
            this.textbox_tenfile = new System.Windows.Forms.TextBox();
            this.textbox_kichco = new System.Windows.Forms.TextBox();
            this.textbox_url = new System.Windows.Forms.TextBox();
            this.textbox_sodong = new System.Windows.Forms.TextBox();
            this.textbox_sotu = new System.Windows.Forms.TextBox();
            this.textbox_sokytu = new System.Windows.Forms.TextBox();
            this.label_tenfile = new System.Windows.Forms.Label();
            this.label_kichco = new System.Windows.Forms.Label();
            this.label_url = new System.Windows.Forms.Label();
            this.label_sodong = new System.Windows.Forms.Label();
            this.label_sotu = new System.Windows.Forms.Label();
            this.label_sokytu = new System.Windows.Forms.Label();
            this.label_tieude = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_docfile
            // 
            this.button_docfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_docfile.Location = new System.Drawing.Point(650, 50);
            this.button_docfile.Name = "button_docfile";
            this.button_docfile.Size = new System.Drawing.Size(120, 35);
            this.button_docfile.TabIndex = 0;
            this.button_docfile.Text = "Đọc file";
            this.button_docfile.UseVisualStyleBackColor = true;
            this.button_docfile.Click += new System.EventHandler(this.button_docfile_Click);
            // 
            // richtextbox_noidung
            // 
            this.richtextbox_noidung.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtextbox_noidung.Location = new System.Drawing.Point(12, 250);
            this.richtextbox_noidung.Name = "richtextbox_noidung";
            this.richtextbox_noidung.ReadOnly = true;
            this.richtextbox_noidung.Size = new System.Drawing.Size(758, 280);
            this.richtextbox_noidung.TabIndex = 1;
            this.richtextbox_noidung.Text = "";
            // 
            // textbox_tenfile
            // 
            this.textbox_tenfile.Location = new System.Drawing.Point(120, 60);
            this.textbox_tenfile.Name = "textbox_tenfile";
            this.textbox_tenfile.ReadOnly = true;
            this.textbox_tenfile.Size = new System.Drawing.Size(500, 20);
            this.textbox_tenfile.TabIndex = 2;
            // 
            // textbox_kichco
            // 
            this.textbox_kichco.Location = new System.Drawing.Point(120, 95);
            this.textbox_kichco.Name = "textbox_kichco";
            this.textbox_kichco.ReadOnly = true;
            this.textbox_kichco.Size = new System.Drawing.Size(200, 20);
            this.textbox_kichco.TabIndex = 3;
            // 
            // textbox_url
            // 
            this.textbox_url.Location = new System.Drawing.Point(120, 130);
            this.textbox_url.Name = "textbox_url";
            this.textbox_url.ReadOnly = true;
            this.textbox_url.Size = new System.Drawing.Size(650, 20);
            this.textbox_url.TabIndex = 4;
            // 
            // textbox_sodong
            // 
            this.textbox_sodong.Location = new System.Drawing.Point(120, 165);
            this.textbox_sodong.Name = "textbox_sodong";
            this.textbox_sodong.ReadOnly = true;
            this.textbox_sodong.Size = new System.Drawing.Size(150, 20);
            this.textbox_sodong.TabIndex = 5;
            // 
            // textbox_sotu
            // 
            this.textbox_sotu.Location = new System.Drawing.Point(340, 165);
            this.textbox_sotu.Name = "textbox_sotu";
            this.textbox_sotu.ReadOnly = true;
            this.textbox_sotu.Size = new System.Drawing.Size(150, 20);
            this.textbox_sotu.TabIndex = 6;
            // 
            // textbox_sokytu
            // 
            this.textbox_sokytu.Location = new System.Drawing.Point(570, 165);
            this.textbox_sokytu.Name = "textbox_sokytu";
            this.textbox_sokytu.ReadOnly = true;
            this.textbox_sokytu.Size = new System.Drawing.Size(150, 20);
            this.textbox_sokytu.TabIndex = 7;
            // 
            // label_tenfile
            // 
            this.label_tenfile.AutoSize = true;
            this.label_tenfile.Location = new System.Drawing.Point(12, 63);
            this.label_tenfile.Name = "label_tenfile";
            this.label_tenfile.Size = new System.Drawing.Size(48, 13);
            this.label_tenfile.TabIndex = 8;
            this.label_tenfile.Text = "Tên file:";
            // 
            // label_kichco
            // 
            this.label_kichco.AutoSize = true;
            this.label_kichco.Location = new System.Drawing.Point(12, 98);
            this.label_kichco.Name = "label_kichco";
            this.label_kichco.Size = new System.Drawing.Size(50, 13);
            this.label_kichco.TabIndex = 9;
            this.label_kichco.Text = "Kích cỡ:";
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(12, 133);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(32, 13);
            this.label_url.TabIndex = 10;
            this.label_url.Text = "URL:";
            // 
            // label_sodong
            // 
            this.label_sodong.AutoSize = true;
            this.label_sodong.Location = new System.Drawing.Point(12, 168);
            this.label_sodong.Name = "label_sodong";
            this.label_sodong.Size = new System.Drawing.Size(53, 13);
            this.label_sodong.TabIndex = 11;
            this.label_sodong.Text = "Số dòng:";
            // 
            // label_sotu
            // 
            this.label_sotu.AutoSize = true;
            this.label_sotu.Location = new System.Drawing.Point(285, 168);
            this.label_sotu.Name = "label_sotu";
            this.label_sotu.Size = new System.Drawing.Size(40, 13);
            this.label_sotu.TabIndex = 12;
            this.label_sotu.Text = "Số từ:";
            // 
            // label_sokytu
            // 
            this.label_sokytu.AutoSize = true;
            this.label_sokytu.Location = new System.Drawing.Point(510, 168);
            this.label_sokytu.Name = "label_sokytu";
            this.label_sokytu.Size = new System.Drawing.Size(54, 13);
            this.label_sokytu.TabIndex = 13;
            this.label_sokytu.Text = "Số ký tự:";
            // 
            // label_tieude
            // 
            this.label_tieude.AutoSize = true;
            this.label_tieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tieude.Location = new System.Drawing.Point(12, 15);
            this.label_tieude.Name = "label_tieude";
            this.label_tieude.Size = new System.Drawing.Size(253, 20);
            this.label_tieude.TabIndex = 14;
            this.label_tieude.Text = "Bài 02 - Đọc thông tin file .txt";
            // 
            // Lab02_Bai02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.label_tieude);
            this.Controls.Add(this.label_sokytu);
            this.Controls.Add(this.label_sotu);
            this.Controls.Add(this.label_sodong);
            this.Controls.Add(this.label_url);
            this.Controls.Add(this.label_kichco);
            this.Controls.Add(this.label_tenfile);
            this.Controls.Add(this.textbox_sokytu);
            this.Controls.Add(this.textbox_sotu);
            this.Controls.Add(this.textbox_sodong);
            this.Controls.Add(this.textbox_url);
            this.Controls.Add(this.textbox_kichco);
            this.Controls.Add(this.textbox_tenfile);
            this.Controls.Add(this.richtextbox_noidung);
            this.Controls.Add(this.button_docfile);
            this.Name = "Lab02_Bai02";
            this.Text = "Lab02_Bai02 - Đọc thông tin file";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_docfile;
        private System.Windows.Forms.RichTextBox richtextbox_noidung;
        private System.Windows.Forms.TextBox textbox_tenfile;
        private System.Windows.Forms.TextBox textbox_kichco;
        private System.Windows.Forms.TextBox textbox_url;
        private System.Windows.Forms.TextBox textbox_sodong;
        private System.Windows.Forms.TextBox textbox_sotu;
        private System.Windows.Forms.TextBox textbox_sokytu;
        private System.Windows.Forms.Label label_tenfile;
        private System.Windows.Forms.Label label_kichco;
        private System.Windows.Forms.Label label_url;
        private System.Windows.Forms.Label label_sodong;
        private System.Windows.Forms.Label label_sotu;
        private System.Windows.Forms.Label label_sokytu;
        private System.Windows.Forms.Label label_tieude;
    }
}