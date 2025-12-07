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
            string gender = radioButton_Male.Checked ? "male" : "female";

            var url = "https://nt106.uitiot.vn/auth/signup";
            using (var client = new HttpClient())
            {
                var content = new MultipartFormDataContent
        {
            { new StringContent(username), "username" },
            { new StringContent(password), "password" },
            { new StringContent(email), "email" },
            { new StringContent(fullName), "ho_ten" },
            { new StringContent(phone), "so_dien_thoai" },
            { new StringContent(birthday), "ngay_sinh" },
            { new StringContent(language), "ngon_ngu" },
            { new StringContent(gender), "gioi_tinh" }
        };

                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đăng ký thành công!");
                    var signin = new Lab04_Bai07.SignIn.SignIn();
                    signin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại: " + responseString);
                }
            }
        }

    }
}
