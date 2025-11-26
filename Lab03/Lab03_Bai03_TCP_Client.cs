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
            try
            {
                // template trong file lab3 

                // 1 Tạo đối tượng TcpClient
                this.tcpClient = new TcpClient();

                // 2 Kết nối đến Server với địa chỉ IP và Port xác định (lấy từ TextBox)
                IPAddress ipAddress = IPAddress.Parse(txtIPAddress.Text.Trim());
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                this.tcpClient.Connect(ipEndPoint);

                // 3 Tạo luồng để đọc và ghi dữ liệu dựa trên NetworkStream
                this.ns = this.tcpClient.GetStream();

                MessageBox.Show("Connected to server!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật trạng thái button 
                btnConnect.Enabled = false;
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
                txtIPAddress.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (ns != null && tcpClient != null && tcpClient.Connected)
                {
                    // 4 Dùng phương thức Write để gửi dữ liệu đến Server
                    byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text + "\n");
                    this.ns.Write(data, 0, data.Length);
                    txtMessage.Clear();
                }
                else
                {
                    MessageBox.Show("Not connected to server!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (ns != null && tcpClient != null)
                {
                    // 5 Dùng phương thức Write để gửi dữ liệu mang dấu hiệu kết thúc cho Server biết và đóng kết nối
                    byte[] data = Encoding.UTF8.GetBytes("quit\n");
                    this.ns.Write(data, 0, data.Length);

                    this.ns.Close();
                    this.ns = null;

                    this.tcpClient.Close();
                    this.tcpClient = null;

                    MessageBox.Show("Disconnected from server!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật trạng thái buttons
                    btnConnect.Enabled = true;
                    btnSend.Enabled = false;
                    btnDisconnect.Enabled = false;
                    txtIPAddress.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnecting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
