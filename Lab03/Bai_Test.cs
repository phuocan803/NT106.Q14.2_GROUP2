using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Bai_Test : Form
    {
        private TcpClient tcpClient;
        private NetworkStream ns;

        public Bai_Test()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Kh?i t?o tr?ng thái ban ??u c?a các controls
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
            txtPort.Text = "8080"; // Port m?c ??nh
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
                {
                    MessageBox.Show("Vui lòng nh?p ??a ch? IP!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPort.Text, out int port) || port < 1 || port > 65535)
                {
                    MessageBox.Show("Port không h?p l?! Vui lòng nh?p s? t? 1-65535.", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. T?o ??i t??ng TcpClient
                this.tcpClient = new TcpClient();
                this.tcpClient.ReceiveTimeout = 5000; // Timeout 5 giây
                this.tcpClient.SendTimeout = 5000;

                // 2. K?t n?i ??n Server v?i ??a ch? IP public và Port
                IPAddress ipAddress = IPAddress.Parse(txtIPAddress.Text.Trim());
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
                
                AddLog("?ang k?t n?i t?i " + ipAddress + ":" + port + "...");
                this.tcpClient.Connect(ipEndPoint);

                // 3. T?o NetworkStream ?? g?i và nh?n d? li?u
                this.ns = this.tcpClient.GetStream();

                AddLog("K?t n?i thành công!");
                MessageBox.Show("?ã k?t n?i thành công t?i server!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // C?p nh?t tr?ng thái controls
                btnConnect.Enabled = false;
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
                txtIPAddress.Enabled = false;
                txtPort.Enabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("??a ch? IP không h?p l?!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("L?i: ??a ch? IP không h?p l?");
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Không th? k?t n?i t?i server:\n" + ex.Message, "L?i k?t n?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("L?i k?t n?i: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("L?i: " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    MessageBox.Show("Vui lòng nh?p tin nh?n!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ns != null && tcpClient != null && tcpClient.Connected)
                {
                    // 4. G?i tin nh?n ??n server
                    string message = txtMessage.Text;
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    this.ns.Write(data, 0, data.Length);

                    AddLog("?ã g?i: " + message);
                    txtMessage.Clear();
                    txtMessage.Focus();
                }
                else
                {
                    MessageBox.Show("Ch?a k?t n?i t?i server!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AddLog("L?i: Ch?a k?t n?i t?i server");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi g?i tin nh?n: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("L?i g?i: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
        }

        private void DisconnectFromServer()
        {
            try
            {
                if (ns != null && tcpClient != null)
                {
                    // 5. G?i tín hi?u ng?t k?t n?i và ?óng k?t n?i
                    if (tcpClient.Connected)
                    {
                        byte[] data = Encoding.UTF8.GetBytes("quit\n");
                        this.ns.Write(data, 0, data.Length);
                    }

                    this.ns.Close();
                    this.ns = null;

                    this.tcpClient.Close();
                    this.tcpClient = null;

                    AddLog("?ã ng?t k?t n?i");
                    MessageBox.Show("?ã ng?t k?t n?i kh?i server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // C?p nh?t tr?ng thái controls
                btnConnect.Enabled = true;
                btnSend.Enabled = false;
                btnDisconnect.Enabled = false;
                txtIPAddress.Enabled = true;
                txtPort.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i khi ng?t k?t n?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLog("L?i ng?t k?t n?i: " + ex.Message);
            }
        }

        private void AddLog(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            txtLog.AppendText($"[{timestamp}] {message}\r\n");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // ??m b?o ?óng k?t n?i khi ?óng form
            if (tcpClient != null && tcpClient.Connected)
            {
                DisconnectFromServer();
            }
            base.OnFormClosing(e);
        }
    }
}
