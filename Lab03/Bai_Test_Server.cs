using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Bai_Test_Server : Form
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private bool isRunning = false;

        public Bai_Test_Server()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Kh?i t?o tr?ng thái ban ??u
            btnStop.Enabled = false;
            txtPort.Text = "8080"; // Port m?c ??nh
            
            // Hi?n th? thông tin IP c?a server
            try
            {
                string hostName = Dns.GetHostName();
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
                txtPrivateIP.Text = "";
                
                foreach (IPAddress ip in hostEntry.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        txtPrivateIP.Text = ip.ToString();
                        break;
                    }
                }
                
                // Hi?n th? thông tin IP
                AddLog("Private IP: " + txtPrivateIP.Text);
                AddLog("Public IP: 34.60.110.222 (GCP External IP)");
                AddLog("Server s? l?ng nghe trên 0.0.0.0 (t?t c? các interfaces)");
            }
            catch (Exception ex)
            {
                AddLog("L?i khi l?y IP: " + ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
                {
                    MessageBox.Show("Port không h?p l?! Vui lòng nh?p s? t? 1-65535.", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kh?i ??ng server - L?ng nghe trên 0.0.0.0 (t?t c? interfaces)
                // ?i?u này cho phép k?t n?i t? c? private IP (10.128.0.2) và public IP (34.60.110.222)
                this.tcpListener = new TcpListener(IPAddress.Any, port);
                this.tcpListener.Start();
                this.isRunning = true;

                // T?o thread ?? l?ng nghe k?t n?i
                this.listenThread = new Thread(new ThreadStart(ListenForClients));
                this.listenThread.IsBackground = true;
                this.listenThread.Start();

                AddLog("========================================");
                AddLog("Server ?ã kh?i ??ng trên 0.0.0.0:" + port);
                AddLog("Private IP: " + txtPrivateIP.Text + ":" + port);
                AddLog("Public IP: 34.60.110.222:" + port);
                AddLog("========================================");
                AddLog("?ang ch? k?t n?i t? client...");
                AddLog("");
                
                MessageBox.Show(
                    "Server ?ã kh?i ??ng thành công!\n\n" +
                    "K?t n?i t? Internet: 34.60.110.222:" + port + "\n" +
                    "K?t n?i local/VPC: " + txtPrivateIP.Text + ":" + port,
                    "Thông báo", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                // C?p nh?t tr?ng thái controls
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                txtPort.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi kh?i ??ng server: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("L?i kh?i ??ng: " + ex.Message);
            }
        }

        private void ListenForClients()
        {
            try
            {
                while (isRunning)
                {
                    if (tcpListener.Pending())
                    {
                        // Ch?p nh?n k?t n?i t? client
                        TcpClient client = tcpListener.AcceptTcpClient();
                        
                        // L?y thông tin client
                        IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                        string clientInfo = clientEndPoint.Address.ToString() + ":" + clientEndPoint.Port;
                        
                        AddLog(">>> Client ?ã k?t n?i: " + clientInfo);

                        // T?o thread ?? x? lý client
                        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                        clientThread.IsBackground = true;
                        clientThread.Start(client);
                    }
                    Thread.Sleep(100); // Gi?m t?i CPU
                }
            }
            catch (Exception ex)
            {
                if (isRunning)
                {
                    AddLog("L?i khi l?ng nghe: " + ex.Message);
                }
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream ns = null;
            IPEndPoint clientEndPoint = null;
            string clientInfo = "";

            try
            {
                clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                clientInfo = clientEndPoint.Address.ToString() + ":" + clientEndPoint.Port;
                ns = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    
                    if (message.ToLower() == "quit")
                    {
                        AddLog("<<< Client ng?t k?t n?i: " + clientInfo);
                        break;
                    }

                    AddLog("[" + clientInfo + "]: " + message);

                    // G?i ph?n h?i cho client
                    string response = "Server ?ã nh?n: " + message + "\n";
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    ns.Write(responseData, 0, responseData.Length);
                }
            }
            catch (Exception ex)
            {
                AddLog("L?i khi x? lý client " + clientInfo + ": " + ex.Message);
            }
            finally
            {
                if (ns != null)
                    ns.Close();
                if (client != null)
                    client.Close();
                AddLog("--- ?ã ?óng k?t n?i v?i: " + clientInfo);
                AddLog("");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            try
            {
                isRunning = false;

                if (tcpListener != null)
                {
                    tcpListener.Stop();
                }

                if (listenThread != null && listenThread.IsAlive)
                {
                    listenThread.Join(1000); // ??i t?i ?a 1 giây
                }

                AddLog("========================================");
                AddLog("Server ?ã d?ng");
                AddLog("========================================");
                MessageBox.Show("Server ?ã d?ng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // C?p nh?t tr?ng thái controls
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                txtPort.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi d?ng server: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("L?i d?ng server: " + ex.Message);
            }
        }

        private void AddLog(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => AddLog(message)));
            }
            else
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                txtLog.AppendText($"[{timestamp}] {message}\r\n");
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // ??m b?o d?ng server khi ?óng form
            if (isRunning)
            {
                StopServer();
            }
            base.OnFormClosing(e);
        }
    }
}
