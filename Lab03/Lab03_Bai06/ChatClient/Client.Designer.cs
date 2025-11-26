namespace ChatClient
{
    partial class Client
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
            label_Participants = new Label();
            textBox_YourName = new TextBox();
            textBox_Message = new TextBox();
            label_YourName = new Label();
            label_Message = new Label();
            button_Connect = new Button();
            button_Send = new Button();
            comboBox_Recipients = new ComboBox();
            richTextBox_Message = new RichTextBox();
            listBox_Participants = new ListBox();
            textBox_IPAddress = new TextBox();
            label_IPAddress = new Label();
            SuspendLayout();
            // 
            // label_Participants
            // 
            label_Participants.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Participants.Location = new Point(659, 15);
            label_Participants.Name = "label_Participants";
            label_Participants.Size = new Size(96, 24);
            label_Participants.TabIndex = 2;
            label_Participants.Text = "Participants";
            // 
            // textBox_YourName
            // 
            textBox_YourName.Location = new Point(12, 357);
            textBox_YourName.Name = "textBox_YourName";
            textBox_YourName.Size = new Size(226, 23);
            textBox_YourName.TabIndex = 3;
            // 
            // textBox_Message
            // 
            textBox_Message.Location = new Point(12, 415);
            textBox_Message.Name = "textBox_Message";
            textBox_Message.Size = new Size(514, 23);
            textBox_Message.TabIndex = 4;
            // 
            // label_YourName
            // 
            label_YourName.AutoSize = true;
            label_YourName.Location = new Point(11, 337);
            label_YourName.Name = "label_YourName";
            label_YourName.Size = new Size(63, 15);
            label_YourName.TabIndex = 5;
            label_YourName.Text = "YourName";
            // 
            // label_Message
            // 
            label_Message.AutoSize = true;
            label_Message.Location = new Point(14, 397);
            label_Message.Name = "label_Message";
            label_Message.Size = new Size(53, 15);
            label_Message.TabIndex = 6;
            label_Message.Text = "Message";
            // 
            // button_Connect
            // 
            button_Connect.Location = new Point(545, 385);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(75, 23);
            button_Connect.TabIndex = 7;
            button_Connect.Text = "Connect";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // button_Send
            // 
            button_Send.Location = new Point(545, 414);
            button_Send.Name = "button_Send";
            button_Send.Size = new Size(75, 23);
            button_Send.TabIndex = 8;
            button_Send.Text = "Send";
            button_Send.UseVisualStyleBackColor = true;
            button_Send.Click += button_Send_Click;
            // 
            // comboBox_Recipients
            // 
            comboBox_Recipients.FormattingEnabled = true;
            comboBox_Recipients.Location = new Point(244, 357);
            comboBox_Recipients.Name = "comboBox_Recipients";
            comboBox_Recipients.Size = new Size(95, 23);
            comboBox_Recipients.TabIndex = 9;
            comboBox_Recipients.SelectedIndexChanged += comboBox_Recipients_SelectedIndexChanged;
            // 
            // richTextBox_Message
            // 
            richTextBox_Message.Location = new Point(12, 23);
            richTextBox_Message.Name = "richTextBox_Message";
            richTextBox_Message.Size = new Size(608, 308);
            richTextBox_Message.TabIndex = 10;
            richTextBox_Message.Text = "";
            richTextBox_Message.TextChanged += richTextBox_Message_TextChanged;
            // 
            // listBox_Participants
            // 
            listBox_Participants.FormattingEnabled = true;
            listBox_Participants.ItemHeight = 15;
            listBox_Participants.Location = new Point(639, 42);
            listBox_Participants.Name = "listBox_Participants";
            listBox_Participants.Size = new Size(144, 394);
            listBox_Participants.TabIndex = 11;
            // 
            // textBox_IPAddress
            // 
            textBox_IPAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_IPAddress.Location = new Point(467, 355);
            textBox_IPAddress.Name = "textBox_IPAddress";
            textBox_IPAddress.Size = new Size(153, 29);
            textBox_IPAddress.TabIndex = 12;
            // 
            // label_IPAddress
            // 
            label_IPAddress.AutoSize = true;
            label_IPAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_IPAddress.Location = new Point(378, 361);
            label_IPAddress.Name = "label_IPAddress";
            label_IPAddress.Size = new Size(86, 21);
            label_IPAddress.TabIndex = 13;
            label_IPAddress.Text = "Server's IP:";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_IPAddress);
            Controls.Add(textBox_IPAddress);
            Controls.Add(listBox_Participants);
            Controls.Add(richTextBox_Message);
            Controls.Add(comboBox_Recipients);
            Controls.Add(button_Send);
            Controls.Add(button_Connect);
            Controls.Add(label_Message);
            Controls.Add(label_YourName);
            Controls.Add(textBox_Message);
            Controls.Add(textBox_YourName);
            Controls.Add(label_Participants);
            Name = "Client";
            Text = "Client";
            FormClosing += Client_FormClosing;
            Load += Client_Load;
            DoubleClick += button_Send_Click;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label label_Participants;
        private TextBox textBox_YourName;
        private TextBox textBox_Message;
        private Label label_YourName;
        private Label label_Message;
        private Button button_Connect;
        private Button button_Send;
        private ComboBox comboBox_Recipients;
        private RichTextBox richTextBox_Message;
        private ListBox listBox_Participants;
        private TextBox textBox_IPAddress;
        private Label label_IPAddress;
    }
}
