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
            
            // Initialize button states
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ IP!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate IP address
                if (!IPAddress.TryParse(txtIPAddress.Text.Trim(), out IPAddress ipAddress))
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 1 Tạo đối tượng TcpClient
                this.tcpClient = new TcpClient();

                // 2 Kết nối đến Server với địa chỉ IP và Port xác định (lấy từ TextBox)
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
                this.tcpClient.Connect(ipEndPoint);

                // 3 Tạo luồng để đọc và ghi dữ liệu dựa trên NetworkStream
                this.ns = this.tcpClient.GetStream();

                MessageBox.Show("Kết nối đến server thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật trạng thái button 
                btnConnect.Enabled = false;
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
                txtIPAddress.Enabled = false;
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Không thể kết nối đến server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (ns != null && tcpClient != null && tcpClient.Connected)
                {
                    // Validate message
                    if (string.IsNullOrWhiteSpace(txtMessage.Text))
                    {
                        MessageBox.Show("Vui lòng nhập nội dung tin nhắn!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 4 Dùng phương thức Write để gửi dữ liệu đến Server
                    byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text);
                    this.ns.Write(data, 0, data.Length);
                    
                    MessageBox.Show("Đã gửi tin nhắn thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMessage.Clear();
                }
                else
                {
                    MessageBox.Show("Chưa kết nối đến server!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Mất kết nối đến server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cleanup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (ns != null && tcpClient != null && tcpClient.Connected)
                {
                    // 5 Dùng phương thức Write để gửi dữ liệu mang dấu hiệu kết thúc cho Server biết và đóng kết nối
                    byte[] data = Encoding.UTF8.GetBytes("quit");
                    this.ns.Write(data, 0, data.Length);
                }

                Cleanup();

                MessageBox.Show("Đã ngắt kết nối khỏi server!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ngắt kết nối: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cleanup();
            }
        }

        private void Cleanup()
        {
            try
            {
                if (this.ns != null)
                {
                    this.ns.Close();
                    this.ns = null;
                }

                if (this.tcpClient != null)
                {
                    this.tcpClient.Close();
                    this.tcpClient = null;
                }

                // Cập nhật trạng thái buttons
                btnConnect.Enabled = true;
                btnSend.Enabled = false;
                btnDisconnect.Enabled = false;
                txtIPAddress.Enabled = true;
            }
            catch { }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Cleanup();
            base.OnFormClosing(e);
        }
    }
}
