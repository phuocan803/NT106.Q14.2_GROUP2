using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private TcpListener listener;
        private Thread listenThread;
        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();
        public Server()
        {
            InitializeComponent();
        }

        private void button_Listen_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
            richTextBox_Log.AppendText("Server started, listening on port 8080...\n");
            listenThread = new Thread(ListenForClients);
            listenThread.Start();
        }
        private void ListenForClients()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread clientThread = new Thread(HandleClientComm);
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object obj)
        {
            var tcpClient = (TcpClient)obj;
            using var reader = new StreamReader(tcpClient.GetStream(), Encoding.UTF8);
            string? clientName = null;

            while (true)
            {
                string? line;
                try { line = reader.ReadLine(); } catch { break; }
                if (line == null) break;

                // Xử lý clientName
                if (line.StartsWith("INTRO|"))
                {
                    clientName = line.Substring("INTRO|".Length);
                    if (!clients.ContainsKey(clientName))
                    {
                        clients[clientName] = tcpClient;
                        Invoke(new Action(() =>
                            richTextBox_Log.AppendText($"New client connected: {clientName}{Environment.NewLine}")));
                        SendClientListToAll(); // cập nhật danh sách cho các client
                    }
                    continue;
                }

                // Xử lý tin nhắn thông thường
                var parts = line.Split('|');
                if (parts.Length < 3) continue;

                string sender = parts[0];
                string recipient = parts[1];
                string text = parts[2];

                if (recipient == "ALL")
                    BroadcastMessage($"{sender}: {text}");
                else if (clients.ContainsKey(recipient))
                    SendPrivateMessage(recipient, $"{sender} (private): {text}");
            }

            // Khi client ngắt kết nối
            if (clientName != null)
            {
                clients.Remove(clientName);
                Invoke(new Action(() =>
                    richTextBox_Log.AppendText($"{clientName} disconnected.{Environment.NewLine}")));
                SendClientListToAll(); // cập nhật lại danh sách
                BroadcastMessage($"{clientName} has left the chat.");
            }

            tcpClient.Close();
        }
        private void SendClientListToAll()
        {
            string listMessage = "CLIENT_LIST|" + string.Join(",", clients.Keys);
            byte[] buffer = Encoding.UTF8.GetBytes(listMessage + "\n");

            foreach (var client in clients.Values)
            {
                try
                {
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
                catch { /* xử lý lỗi */ }
            }
        }

        private void BroadcastMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message + "\n"); 
            foreach (var client in clients.Values)
            {
                try
                {
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
                catch { /* handle disconnected client */ }
            }
            Invoke(new Action(() => richTextBox_Log.AppendText(message + Environment.NewLine)));
        }

        private void SendPrivateMessage(string recipient, string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message + "\n");
            var client = clients[recipient];
            client.GetStream().Write(buffer, 0, buffer.Length);
            Invoke(new Action(() => richTextBox_Log.AppendText(message + Environment.NewLine)));
        }

        private void Server_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox_Log_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
