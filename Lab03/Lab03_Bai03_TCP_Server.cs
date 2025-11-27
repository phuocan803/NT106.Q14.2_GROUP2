using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Lab03_Bai03_TCP_Server : Form
    {
        private Socket listenerSocket;
        private Thread serverThread;
        private bool isRunning = false;

        public Lab03_Bai03_TCP_Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; // Allow cross-thread calls for simplicity
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // bảo tồn tránh khởi tạo nhiều server
            if (isRunning || listenerSocket != null)
            {
                MessageBox.Show("Server đã đang chạy!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                isRunning = true;

                // Update UI
                btnListen.Text = "Listening...";
                btnListen.Enabled = false;

                // lắng nghe trên thread riêng
                serverThread = new Thread(new ThreadStart(StartServer));
                serverThread.IsBackground = true;

                // start luồng để nó trỏ tới StartServer
                serverThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupServer();
            }
        }

        void StartServer()
        {
            try
            {
                // khởi tạo mảng byte để nhận dữ liệu
                byte[] buffer = new byte[1024];

                // tạo socket lắng nghe 
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                // ipserver và endpoint
                IPEndPoint ipEpServer = new IPEndPoint(IPAddress.Any, 8080);
                
                // gán socket tới địa chỉ IP và port 8080
                listenerSocket.Bind(ipEpServer);

                // bắt đầu lắng nghe
                int backlog = 10; // số kết nối chờ tối đa
                listenerSocket.Listen(backlog);

                txtLog.AppendText("Server started! Listening on port 8080\r\n");

                // lặp nhận dữ liệu
                while (isRunning)
                {
                    try
                    {
                        // Đồng ý kết nối
                        Socket clientSocket = listenerSocket.Accept();

                        // Thông báo client đã kết nối
                        IPEndPoint clientEP = (IPEndPoint)clientSocket.RemoteEndPoint;

                        // hiển thị thông tin kết nối
                        txtLog.AppendText("Connection accepted from " + clientEP.Address.ToString() + ":" + clientEP.Port + "\r\n");

                        // Handle client in separate thread
                        Thread clientThread = new Thread(() => HandleClient(clientSocket, clientEP));
                        clientThread.IsBackground = true;
                        clientThread.Start();
                    }
                    catch (SocketException)
                    {
                        if (!isRunning)
                            break;
                    }
                }
            }
            catch (SocketException ex)
            {
                if (isRunning)
                {
                    MessageBox.Show("Lỗi socket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleClient(Socket clientSocket, IPEndPoint clientEP)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesReceived = 0;

                // Nhận dữ liệu từ client
                while (clientSocket.Connected && isRunning)
                {
                    try
                    {
                        // nhận dữ liệu từ client
                        bytesReceived = clientSocket.Receive(buffer);
                        
                        if (bytesReceived == 0)
                        {
                            break; // Client closed connection
                        }

                        // chuyển mảng byte thành chuỗi
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                        // kiểm tra lệnh thoát
                        if (message.Trim().ToLower() == "quit")
                        {
                            txtLog.AppendText("Client " + clientEP.Address.ToString() + ":" + clientEP.Port + " sent quit command\r\n");
                            break;
                        }

                        txtLog.AppendText("From " + clientEP.Address.ToString() + ":" + clientEP.Port + " - " + message + "\r\n");
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }

                txtLog.AppendText("Client disconnected: " + clientEP.Address.ToString() + ":" + clientEP.Port + "\r\n");
            }
            catch (Exception ex)
            {
                txtLog.AppendText("Lỗi xử lý client: " + ex.Message + "\r\n");
            }
            finally
            {
                if (clientSocket != null && clientSocket.Connected)
                {
                    clientSocket.Close();
                }
            }
        }

        private void CleanupServer()
        {
            isRunning = false;

            if (listenerSocket != null)
            {
                try
                {
                    listenerSocket.Close();
                }
                catch { }
                listenerSocket = null;
            }

            if (serverThread != null && serverThread.IsAlive)
            {
                serverThread.Join(1000);
            }

            btnListen.Text = "Listen";
            btnListen.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CleanupServer();
            base.OnFormClosing(e);
        }
    }
}
