using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Lab03_Bai03_TCP_Client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream ns;

        public Lab03_Bai03_TCP_Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
                // template trong file lab3 

                // 1 Tạo đối tượng TcpClient
                this.tcpClient = new TcpClient();

                // 2 Kết nối đến Server với địa chỉ IP và Port xác định
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                this.tcpClient.Connect(ipEndPoint);

                // 3 Tạo luồng để đọc và ghi dữ liệu dựa trên NetworkStream
                this.ns = this.tcpClient.GetStream();

                // MessageBox.Show("Connected to server!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /// Cập nhật trạng thái button 
                //btnConnect.Enabled = false;
                //btnSend.Enabled = true;
                //btnDisconnect.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            // 4 Dùng phương thức Write để gửi dữ liệu đến Server
            byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text + "\n");
            this.ns.Write(data, 0, data.Length);

        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {

            // 5 Dùng phương thức Write để gửi dữ liệu mang dấu hiệu kết thúc cho Server biết và đóng kết nối - SỬA: ASCII -> UTF8
                    byte[] data = Encoding.UTF8.GetBytes("quit\n");
                    this.ns.Write(data, 0, data.Length);
                
                    this.ns.Close();
                    //this.ns = null;
                
                    this.tcpClient.Close();
                    //this.tcpClient = null;
               
                //MessageBox.Show("Disconnected from server!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //// Cập nhật trạng thái buttons
                //btnConnect.Enabled = true;
                //btnSend.Enabled = false;
                //btnDisconnect.Enabled = false;
           
        }
    }
}
