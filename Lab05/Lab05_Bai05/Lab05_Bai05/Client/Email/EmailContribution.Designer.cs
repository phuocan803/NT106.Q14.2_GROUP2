namespace Lab04_Bai07.Client.Email
{
    partial class EmailContribution
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
            this.label_Email = new System.Windows.Forms.Label();
            this.label_AppPassword = new System.Windows.Forms.Label();
            this.btnFetch = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAppPassword = new System.Windows.Forms.TextBox();
            this.listView_Mail = new System.Windows.Forms.ListView();
            this.Dish = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(21, 35);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(35, 13);
            this.label_Email.TabIndex = 0;
            this.label_Email.Text = "Email:";
            // 
            // label_AppPassword
            // 
            this.label_AppPassword.AutoSize = true;
            this.label_AppPassword.Location = new System.Drawing.Point(21, 62);
            this.label_AppPassword.Name = "label_AppPassword";
            this.label_AppPassword.Size = new System.Drawing.Size(59, 13);
            this.label_AppPassword.TabIndex = 1;
            this.label_AppPassword.Text = "Passworrd:";
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(661, 37);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(113, 38);
            this.btnFetch.TabIndex = 2;
            this.btnFetch.Text = "Tải đóng góp";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(84, 28);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(165, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtAppPassword
            // 
            this.txtAppPassword.Location = new System.Drawing.Point(84, 55);
            this.txtAppPassword.Name = "txtAppPassword";
            this.txtAppPassword.Size = new System.Drawing.Size(165, 20);
            this.txtAppPassword.TabIndex = 4;
            // 
            // listView_Mail
            // 
            this.listView_Mail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Dish,
            this.Sender,
            this.Status});
            this.listView_Mail.FullRowSelect = true;
            this.listView_Mail.GridLines = true;
            this.listView_Mail.HideSelection = false;
            this.listView_Mail.Location = new System.Drawing.Point(12, 100);
            this.listView_Mail.Name = "listView_Mail";
            this.listView_Mail.Size = new System.Drawing.Size(773, 338);
            this.listView_Mail.TabIndex = 5;
            this.listView_Mail.UseCompatibleStateImageBehavior = false;
            this.listView_Mail.SelectedIndexChanged += new System.EventHandler(this.listView_Mail_SelectedIndexChanged);
            // 
            // Dish
            // 
            this.Dish.Text = "Món ăn";
            this.Dish.Width = 240;
            // 
            // Sender
            // 
            this.Sender.Text = "Người gửi";
            this.Sender.Width = 300;
            // 
            // Status
            // 
            this.Status.Text = "Trạng thái";
            this.Status.Width = 250;
            // 
            // EmailContribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView_Mail);
            this.Controls.Add(this.txtAppPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.label_AppPassword);
            this.Controls.Add(this.label_Email);
            this.Name = "EmailContribution";
            this.Text = "EmailContribution";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_AppPassword;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAppPassword;
        private System.Windows.Forms.ListView listView_Mail;
        private System.Windows.Forms.ColumnHeader Dish;
        private System.Windows.Forms.ColumnHeader Sender;
        private System.Windows.Forms.ColumnHeader Status;
    }
}