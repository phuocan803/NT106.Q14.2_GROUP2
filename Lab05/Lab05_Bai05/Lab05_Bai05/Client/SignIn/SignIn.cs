using Lab04_Bai07.SignUp;
using System;
using System.Net;
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
            this.Hide();
        }
        private async void button_Sign_In_Click(object sender, EventArgs e)
        {
            string username = textBox_Username.Text;
            string password = textBox_Password.Text;

            var url = "https://nt106.uitiot.vn/auth/token";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("grant_type", "password")
                    });
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đăng nhập thất bại: " + responseString);
                        return;
                    }

                    JObject responseObject = JObject.Parse(responseString);

                    // Lưu Token vào Session
                    Session.TokenType = responseObject["token_type"].ToString();
                    Session.AccessToken = responseObject["access_token"].ToString();
                    MessageBox.Show("Đăng nhập thành công!");

                    // Chuyển sang MainMenu
                    var mainMenu = new Lab04_Bai07.Client.Main_Menu.MainMenu();
                    mainMenu.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        private void label_Title_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
