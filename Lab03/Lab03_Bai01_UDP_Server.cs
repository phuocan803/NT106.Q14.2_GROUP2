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
        private Thread listenThread;
        private bool isRunning = false;

        public Lab03_Bai01_UDP_Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; // Allow cross-thread calls for simplicity
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // Prevent multiple initializations
            if (udpServer != null || isRunning)
            {
                MessageBox.Show("Server is already listening!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int port = int.Parse(txtPort.Text);

                // khởi tạo UDP Server
                udpServer = new UdpClient(port);
                isRunning = true;

                // đổi sang listening, vô hiệu 2 text box
                btnListen.Text = "Listening...";
                btnListen.Enabled = false;
                txtPort.Enabled = false;

                // lắng nghe trên thread riêng
                listenThread = new Thread(new ThreadStart(ReceiveMessages));
                listenThread.IsBackground = true;

                // start luồng để nó trỏ tới ReceiveMessages
                listenThread.Start();

                txtReceivedMessages.AppendText("Server đang lắng nghe trên port " + port + "\r\n");
            }
            catch (FormatException)
            {
                MessageBox.Show("Port phải là một số nguyên hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupServer();
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                // lặp nhận dữ liệu
                while (isRunning)
                {
                    // IPEndPoint là mọi địa chỉ IP và port 0 tự động nhận port của client
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                    // nhận dữ liệu
                    // ref tham chiếu đến remoteEP để lấy thông tin client gửi đến
                    byte[] receivedBytes = udpServer.Receive(ref remoteEP);

                    // chuyển mảng byte thành chuỗi
                    string receivedMessage = Encoding.UTF8.GetString(receivedBytes);

                    // IP: message
                    string displayMessage = remoteEP.Address.ToString() + ":" + remoteEP.Port + " - " + receivedMessage;

                    // hiển thị nội dung lên textbox
                    if (txtReceivedMessages.InvokeRequired)
                    {
                        txtReceivedMessages.Invoke(new Action(() =>
                        {
                            txtReceivedMessages.AppendText(displayMessage + "\r\n");
                        }));
                    }
                    else
                    {
                        txtReceivedMessages.AppendText(displayMessage + "\r\n");
                    }
                }
            }
            catch (SocketException)
            {
                // Socket closed, normal termination
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhận dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanupServer()
        {
            isRunning = false;

            if (udpServer != null)
            {
                udpServer.Close();
                udpServer = null;
            }

            if (listenThread != null && listenThread.IsAlive)
            {
                listenThread.Join(1000); // chờ 1000ms=1s để thread kết thúc
            }

            btnListen.Text = "Listen";
            btnListen.Enabled = true;
            txtPort.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CleanupServer();
            base.OnFormClosing(e);
        }

        private void txtReceivedMessages_TextChanged(object sender, EventArgs e)
        {

        }
    }
}