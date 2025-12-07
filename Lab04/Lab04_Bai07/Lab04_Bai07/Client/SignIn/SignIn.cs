using Lab04_Bai07.SignUp;
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
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Lab04_Bai07.Client.Main_Menu;

namespace Lab04_Bai07.SignIn
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void linkLabel_Sign_Up_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var signup = new Lab04_Bai07.SignUp.SignUp();
            signup.Show();
            this.Close();
        }

        private void label_Title_Click(object sender, EventArgs e)
        {

        }

        private async void button_Sign_In_Click(object sender, EventArgs e)
        {
            string username = textBox_Username.Text;
            string password = textBox_Password.Text;

            var url = "https://nt106.uitiot.vn/auth/token";
            using (var client = new HttpClient())
            {
                var content = new MultipartFormDataContent
                {
                    { new StringContent(username), "username" },
                    { new StringContent(password), "password" }
                };

                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(responseString);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đăng nhập thất bại: " + responseObject["detail"]);
                    return;
                }

                Session.TokenType = responseObject["token_type"].ToString();
                Session.AccessToken = responseObject["access_token"].ToString();

                MessageBox.Show("Đăng nhập thành công!");
                var mainMenu = new Lab04_Bai07.Client.Main_Menu.MainMenu();
                mainMenu.Show();
                this.Hide();
            }
        }
    }
}
