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
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox_Log);
            Controls.Add(button_Listen);
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button_Listen;
        private RichTextBox richTextBox_Log;
    }
}
