namespace Lab04_Bai07.Client.AddFood
{
    partial class AddFood
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
            this.label_Title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_Food_Name = new System.Windows.Forms.Label();
            this.textBox_Food_Name = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.label_Price = new System.Windows.Forms.Label();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label_Address = new System.Windows.Forms.Label();
            this.textBox_Image = new System.Windows.Forms.TextBox();
            this.label_Image = new System.Windows.Forms.Label();
            this.label_Description = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Calibri", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_Title.Location = new System.Drawing.Point(116, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(219, 39);
            this.label_Title.TabIndex = 3;
            this.label_Title.Text = "Hôm nay ăn gì?";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Description);
            this.groupBox1.Controls.Add(this.label_Description);
            this.groupBox1.Controls.Add(this.label_Image);
            this.groupBox1.Controls.Add(this.textBox_Image);
            this.groupBox1.Controls.Add(this.label_Address);
            this.groupBox1.Controls.Add(this.textBox_Address);
            this.groupBox1.Controls.Add(this.label_Price);
            this.groupBox1.Controls.Add(this.textBox_Price);
            this.groupBox1.Controls.Add(this.textBox_Food_Name);
            this.groupBox1.Controls.Add(this.label_Food_Name);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 318);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm món ăn";
            // 
            // label_Food_Name
            // 
            this.label_Food_Name.AutoSize = true;
            this.label_Food_Name.Location = new System.Drawing.Point(6, 49);
            this.label_Food_Name.Name = "label_Food_Name";
            this.label_Food_Name.Size = new System.Drawing.Size(79, 18);
            this.label_Food_Name.TabIndex = 0;
            this.label_Food_Name.Text = "Tên món ăn";
            // 
            // textBox_Food_Name
            // 
            this.textBox_Food_Name.Location = new System.Drawing.Point(139, 46);
            this.textBox_Food_Name.Name = "textBox_Food_Name";
            this.textBox_Food_Name.Size = new System.Drawing.Size(278, 26);
            this.textBox_Food_Name.TabIndex = 1;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(139, 78);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(278, 26);
            this.textBox_Price.TabIndex = 2;
            // 
            // label_Price
            // 
            this.label_Price.AutoSize = true;
            this.label_Price.Location = new System.Drawing.Point(6, 81);
            this.label_Price.Name = "label_Price";
            this.label_Price.Size = new System.Drawing.Size(28, 18);
            this.label_Price.TabIndex = 3;
            this.label_Price.Text = "Giá";
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(139, 110);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(278, 26);
            this.textBox_Address.TabIndex = 4;
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Location = new System.Drawing.Point(6, 113);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(48, 18);
            this.label_Address.TabIndex = 5;
            this.label_Address.Text = "Địa chỉ";
            // 
            // textBox_Image
            // 
            this.textBox_Image.Location = new System.Drawing.Point(139, 142);
            this.textBox_Image.Name = "textBox_Image";
            this.textBox_Image.Size = new System.Drawing.Size(278, 26);
            this.textBox_Image.TabIndex = 6;
            // 
            // label_Image
            // 
            this.label_Image.AutoSize = true;
            this.label_Image.Location = new System.Drawing.Point(6, 145);
            this.label_Image.Name = "label_Image";
            this.label_Image.Size = new System.Drawing.Size(62, 18);
            this.label_Image.TabIndex = 7;
            this.label_Image.Text = "Hình ảnh";
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Location = new System.Drawing.Point(6, 180);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(43, 18);
            this.label_Description.TabIndex = 8;
            this.label_Description.Text = "Mô tả";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(139, 177);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(278, 134);
            this.textBox_Description.TabIndex = 9;
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Location = new System.Drawing.Point(349, 375);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(86, 28);
            this.button_Add.TabIndex = 5;
            this.button_Add.Text = "Thêm";
            this.button_Add.UseVisualStyleBackColor = true;
            // 
            // button_Clear
            // 
            this.button_Clear.Font = new System.Drawing.Font("Calibri", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Clear.Location = new System.Drawing.Point(257, 375);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(86, 28);
            this.button_Clear.TabIndex = 6;
            this.button_Clear.Text = "Xóa";
            this.button_Clear.UseVisualStyleBackColor = true;
            // 
            // AddFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 408);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_Title);
            this.Name = "AddFood";
            this.Text = "AddFood";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label_Price;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.TextBox textBox_Food_Name;
        private System.Windows.Forms.Label label_Food_Name;
        private System.Windows.Forms.Label label_Image;
        private System.Windows.Forms.TextBox textBox_Image;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Clear;
    }
}