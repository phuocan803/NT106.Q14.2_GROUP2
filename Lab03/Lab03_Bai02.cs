using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Lab03_Bai02 : Form
    {
        private Socket listenerSocket;
        private Thread serverThread;
        private bool isRunning = false;
        
        public Lab03_Bai02()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; // cho phép gọi cross-thread để đơn giản hóa
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
                // Lấy địa chỉ IP của máy
                string ipServer = GetServerIPAddress();
                txtLog.AppendText("Server đang lắng nghe trên " + ipServer + ":8080\r\n");

                isRunning = true;

                // Disable button
                btnListen.Text = "Listening...";
                btnListen.Enabled = false;

                // lắng nghe trên thread riêng
                serverThread = new Thread(new ThreadStart(StartUnsafeThread));
                serverThread.IsBackground = true;

                // start luồng để nó trỏ tới StartUnsafeThread
                serverThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi động server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupServer();
            }
        }

        private void StartUnsafeThread()
        {
            try
            {
                int bytesReceived = 0;

                // khởi tạo mảng byte để nhận dữ liệu
                byte[] recv = new byte[1];

                // tạo socket lắng nghe 
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                // ipserver và endpoint
                string ipServer = GetServerIPAddress();
                IPEndPoint ipEpServer = new IPEndPoint(IPAddress.Parse(ipServer), 8080);
                
                // gán socket tới địa chỉ IP và port 8080
                listenerSocket.Bind(ipEpServer);

                // bắt đầu lắng nghe
                int n = 10; // số kết nối chờ tối đa
                listenerSocket.Listen(n);

                txtLog.AppendText("Server sẵn sàng nhận kết nối...\r\n");

                // lặp nhận dữ liệu
                while (isRunning)
                {
                    try
                    {
                        // Đồng ý kết nối
                        Socket clientSocket = listenerSocket.Accept();

                        // Thông báo client đã kết nối
                        IPEndPoint clientEP = (IPEndPoint)clientSocket.RemoteEndPoint;

                        // IP: message
                        string displayMessage = clientEP.Address.ToString() + ":" + clientEP.Port + " - connected";

                        // hiển thị nội dung lên textbox
                        txtLog.AppendText(displayMessage + "\r\n");

                        // Nhận dữ liệu từ client trong thread riêng
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
                int bytesReceived = 0;
                byte[] recv = new byte[1];

                // Nhận dữ liệu
                while (clientSocket.Connected && isRunning)
                {
                    string text = "";
                    
                    try
                    {
                        do
                        {
                            bytesReceived = clientSocket.Receive(recv);
                            
                            if (bytesReceived == 0)
                                break;
                                
                            // chuyển mảng byte thành chuỗi 
                            text += Encoding.UTF8.GetString(recv);
                            
                        } while (text.Length == 0 || text[text.Length - 1] != '\n');

                        if (bytesReceived > 0 && text.Length > 0)
                        {
                            // Hiển thị tin nhắn từ client
                            string displayMsg = clientEP.Address.ToString() + ":" + clientEP.Port + " - " + text;
                            txtLog.AppendText(displayMsg);
                        }
                        else
                        {
                            break; // Client disconnect
                        }
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

        private string GetServerIPAddress()
        {
            try
            {
                // lấy hostname máy hiện tại
                string hostName = Dns.GetHostName();

                // lấy thông tin ipv4 ipv6 từ hostname lấy dược ở trên
                IPHostEntry host = Dns.GetHostEntry(hostName);

                // IPAddress thuộc System.Net
                // IPAddress.AddressFamily là kiểu địa chỉ IP
                // IPAddress.InterNetwork là ipv4 
                // host.AddressList là mảng các địa chỉ IP lấy được từ hostname -> của class IPHostEntry
                // lặp qua các địa chỉ IP để tìm ipv4
                // trả về chuỗi IP đầu tiên mà tìm thấy
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }

                // không tìm thấy thì trả về ip loopback
                return "127.0.0.1";
            }
            catch
            {
                return "127.0.0.1";
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

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}