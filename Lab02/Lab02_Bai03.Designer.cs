namespace NT106_Lab02
{
    partial class Lab02_Bai03
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
            this.label_tieude = new System.Windows.Forms.Label();
            this.button_doc_tinhtoan = new System.Windows.Forms.Button();
            this.richtextbox_input = new System.Windows.Forms.RichTextBox();
            this.richtextbox_output = new System.Windows.Forms.RichTextBox();
            this.label_input = new System.Windows.Forms.Label();
            this.label_output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_tieude
            // 
            this.label_tieude.AutoSize = true;
            this.label_tieude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tieude.Location = new System.Drawing.Point(12, 15);
            this.label_tieude.Name = "label_tieude";
            this.label_tieude.Size = new System.Drawing.Size(299, 20);
            this.label_tieude.TabIndex = 0;
            this.label_tieude.Text = "Bài 03 - Đọc và Ghi file và tính toán";
            // 
            // button_doc_tinhtoan
            // 
            this.button_doc_tinhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_doc_tinhtoan.Location = new System.Drawing.Point(320, 50);
            this.button_doc_tinhtoan.Name = "button_doc_tinhtoan";
            this.button_doc_tinhtoan.Size = new System.Drawing.Size(150, 35);
            this.button_doc_tinhtoan.TabIndex = 1;
            this.button_doc_tinhtoan.Text = "Đọc và Tính toán";
            this.button_doc_tinhtoan.UseVisualStyleBackColor = true;
            this.button_doc_tinhtoan.Click += new System.EventHandler(this.button_doc_tinhtoan_Click);
            // 
            // richtextbox_input
            // 
            this.richtextbox_input.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtextbox_input.Location = new System.Drawing.Point(12, 115);
            this.richtextbox_input.Name = "richtextbox_input";
            this.richtextbox_input.ReadOnly = true;
            this.richtextbox_input.Size = new System.Drawing.Size(360, 350);
            this.richtextbox_input.TabIndex = 2;
            this.richtextbox_input.Text = "";
            // 
            // richtextbox_output
            // 
            this.richtextbox_output.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtextbox_output.Location = new System.Drawing.Point(390, 115);
            this.richtextbox_output.Name = "richtextbox_output";
            this.richtextbox_output.ReadOnly = true;
            this.richtextbox_output.Size = new System.Drawing.Size(400, 350);
            this.richtextbox_output.TabIndex = 3;
            this.richtextbox_output.Text = "";
            // 
            // label_input
            // 
            this.label_input.AutoSize = true;
            this.label_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_input.Location = new System.Drawing.Point(12, 95);
            this.label_input.Name = "label_input";
            this.label_input.Size = new System.Drawing.Size(157, 17);
            this.label_input.TabIndex = 4;
            this.label_input.Text = "Input (input3.txt):";
            // 
            // label_output
            // 
            this.label_output.AutoSize = true;
            this.label_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_output.Location = new System.Drawing.Point(390, 95);
            this.label_output.Name = "label_output";
            this.label_output.Size = new System.Drawing.Size(177, 17);
            this.label_output.TabIndex = 5;
            this.label_output.Text = "Output (output3.txt):";
            // 
            // Lab02_Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 481);
            this.Controls.Add(this.label_output);
            this.Controls.Add(this.label_input);
            this.Controls.Add(this.richtextbox_output);
            this.Controls.Add(this.richtextbox_input);
            this.Controls.Add(this.button_doc_tinhtoan);
            this.Controls.Add(this.label_tieude);
            this.Name = "Lab02_Bai03";
            this.Text = "Lab02_Bai03 - Đọc và Ghi file và tính toán";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_tieude;
        private System.Windows.Forms.Button button_doc_tinhtoan;
        private System.Windows.Forms.RichTextBox richtextbox_input;
        private System.Windows.Forms.RichTextBox richtextbox_output;
        private System.Windows.Forms.Label label_input;
        private System.Windows.Forms.Label label_output;
    }
}