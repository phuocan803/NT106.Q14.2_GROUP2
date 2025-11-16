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

        public Lab03_Bai03_TCP_Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // Lấy địa chỉ IP của máy
            // string ipServer = GetServerIPAddress();
            // txtLog.AppendText("Server đang lắng nghe trên " + ipServer + ":8080\r\n");

            // lắng nghe trên thread riêng
            serverThread = new Thread(new ThreadStart(StartServer));
            //serverThread.IsBackground = true;

            // start luồng để nó trỏ tới StartServer
            serverThread.Start();

            //btnListen.Text = "Listening...";
            //btnListen.Enabled = false;
        }

        void StartServer()
        {
            int bytesReceived = 0;

            // khởi tạo mảng byte để nhận dữ liệu
            byte[] buffer = new byte[1024];

            // tạo socket lắng nghe 
            listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            // ipserver và endpoint
            // string ipServer = GetServerIPAddress();
            // IPEndPoint ipEpServer = new IPEndPoint(IPAddress.Any, 8080);
            IPEndPoint ipEpServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            // IPEndPoint ipEpServer = new IPEndPoint(IPAddress.Parse(ipServer), 8080);
            
            // gán socket tới địa chỉ IP và port 8080
            listenerSocket.Bind(ipEpServer);

            // bắt đầu lắng nghe
            int n = -1; // số kết nối chờ -1 là vô hạn
            listenerSocket.Listen(n);

            txtLog.AppendText("Server started!\r\n");

            // lặp nhận dữ liệu
            while (true)
            {
                    // Đồng ý kết nối
                    Socket clientSocket = listenerSocket.Accept();

                    // Thông báo client đã kết nối
                    // ref tham chiếu đến clientEP để lấy thông tin client gửi đến
                    IPEndPoint clientEP = (IPEndPoint)clientSocket.RemoteEndPoint;

                    // hiển thị thông tin kết nối
                    txtLog.AppendText("Connection accepted from " + clientEP.Address.ToString() + ":" + clientEP.Port + "\r\n");

                    // Nhận dữ liệu từ client
                    while (clientSocket.Connected)
                    {
                        // nhận dữ liệu từ client
                        bytesReceived = clientSocket.Receive(buffer);
                        
                        if (bytesReceived == 0)
                        {
                            break;
                        }

                        // chuyển mảng byte thành chuỗi
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                        txtLog.AppendText("From client: " + message + "\r\n");
                    }

                    txtLog.AppendText("Client disconnected\r\n");
                    clientSocket.Close();
            }
        }

        //private string GetServerIPAddress()
        //{
        //    // lấy hostname máy hiện tại
        //    string hostName = Dns.GetHostName();

        //    // lấy thông tin ipv4 ipv6 từ hostname lấy được ở trên
        //    IPHostEntry host = Dns.GetHostEntry(hostName);

        //    // IPAddress thuộc System.Net
        //    // IPAddress.AddressFamily là kiểu địa chỉ IP
        //    // IPAddress.InterNetwork là ipv4 
        //    // host.AddressList là mảng các địa chỉ IP lấy được từ hostname -> của class IPHostEntry
        //    // lặp qua các địa chỉ IP để tìm ipv4
        //    // trả về chuỗi IP đầu tiên mà tìm thấy
        //    foreach (IPAddress ip in host.AddressList)
        //    {
        //        if (ip.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            return ip.ToString();
        //        }
        //    }

        //    // không tìm thấy thì trả về ip loopback
        //    return "127.0.0.1";
        //}
    }
}
