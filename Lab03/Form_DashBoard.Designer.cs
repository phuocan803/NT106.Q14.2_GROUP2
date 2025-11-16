using System;
using System.Windows.Forms;

namespace Lab03
{
    partial class Form_DashBoard
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
            this.Lab03_Bai06 = new System.Windows.Forms.Button();
            this.Lab03_Bai05 = new System.Windows.Forms.Button();
            this.Lab03_Bai04 = new System.Windows.Forms.Button();
            this.Lab03_Bai03 = new System.Windows.Forms.Button();
            this.Lab03_Bai02 = new System.Windows.Forms.Button();
            this.Lab03_Bai01 = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lab03_Bai06
            // 
            this.Lab03_Bai06.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab03_Bai06.Location = new System.Drawing.Point(503, 243);
            this.Lab03_Bai06.Name = "Lab03_Bai06";
            this.Lab03_Bai06.Size = new System.Drawing.Size(120, 40);
            this.Lab03_Bai06.TabIndex = 24;
            this.Lab03_Bai06.Text = "Bài 06";
            this.Lab03_Bai06.UseVisualStyleBackColor = true;
            // 
            // Lab03_Bai05
            // 
            this.Lab03_Bai05.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab03_Bai05.Location = new System.Drawing.Point(333, 243);
            this.Lab03_Bai05.Name = "Lab03_Bai05";
            this.Lab03_Bai05.Size = new System.Drawing.Size(120, 40);
            this.Lab03_Bai05.TabIndex = 23;
            this.Lab03_Bai05.Text = "Bài 05";
            this.Lab03_Bai05.UseVisualStyleBackColor = true;
            // 
            // Lab03_Bai04
            // 
            this.Lab03_Bai04.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab03_Bai04.Location = new System.Drawing.Point(163, 243);
            this.Lab03_Bai04.Name = "Lab03_Bai04";
            this.Lab03_Bai04.Size = new System.Drawing.Size(120, 40);
            this.Lab03_Bai04.TabIndex = 22;
            this.Lab03_Bai04.Text = "Bài 04";
            this.Lab03_Bai04.UseVisualStyleBackColor = true;
            // 
            // Lab03_Bai03
            // 
            this.Lab03_Bai03.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab03_Bai03.Location = new System.Drawing.Point(503, 183);
            this.Lab03_Bai03.Name = "Lab03_Bai03";
            this.Lab03_Bai03.Size = new System.Drawing.Size(120, 40);
            this.Lab03_Bai03.TabIndex = 21;
            this.Lab03_Bai03.Text = "Bài 03";
            this.Lab03_Bai03.UseVisualStyleBackColor = true;
            this.Lab03_Bai03.Click += new System.EventHandler(this.Lab03_Bai03_Click);
            // 
            // Lab03_Bai02
            // 
            this.Lab03_Bai02.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab03_Bai02.Location = new System.Drawing.Point(333, 183);
            this.Lab03_Bai02.Name = "Lab03_Bai02";
            this.Lab03_Bai02.Size = new System.Drawing.Size(120, 40);
            this.Lab03_Bai02.TabIndex = 20;
            this.Lab03_Bai02.Text = "Bài 02";
            this.Lab03_Bai02.UseVisualStyleBackColor = true;
            this.Lab03_Bai02.Click += new System.EventHandler(this.Lab03_Bai02_Click);
            // 
            // Lab03_Bai01
            // 
            this.Lab03_Bai01.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab03_Bai01.Location = new System.Drawing.Point(163, 183);
            this.Lab03_Bai01.Name = "Lab03_Bai01";
            this.Lab03_Bai01.Size = new System.Drawing.Size(120, 40);
            this.Lab03_Bai01.TabIndex = 19;
            this.Lab03_Bai01.Text = "Bài 01";
            this.Lab03_Bai01.UseVisualStyleBackColor = true;
            this.Lab03_Bai01.Click += new System.EventHandler(this.Lab03_Bai01_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.Blue;
            this.label_title.Location = new System.Drawing.Point(283, 123);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(181, 26);
            this.label_title.TabIndex = 18;
            this.label_title.Text = "NT106 - LAB 03";
            // 
            // Form_DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 453);
            this.Controls.Add(this.Lab03_Bai06);
            this.Controls.Add(this.Lab03_Bai05);
            this.Controls.Add(this.Lab03_Bai04);
            this.Controls.Add(this.Lab03_Bai03);
            this.Controls.Add(this.Lab03_Bai02);
            this.Controls.Add(this.Lab03_Bai01);
            this.Controls.Add(this.label_title);
            this.Name = "Form_DashBoard";
            this.Text = "Form_DashBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Button Lab03_Bai06;
        private Button Lab03_Bai05;
        private Button Lab03_Bai04;
        private Button Lab03_Bai03;
        private Button Lab03_Bai02;
        private Button Lab03_Bai01;
        private Label label_title;
    }
}

