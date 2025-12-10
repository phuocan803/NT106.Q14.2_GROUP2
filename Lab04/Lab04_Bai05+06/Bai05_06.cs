using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai05_06
{
    public partial class Bai05_06 : Form
    {
        private string accessToken = "";
        private string tokenType = "";

        public Bai05_06()
        {
            InitializeComponent();
        }

        // SỰ KIỆN NÚT "ĐĂNG"
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            btnLogin.Enabled = false;
            rtbResult.Text = "Đang đăng nhập...\n";

            try
            {
                await LoginAsync(username, password);
            }
            catch (Exception ex)
            {
                rtbResult.AppendText($"\n❌ Lỗi: {ex.Message}");
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private async Task LoginAsync(string username, string password)
        {
            string url = "https://nt106.uitiot.vn/auth/token";

            using (var client = new HttpClient())
            {
                // Tạo form-data
                var content = new MultipartFormDataContent
                {
                    { new StringContent(username), "username" },
                    { new StringContent(password), "password" }
                };

                // Gửi POST request
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                // Parse JSON
                var responseObject = JObject.Parse(responseString);

                // Kiểm tra kết quả
                if (!response.IsSuccessStatusCode)
                {
                    var detail = responseObject["detail"]?.ToString() ?? "Đăng nhập thất bại!";
                    rtbResult.Clear();
                    rtbResult.AppendText($"❌ LỖI ĐĂNG NHẬP\n\n");
                    rtbResult.AppendText($"Chi tiết: {detail}\n");
                    MessageBox.Show(detail, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy token
                tokenType = responseObject["token_type"]?.ToString() ?? "";
                accessToken = responseObject["access_token"]?.ToString() ?? "";

                // Hiển thị kết quả
                rtbResult.Clear();
                rtbResult.AppendText("=== ĐĂNG NHẬP THÀNH CÔNG ===\n\n");
                rtbResult.AppendText($"Token Type: {tokenType}\n");
                rtbResult.AppendText($"Access Token:\n{accessToken}\n\n");
                rtbResult.AppendText("✓ Đăng nhập thành công!\n");
                rtbResult.AppendText("→ Nhấn nút 'Nhận' để lấy thông tin người dùng.\n");

                // Kích hoạt nút lấy thông tin
                btnGetInfo.Enabled = true;

                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // SỰ KIỆN NÚT "NHẬN"
        private async void btnGetInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Thông báo");
                return;
            }

            btnGetInfo.Enabled = false;
            rtbResult.AppendText("\n\nĐang lấy thông tin người dùng...\n");

            try
            {
                await GetUserInfoAsync();
            }
            catch (Exception ex)
            {
                rtbResult.AppendText($"\n❌ Lỗi: {ex.Message}");
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                btnGetInfo.Enabled = true;
            }
        }

        private async Task GetUserInfoAsync()
        {
            string url = "https://nt106.uitiot.vn/api/v1/user/me";

            using (var client = new HttpClient())
            {
                // Thêm token vào header Authorization
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, accessToken);

                // Gửi GET request
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();

                // Kiểm tra kết quả
                if (!response.IsSuccessStatusCode)
                {
                    rtbResult.AppendText("\n❌ Lỗi: Token hết hạn hoặc không hợp lệ!\n");
                    rtbResult.AppendText("→ Vui lòng đăng nhập lại.\n");
                    MessageBox.Show("Lỗi xác thực! Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnGetInfo.Enabled = false;
                    accessToken = "";
                    return;
                }

                // Parse JSON
                var userInfo = JObject.Parse(responseString);

                // Lấy thông tin
                string username = userInfo["username"]?.ToString() ?? "";
                string email = userInfo["email"]?.ToString() ?? "";
                string firstName = userInfo["first_name"]?.ToString() ?? "";
                string lastName = userInfo["last_name"]?.ToString() ?? "";
                string fullName = $"{firstName} {lastName}".Trim();

                // Hiển thị vào TextBox
                txtUserInfo_Username.Text = username;
                txtUserInfo_Email.Text = email;
                txtUserInfo_FullName.Text = fullName;

                rtbResult.AppendText($"Username:  {username}\n");
                rtbResult.AppendText($"Email:     {email}\n");
                rtbResult.AppendText($"Họ và Tên: {fullName}\n");
                rtbResult.AppendText($"\nJSON Response:\n{responseString}\n");
                rtbResult.AppendText("\n✓ Lấy thông tin thành công!\n");

                MessageBox.Show("Lấy thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Bai05_06_Load(object sender, EventArgs e)
        {
            // Vô hiệu hóa nút Nhận khi mới mở form
            btnGetInfo.Enabled = false;

            // Có thể để sẵn username/password cho test
            txtUsername.Text = "tkayyy0119";
            txtPassword.Text = "123456789";
        }
    }
}