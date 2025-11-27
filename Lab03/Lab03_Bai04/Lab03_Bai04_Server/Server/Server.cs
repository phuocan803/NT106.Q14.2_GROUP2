using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab03_Bai04_Server
{
    public partial class Server : Form
    {
        TcpListener listener;
        List<TcpClient> clients = new List<TcpClient>();
        object lockObj = new object();
        bool isRunning = false;

        // Dữ liệu phim & ghế
        Dictionary<string, Dictionary<int, List<string>>> bookedSeats = new Dictionary<string, Dictionary<int, List<string>>>();

        public Server()
        {
            InitializeComponent();
            //textBox_IP_Address.Text = "127.0.0.1";
            //textBox_Port.Text = "9000";
            InitializeMovies();
            //this.Load += Server_Load;
        }

        private void Server_Load(object sender, EventArgs e) => button_Listen_Click(null, null);

        private void InitializeMovies()
        {
            bookedSeats["Đào, phở và piano"] = new Dictionary<int, List<string>> { { 1, new List<string>() }, { 2, new List<string>() }, { 3, new List<string>() } };
            bookedSeats["Mai"] = new Dictionary<int, List<string>> { { 2, new List<string>() }, { 3, new List<string>() } };
            bookedSeats["Gặp lại chị bầu"] = new Dictionary<int, List<string>> { { 1, new List<string>() } };
            bookedSeats["Tarot"] = new Dictionary<int, List<string>> { { 3, new List<string>() } };
        }

        private void button_Listen_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                Log("Máy chủ đang chạy."); 
                return; 
            }
            try
            {
                listener = new TcpListener(IPAddress.Parse(textBox_IP_Address.Text.Trim()), int.Parse(textBox_Port.Text.Trim()));
                listener.Start();
                isRunning = true;
                Log("Máy chủ đã chạy tại " + textBox_IP_Address.Text + ":" + textBox_Port.Text);

                Thread t = new Thread(AcceptClients)
                {
                    IsBackground = true
                };
                t.Start();

                button_Listen.Enabled = false;
                button_Stop.Enabled = true;
            }
            catch (Exception ex) 
            { 
                Log("Lỗi: " + ex.Message); 
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            if (!isRunning) return;

            try
            {
                isRunning = false;
                listener.Stop();

                lock (lockObj)
                {
                    foreach (var c in clients) c.Close();
                    clients.Clear();
                }

                UpdateClientsList();
                Log("Máy chủ đã dừng.");

                button_Listen.Enabled = true;
                button_Stop.Enabled = false;
            }
            catch (Exception ex)
            {
                Log("Lỗi khi dừng máy chủ: " + ex.Message);
            }
        }


        private void AcceptClients()
        {
            while(isRunning)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    lock(lockObj) clients.Add(client);
                    UpdateClientsList();
                    Log("Khách kết nối: " + client.Client.RemoteEndPoint);
                    Thread t = new Thread(HandleClient)
                    {
                        IsBackground = true
                    };
                    t.Start(client);
                }
                catch{ }
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytes = ns.Read(buffer, 0, buffer.Length);
                    if (bytes == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                    ProcessMessage(msg, client);
                }
            }
            catch { }
            finally
            {
                lock (lockObj) clients.Remove(client);
                UpdateClientsList();
                Log("Khách ngắt kết nối: " + client.Client.RemoteEndPoint);
                client.Close();
            }
        }
        private void ProcessMessage(string msg, TcpClient sender)
        {
            string[] parts = msg.Split('|');

            if (parts[0] == "GET_SEATS")
            {
                string movie = parts[1];
                int room = int.Parse(parts[2]);
                string booked = string.Join(",", bookedSeats[movie][room]);
                SendMessage(sender, "SEATS|" + booked);
            }
            else if (parts[0] == "BOOK_SEATS")
            {
                string customer = parts[1];
                string movie = parts[2];
                int room = int.Parse(parts[3]);
                string[] seats = parts[4].Split(',');

                lock (lockObj)
                {
                    List<string> failed = new List<string>();
                    foreach (string s in seats)
                    {
                        if (bookedSeats[movie][room].Contains(s)) failed.Add(s);
                    }

                    if (failed.Count > 0)
                    {
                        SendMessage(sender, "BOOK_FAIL|" + string.Join(",", failed));
                        return;
                    }

                    bookedSeats[movie][room].AddRange(seats);
                    SendMessage(sender, "BOOK_SUCCESS|" + string.Join(",", seats));

                    BroadcastUpdate(movie, room);

                    // Log rút gọn nhưng có IP
                    string clientIP = sender.Client.RemoteEndPoint.ToString();
                    Log($"[{customer} | {clientIP}] {movie} P{room}: {string.Join(",", seats)}");
                }
            }
        }


        private void BroadcastUpdate(string movie, int room)
        {
            string msg = "UPDATE|" + movie + "|" + room + "|" + string.Join(",", bookedSeats[movie][room]);
            byte[] data = Encoding.UTF8.GetBytes(msg);

            lock (lockObj)
            {
                foreach (var client in clients)
                {
                    try 
                    { 
                        client.GetStream().Write(data, 0, data.Length); 
                    }
                    catch { }
                }
            }
        }

        private void SendMessage(TcpClient client, string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            try 
            { 
                client.GetStream().Write(data, 0, data.Length); 
            }
            catch { }
        }

        private void Log(string s)
        {
            if (InvokeRequired)
            { 
                Invoke(new Action<string>(Log), s); 
                return; 
            }
            textBox_Logs.AppendText(s + Environment.NewLine);
        }

        private void UpdateClientsList()
        {
            if (InvokeRequired)
            { 
                Invoke(new Action(UpdateClientsList));
                return;
            }
            listBox_Clients.Items.Clear();
            foreach (var c in clients)
            {
                listBox_Clients.Items.Add(c.Client.RemoteEndPoint.ToString());
            }    
        }
    }
}

