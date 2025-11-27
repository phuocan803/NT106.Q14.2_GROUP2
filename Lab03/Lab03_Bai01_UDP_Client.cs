using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Lab03_Bai01_UDP_Client : Form
    {
        public Lab03_Bai01_UDP_Client()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            UdpClient client = null;
            try
            {
                // kiểm tra inputs
                if (string.IsNullOrWhiteSpace(txtIPRemoteHost.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ IP!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPort.Text))
                {
                    MessageBox.Show("Vui lòng nhập Port!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    MessageBox.Show("Vui lòng nhập nội dung tin nhắn!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // kiểm tra IP address
                if (!IPAddress.TryParse(txtIPRemoteHost.Text.Trim(), out IPAddress ipAddress))
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // kiểm tra port
                if (!int.TryParse(txtPort.Text.Trim(), out int port) || port < 1 || port > 65535)
                {
                    MessageBox.Show("Port phải là số từ 1 đến 65535!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // tạo kết nối UDP
                client = new UdpClient();

                // chuyển đổi chuỗi thành mảng byte
                byte[] sendBytes = Encoding.UTF8.GetBytes(txtMessage.Text);

                // gửi dữ liệu đến Remote Host
                client.Send(sendBytes, sendBytes.Length, txtIPRemoteHost.Text.Trim(), port);

                MessageBox.Show("Đã gửi tin nhắn thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // clear mess sau khi gửi
                txtMessage.Clear();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi tin nhắn: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng client sau khi gửi
                if (client != null)
                {
                    client.Close();
                }
            }
        }
    }
}
