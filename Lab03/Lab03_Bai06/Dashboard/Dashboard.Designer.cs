namespace Dashboard
{
    partial class Dashboard
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
            button_Server = new Button();
            button_Client = new Button();
            SuspendLayout();
            // 
            // button_Server
            // 
            button_Server.Font = new Font("Segoe UI", 12F);
            button_Server.Location = new Point(76, 51);
            button_Server.Name = "button_Server";
            button_Server.Size = new Size(127, 40);
            button_Server.TabIndex = 0;
            button_Server.Text = "TCP Server";
            button_Server.UseVisualStyleBackColor = true;
            button_Server.Click += button_Server_Click;
            // 
            // button_Client
            // 
            button_Client.Font = new Font("Segoe UI", 12F);
            button_Client.Location = new Point(321, 51);
            button_Client.Name = "button_Client";
            button_Client.Size = new Size(127, 40);
            button_Client.TabIndex = 1;
            button_Client.Text = "TCP Client";
            button_Client.UseVisualStyleBackColor = true;
            button_Client.Click += button_Client_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 136);
            Controls.Add(button_Client);
            Controls.Add(button_Server);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button_Server;
        private Button button_Client;
    }
}
