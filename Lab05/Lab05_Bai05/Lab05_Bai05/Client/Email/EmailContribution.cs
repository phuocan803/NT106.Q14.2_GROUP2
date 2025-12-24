using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_Bai07.Client.Email
{
    public partial class EmailContribution : Form
    {
        public EmailContribution()
        {
            InitializeComponent();
            listView_Mail.View = View.Details;
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string appPassword = txtAppPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(appPassword))
            {
                MessageBox.Show("Vui lòng nhập Email và mật khẩu ứng dụng!");
                return;
            }

            btnFetch.Enabled = false;
            btnFetch.Text = "Đang quét...";
            listView_Mail.Items.Clear();

            try
            {
                using (var client = new ImapClient())
                {
                    // Kết nối tới server IMAP của Gmail, Xác thực bằng AppPassword
                    await client.ConnectAsync("imap.gmail.com", 993, true);
                    await client.AuthenticateAsync(email, appPassword);

                    var inbox = client.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadWrite);

                    // 1. Lấy danh sách tên món hiện có từ API để kiểm tra trùng
                    var existingFoods = await GetExistingFoodNames();

                    // 2. Tìm thư chưa đọc có tiêu đề "Đóng góp món ăn"
                    var query = SearchQuery.SubjectContains("Đóng góp món ăn").And(SearchQuery.NotSeen);
                    var uids = await inbox.SearchAsync(query);

                    int count = 0;
                    foreach (var uid in uids)
                    {
                        var message = await inbox.GetMessageAsync(uid);
                        string body = message.TextBody;

                        // 3. Tách chuỗi theo định dạng <Tên món>;<Link ảnh>
                        if (!string.IsNullOrEmpty(body) && body.Contains(";"))
                        {
                            string[] parts = body.Split(';');
                            string tenMon = parts[0].Trim();
                            string urlAnh = parts[1].Trim();

                            // Lấy tên người gửi từ email
                            string senderName = message.From.Mailboxes.FirstOrDefault()?.Name;
                            if (string.IsNullOrEmpty(senderName)) senderName = "Người ẩn danh";

                            // 4. Kiểm tra trùng lặp và gửi API
                            bool isDuplicate = existingFoods.Contains(tenMon.ToLower());
                            string status = "Đã tồn tại";

                            if (!isDuplicate)
                            {
                                bool success = await PostFoodToApi(tenMon, urlAnh, senderName);
                                status = success ? "Thành công" : "Lỗi API";
                                if (success) count++;
                            }

                            // 5. Cập nhật giao diện ListView
                            ListViewItem item = new ListViewItem(tenMon);
                            item.SubItems.Add(senderName);
                            item.SubItems.Add(status);

                            if (status == "Đã tồn tại") item.ForeColor = Color.Gray;
                            if (status == "Lỗi API") item.ForeColor = Color.Red;

                            listView_Mail.Items.Add(item);
                        }

                        // 6. Đánh dấu đã đọc để không quét lại lần sau
                        await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                    }

                    MessageBox.Show($"Hoàn tất! Đã thêm {count} món mới.");
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                btnFetch.Enabled = true;
                btnFetch.Text = "Tải đóng góp";
            }
        }

        private async Task<List<string>> GetExistingFoodNames()
        {
            var names = new List<string>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);
                    var body = new JObject { ["current"] = 1, ["pageSize"] = 1000 };
                    var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/all", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                        foreach (var item in json["data"]) names.Add(item["ten_mon_an"].ToString().ToLower());
                    }
                }
            }
            catch { }
            return names;
        }

        private async Task<bool> PostFoodToApi(string tenMon, string urlAnh, string nguoiDongGop)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);
                    var body = new JObject
                    {
                        ["ten_mon_an"] = tenMon,
                        ["gia"] = 0,
                        ["dia_chi"] = "Đóng góp qua Email",
                        ["hinh_anh"] = urlAnh,
                        ["mo_ta"] = $"Đóng góp bởi: {nguoiDongGop}"
                    };
                    var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://nt106.uitiot.vn/api/v1/monan/add", content);
                    return response.IsSuccessStatusCode;
                }
            }
            catch { return false; }
        }

        private void listView_Mail_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Để trống hoặc dùng để xem chi tiết khi click vào một dòng
        }
    }
}
