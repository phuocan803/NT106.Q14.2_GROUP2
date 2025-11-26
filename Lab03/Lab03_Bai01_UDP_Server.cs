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
    public partial class Lab03_Bai01_UDP_Server : Form
    {
        private UdpClient udpServer;
        // private bool isListening = false;
        private Thread listenThread;

        public Lab03_Bai01_UDP_Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {

                int port = int.Parse(txtPort.Text);

                // khởi tạo UDP Server
                udpServer = new UdpClient(port);
                //isListening = true;

                // đổi sang listening, vộ hiệu 2 text box
                //btnListen.Text = "Listening...";
                //btnListen.Enabled = false;
                //txtPort.Enabled = false;

                // lắng nghe trên thread riêng
                listenThread = new Thread(new ThreadStart(ReceiveMessages));
                // listenThread = new Thread(ReceiveMessages);
                // listenThread.IsBackground = true;

                // start luồng để nó trỏ tới ReceiveMessages
                listenThread.Start();

            txtReceivedMessages.AppendText("Server đang lắng nghe trên port " + port + "\r\n");
        }

        private void ReceiveMessages()
        {

            // lặp nhận dữ liệu
            while (true)
            {
                // IPEndPoint là mọi địa chỉ IP và port 0 tự động nhận port của client
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                // nhận dữ liệu
                // ref tham chiếu đến remoteEP để lấy thông tin client gửi đến
                byte[] receivedBytes = udpServer.Receive(ref remoteEP);

                // chuyển mảng byte thành chuỗi
                string receivedMessage = Encoding.UTF8.GetString(receivedBytes);

                // IP: message
                string displayMessage = remoteEP.Address.ToString() + ": " + receivedMessage;

                // hiển thị nội dung lên textbox
                txtReceivedMessages.AppendText(displayMessage + "\r\n");
            }
        }

        private void txtReceivedMessages_TextChanged(object sender, EventArgs e)
        {

        }
    }
}