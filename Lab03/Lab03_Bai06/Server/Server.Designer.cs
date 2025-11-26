namespace Server
{
    partial class Server
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
            button_Listen = new Button();
            richTextBox_Log = new RichTextBox();
            richTextBox_IPAddress = new RichTextBox();
            label_IPAddress = new Label();
            SuspendLayout();
            // 
            // button_Listen
            // 
            button_Listen.Location = new Point(626, 12);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(129, 38);
            button_Listen.TabIndex = 0;
            button_Listen.Text = "Listen";
            button_Listen.UseVisualStyleBackColor = true;
            button_Listen.Click += button_Listen_Click;
            // 
            // richTextBox_Log
            // 
            richTextBox_Log.Location = new Point(12, 68);
            richTextBox_Log.Name = "richTextBox_Log";
            richTextBox_Log.Size = new Size(776, 370);
            richTextBox_Log.TabIndex = 1;
            richTextBox_Log.Text = "";
            richTextBox_Log.TextChanged += richTextBox_Log_TextChanged;
            // 
            // richTextBox_IPAddress
            // 
            richTextBox_IPAddress.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_IPAddress.Location = new Point(190, 20);
            richTextBox_IPAddress.Name = "richTextBox_IPAddress";
            richTextBox_IPAddress.Size = new Size(192, 30);
            richTextBox_IPAddress.TabIndex = 2;
            richTextBox_IPAddress.Text = "";
            // 
            // label_IPAddress
            // 
            label_IPAddress.AutoSize = true;
            label_IPAddress.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_IPAddress.Location = new Point(16, 25);
            label_IPAddress.Name = "label_IPAddress";
            label_IPAddress.Size = new Size(168, 25);
            label_IPAddress.TabIndex = 3;
            label_IPAddress.Text = "Server's IPAddress:";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_IPAddress);
            Controls.Add(richTextBox_IPAddress);
            Controls.Add(richTextBox_Log);
            Controls.Add(button_Listen);
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Listen;
        private RichTextBox richTextBox_Log;
        private RichTextBox richTextBox_IPAddress;
        private Label label_IPAddress;
    }
}
