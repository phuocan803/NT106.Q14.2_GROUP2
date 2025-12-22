namespace Lab05
{
    partial class Lab05_Bai01
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
            btnSend = new Button();
            txtFrom = new TextBox();
            txtTo = new TextBox();
            txtSubject = new TextBox();
            txtBody = new TextBox();
            lblFrom = new Label();
            lblTo = new Label();
            lblSubject = new Label();
            lblBody = new Label();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.Location = new Point(26, 22);
            btnSend.Margin = new Padding(3, 2, 3, 2);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(66, 48);
            btnSend.TabIndex = 0;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(158, 22);
            txtFrom.Margin = new Padding(3, 2, 3, 2);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(263, 23);
            txtFrom.TabIndex = 1;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(158, 52);
            txtTo.Margin = new Padding(3, 2, 3, 2);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(263, 23);
            txtTo.TabIndex = 2;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(105, 91);
            txtSubject.Margin = new Padding(3, 2, 3, 2);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(316, 23);
            txtSubject.TabIndex = 3;
            // 
            // txtBody
            // 
            txtBody.Location = new Point(105, 121);
            txtBody.Margin = new Padding(3, 2, 3, 2);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(316, 121);
            txtBody.TabIndex = 4;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(105, 25);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(38, 15);
            lblFrom.TabIndex = 5;
            lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(105, 55);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(23, 15);
            lblTo.TabIndex = 6;
            lblTo.Text = "To:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(26, 94);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(49, 15);
            lblSubject.TabIndex = 7;
            lblSubject.Text = "Subject:";
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Location = new Point(26, 124);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(37, 15);
            lblBody.TabIndex = 8;
            lblBody.Text = "Body:";
            // 
            // Lab05_Bai01
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 262);
            Controls.Add(lblBody);
            Controls.Add(lblSubject);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(txtBody);
            Controls.Add(txtSubject);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Controls.Add(btnSend);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Lab05_Bai01";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblBody;
    }
}
