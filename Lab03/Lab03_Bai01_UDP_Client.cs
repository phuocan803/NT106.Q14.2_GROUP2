using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            // tạo kết nối UDP
            UdpClient client = new UdpClient();

            // chuyển đổi chuỗi thành mảng byte
            Byte[] sendBytes = Encoding.UTF8.GetBytes(txtMessage.Text);

            // gửi dữ liệu đến Remote Host
            client.Send(sendBytes, sendBytes.Length, txtIPRemoteHost.Text, int.Parse(txtPort.Text));
            
            // client.Send(sendBytes, sendBytes.Length, 172.0.0.1, 8080);
        }
    }
}
