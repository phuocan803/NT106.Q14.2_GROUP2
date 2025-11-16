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
        // private bool isListening = false;
        
        public Lab03_Bai02()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // Lấy địa chỉ IP của máy
            string ipServer = GetServerIPAddress();
            txtLog.AppendText("Server đang lắng nghe trên " + ipServer + ":8080\r\n");

            // lắng nghe trên thread riêng
            serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            // serverThread = new Thread(StartUnsafeThread);
            // serverThread.IsBackground = true;

            // start luồng để nó trỏ tới StartUnsafeThread
            serverThread.Start();
        }

        private void StartUnsafeThread()
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
            int n = -1; // số kết nối chờ -1 là vô hạn
            listenerSocket.Listen(n);

            // lặp nhận dữ liệu
            while (true)
            {
                // Đồng ý kết nối
                Socket clientSocket = listenerSocket.Accept();

                // Thông báo client đã kết nối
                // ref tham chiếu đến clientEP để lấy thông tin client gửi đến
                IPEndPoint clientEP = (IPEndPoint)clientSocket.RemoteEndPoint;

                // IP: message
                string displayMessage = clientEP.Address.ToString() + ": connected";

                // hiển thị nội dung lên textbox
                txtLog.AppendText(displayMessage + "\r\n");
                
                // listViewCommand.Items.Add(new ListViewItem("New client connected"));

                // Nhận dữ liệu
                while (clientSocket.Connected)
                {
                    string text = "";
                    
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
                        txtLog.AppendText(text);
                        //listViewCommand.Items.Add(new ListViewItem(text));
                    }
                }

                txtLog.AppendText("Client disconnected: " + clientEP.Address.ToString() + "\r\n");
                clientSocket.Close();
            }
        }

        private string GetServerIPAddress()
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
    }
}