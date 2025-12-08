using Lab04_Bai07.SignIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Lab04_Bai07.SignUp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void linkLabel_Sign_In_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var signin = new Lab04_Bai07.SignIn.SignIn();
            signin.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button_Sign_Up_Click(object sender, EventArgs e)
        {
            await RegisterUser();
        }

        private async Task RegisterUser()
        {
            string username = textBox_Username.Text;
            string password = textBox_Password.Text;
            string email = textBox_Email.Text;
            string fullName = textBox_FullName.Text;
            string phone = textBox_Phone.Text;
            string birthday = dateTimePicker_Birthday.Value.ToString("yyyy-MM-dd");
            string language = comboBox_Language.Text;

            int sex = radioButton_Male.Checked ? 1 : 0;

            string firstName = fullName;
            string lastName = "";
            int spaceIndex = fullName.LastIndexOf(' ');
            if (spaceIndex > 0)
            {
                firstName = fullName.Substring(spaceIndex + 1); // Tên
                lastName = fullName.Substring(0, spaceIndex);   // Họ và đệm
            }

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu.");
                return;
            }

            var url = "https://nt106.uitiot.vn/api/v1/user/signup";

            try
            {
                using (var client = new HttpClient())
                {
                    var userData = new JObject
                    {
                        ["username"] = username,
                        ["password"] = password,
                        ["email"] = email,
                        ["first_name"] = firstName,
                        ["last_name"] = lastName,
                        ["phone"] = phone,      
                        ["birthday"] = birthday,
                        ["sex"] = sex,          
                        ["language"] = language  
                    };

                    // 2. Đóng gói thành StringContent với header application/json
                    var content = new StringContent(userData.ToString(), Encoding.UTF8, "application/json");

                    // 3. Gửi yêu cầu POST
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đăng ký thành công!");

                        // Chuyển về màn hình đăng nhập
                        var signin = new Lab04_Bai07.SignIn.SignIn();
                        signin.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Hiển thị lỗi chi tiết từ server
                        MessageBox.Show($"Đăng ký thất bại: {responseString}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
