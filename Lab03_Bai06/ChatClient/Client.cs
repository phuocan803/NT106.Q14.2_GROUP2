using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private string userName;
        public Client()
        {
            InitializeComponent();
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            string recipient = string.IsNullOrWhiteSpace(comboBox_Recipients.Text) ? "ALL" : comboBox_Recipients.Text;
            string text = textBox_Message.Text;
            if (string.IsNullOrWhiteSpace(text)) return;

            string msg = $"{userName}|{recipient}|{text}";
            byte[] buffer = Encoding.UTF8.GetBytes(msg + "\n"); // add line terminator
            stream.Write(buffer, 0, buffer.Length);

            richTextBox_Message.AppendText($"Me: {text}{Environment.NewLine}");
            textBox_Message.Clear();
        }
        private void button_Connect_Click(object sender, EventArgs e)
        {
            userName = textBox_YourName.Text;
            if (string.IsNullOrWhiteSpace(userName)) return;

            try
            {
                client = new TcpClient("127.0.0.1", 8080);
                stream = client.GetStream();

                // Gửi tên người dùng ngay sau khi kết nối
                string intro = $"INTRO|{userName}";
                byte[] buffer = Encoding.UTF8.GetBytes(intro + "\n");
                stream.Write(buffer, 0, buffer.Length);

                // Hiển thị trạng thái kết nối
                richTextBox_Message.AppendText("Connected to server." + Environment.NewLine);

                // Bắt đầu nhận tin nhắn
                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }
        private void ReceiveMessages()
        {
            using var reader = new StreamReader(stream, Encoding.UTF8);
            while (true)
            {
                string? line;
                try { line = reader.ReadLine(); } catch { break; }
                if (line == null) break;

                // Gộp xử lý CLIENT_LIST
                if (line.StartsWith("CLIENT_LIST|"))
                {
                    string[] names = line.Substring("CLIENT_LIST|".Length).Split(',');
                    Invoke(new Action(() =>
                    {
                        listBox_Participants.Items.Clear();
                        comboBox_Recipients.Items.Clear();
                        comboBox_Recipients.Items.Add("ALL");

                        foreach (var name in names)
                        {
                            if (name != userName)
                            {
                                listBox_Participants.Items.Add(name);
                                comboBox_Recipients.Items.Add(name);
                            }
                        }
                    }));
                    continue;
                }

                // Bỏ qua tin nhắn của chính mình (broadcast)
                if (line.StartsWith($"{userName}:") && !line.Contains("(private)")) continue;

                // Hiển thị tin nhắn
                Invoke(new Action(() =>
                {
                    richTextBox_Message.AppendText(line + Environment.NewLine);
                }));
            }
        }


        private void Client_Load(object sender, EventArgs e)
        {
            comboBox_Recipients.Items.Add("ALL");
        }

        private void listView_Message_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listView_Participants_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Recipients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_Message_TextChanged(object sender, EventArgs e)
        {

        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                stream?.Close();
                client?.Close();
            }
            catch { }
        }

    }
}
