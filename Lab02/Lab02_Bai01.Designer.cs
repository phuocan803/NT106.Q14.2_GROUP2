namespace NT106_Lab02
{
    partial class Lab02_Bai01
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
            this.richtextbox_noidung = new System.Windows.Forms.RichTextBox();
            this.button_doc = new System.Windows.Forms.Button();
            this.button_ghi = new System.Windows.Forms.Button();
            this.label_tieu_de = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richtextbox_noidung
            // 
            this.richtextbox_noidung.Location = new System.Drawing.Point(12, 50);
            this.richtextbox_noidung.Name = "richtextbox_noidung";
            this.richtextbox_noidung.Size = new System.Drawing.Size(776, 350);
            this.richtextbox_noidung.TabIndex = 0;
            this.richtextbox_noidung.Text = "";
            // 
            // button_doc
            // 
            this.button_doc.Location = new System.Drawing.Point(12, 415);
            this.button_doc.Name = "button_doc";
            this.button_doc.Size = new System.Drawing.Size(120, 30);
            this.button_doc.TabIndex = 1;
            this.button_doc.Text = "Đọc file";
            this.button_doc.UseVisualStyleBackColor = true;
            this.button_doc.Click += new System.EventHandler(this.button_doc_Click);
            // 
            // button_ghi
            // 
            this.button_ghi.Location = new System.Drawing.Point(150, 415);
            this.button_ghi.Name = "button_ghi";
            this.button_ghi.Size = new System.Drawing.Size(120, 30);
            this.button_ghi.TabIndex = 2;
            this.button_ghi.Text = "Ghi file";
            this.button_ghi.UseVisualStyleBackColor = true;
            this.button_ghi.Click += new System.EventHandler(this.button_ghi_Click);
            // 
            // label_tieu_de
            // 
            this.label_tieu_de.AutoSize = true;
            this.label_tieu_de.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tieu_de.Location = new System.Drawing.Point(12, 15);
            this.label_tieu_de.Name = "label_tieu_de";
            this.label_tieu_de.Size = new System.Drawing.Size(193, 20);
            this.label_tieu_de.TabIndex = 3;
            this.label_tieu_de.Text = "Bài 01 - Ghi và Đọc file";
            // 
            // Lab02_Bai01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.label_tieu_de);
            this.Controls.Add(this.button_ghi);
            this.Controls.Add(this.button_doc);
            this.Controls.Add(this.richtextbox_noidung);
            this.Name = "Lab02_Bai01";
            this.Text = "Lab02_Bai01 - Ghi và Đọc file";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox richtextbox_noidung;
        private System.Windows.Forms.Button button_doc;
        private System.Windows.Forms.Button button_ghi;
        private System.Windows.Forms.Label label_tieu_de;
    }
}