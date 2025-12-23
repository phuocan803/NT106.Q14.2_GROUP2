using MailKit.Net.Imap;
using System;
using System.Windows.Forms;

namespace Lab05_Bai02
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Button_Login.Click += Button_Login_Click;
        }

        private async void Button_Login_Click(object sender, EventArgs e)
        {
            string email = TextBox_User.Text.Trim();
            string password = TextBox_Password.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và App Password!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var client = new ImapClient())
                {
                    // Kết nối đến IMAP của Gmail
                    await client.ConnectAsync("imap.gmail.com", 993, true);

                    // Xác thực
                    await client.AuthenticateAsync(email, password);

                    // Thành công → mở form xem mail
                    MessageBox.Show("Đăng nhập thành công!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form xem thư
                    Mail viewer = new Mail(email, password);
                    viewer.Show();
                    this.Hide();

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại!\n" +
                    "Kiểm tra đúng Email + App Password (không phải mật khẩu Gmail).\n\n" +
                    "Chi tiết lỗi:\n" + ex.Message,
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
