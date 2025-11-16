using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab02_Bai6
{
    partial class Bai06
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox_DanhSachMonAn = new GroupBox();
            listView_MonAn = new ListView();
            groupBox_DanhSachNCC = new GroupBox();
            listView_NCC = new ListView();
            button_TimMonAn = new Button();
            button_Thoat = new Button();
            pictureBox_HinhAnh = new PictureBox();
            label_TenMonAn = new Label();
            label_TenNCC = new Label();
            textBox_TenMonAn = new TextBox();
            textBox_TenNCC = new TextBox();
            groupBox_DanhSachMonAn.SuspendLayout();
            groupBox_DanhSachNCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_HinhAnh).BeginInit();
            SuspendLayout();
            // 
            // groupBox_DanhSachMonAn
            // 
            groupBox_DanhSachMonAn.Controls.Add(listView_MonAn);
            groupBox_DanhSachMonAn.Location = new Point(12, 12);
            groupBox_DanhSachMonAn.Name = "groupBox_DanhSachMonAn";
            groupBox_DanhSachMonAn.Size = new Size(461, 233);
            groupBox_DanhSachMonAn.TabIndex = 0;
            groupBox_DanhSachMonAn.TabStop = false;
            groupBox_DanhSachMonAn.Text = "Danh sách món ăn";
            // 
            // listView_MonAn
            // 
            listView_MonAn.Location = new Point(6, 22);
            listView_MonAn.Name = "listView_MonAn";
            listView_MonAn.Size = new Size(449, 205);
            listView_MonAn.TabIndex = 0;
            listView_MonAn.UseCompatibleStateImageBehavior = false;
            listView_MonAn.SelectedIndexChanged += listView_MonAn_SelectedIndexChanged;
            // 
            // groupBox_DanhSachNCC
            // 
            groupBox_DanhSachNCC.Controls.Add(listView_NCC);
            groupBox_DanhSachNCC.Location = new Point(519, 12);
            groupBox_DanhSachNCC.Name = "groupBox_DanhSachNCC";
            groupBox_DanhSachNCC.Size = new Size(349, 233);
            groupBox_DanhSachNCC.TabIndex = 1;
            groupBox_DanhSachNCC.TabStop = false;
            groupBox_DanhSachNCC.Text = "Danh sách người cung cấp";
            // 
            // listView_NCC
            // 
            listView_NCC.Location = new Point(6, 22);
            listView_NCC.Name = "listView_NCC";
            listView_NCC.Size = new Size(337, 205);
            listView_NCC.TabIndex = 0;
            listView_NCC.UseCompatibleStateImageBehavior = false;
            // 
            // button_TimMonAn
            // 
            button_TimMonAn.Location = new Point(59, 277);
            button_TimMonAn.Name = "button_TimMonAn";
            button_TimMonAn.Size = new Size(99, 50);
            button_TimMonAn.TabIndex = 2;
            button_TimMonAn.Text = "Tìm món ăn";
            button_TimMonAn.UseVisualStyleBackColor = true;
            button_TimMonAn.Click += button_TimMonAn_Click;
            // 
            // button_Thoat
            // 
            button_Thoat.Location = new Point(59, 398);
            button_Thoat.Name = "button_Thoat";
            button_Thoat.Size = new Size(99, 50);
            button_Thoat.TabIndex = 3;
            button_Thoat.Text = "Thoát";
            button_Thoat.UseVisualStyleBackColor = true;
            button_Thoat.Click += button_Thoat_Click;
            // 
            // pictureBox_HinhAnh
            // 
            pictureBox_HinhAnh.Location = new Point(302, 295);
            pictureBox_HinhAnh.Name = "pictureBox_HinhAnh";
            pictureBox_HinhAnh.Size = new Size(302, 161);
            pictureBox_HinhAnh.TabIndex = 4;
            pictureBox_HinhAnh.TabStop = false;
            // 
            // label_TenMonAn
            // 
            label_TenMonAn.AutoSize = true;
            label_TenMonAn.Location = new Point(693, 295);
            label_TenMonAn.Name = "label_TenMonAn";
            label_TenMonAn.Size = new Size(70, 15);
            label_TenMonAn.TabIndex = 5;
            label_TenMonAn.Text = "Tên món ăn";
            // 
            // label_TenNCC
            // 
            label_TenNCC.AutoSize = true;
            label_TenNCC.Location = new Point(693, 379);
            label_TenNCC.Name = "label_TenNCC";
            label_TenNCC.Size = new Size(112, 15);
            label_TenNCC.TabIndex = 6;
            label_TenNCC.Text = "Tên người cung cấp";
            // 
            // textBox_TenMonAn
            // 
            textBox_TenMonAn.Location = new Point(693, 313);
            textBox_TenMonAn.Name = "textBox_TenMonAn";
            textBox_TenMonAn.Size = new Size(169, 23);
            textBox_TenMonAn.TabIndex = 7;
            // 
            // textBox_TenNCC
            // 
            textBox_TenNCC.Location = new Point(693, 398);
            textBox_TenNCC.Name = "textBox_TenNCC";
            textBox_TenNCC.Size = new Size(175, 23);
            textBox_TenNCC.TabIndex = 8;
            // 
            // Bai06
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 498);
            Controls.Add(textBox_TenNCC);
            Controls.Add(textBox_TenMonAn);
            Controls.Add(label_TenNCC);
            Controls.Add(label_TenMonAn);
            Controls.Add(pictureBox_HinhAnh);
            Controls.Add(button_Thoat);
            Controls.Add(button_TimMonAn);
            Controls.Add(groupBox_DanhSachNCC);
            Controls.Add(groupBox_DanhSachMonAn);
            Name = "Bai06";
            Text = "Bai06";
            Load += Form1_Load;
            groupBox_DanhSachMonAn.ResumeLayout(false);
            groupBox_DanhSachNCC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_HinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox_DanhSachMonAn;
        private ListView listView_MonAn;
        private GroupBox groupBox_DanhSachNCC;
        private ListView listView_NCC;
        private Button button_TimMonAn;
        private Button button_Thoat;
        private PictureBox pictureBox_HinhAnh;
        private Label label_TenMonAn;
        private Label label_TenNCC;
        private TextBox textBox_TenMonAn;
        private TextBox textBox_TenNCC;
    }
}