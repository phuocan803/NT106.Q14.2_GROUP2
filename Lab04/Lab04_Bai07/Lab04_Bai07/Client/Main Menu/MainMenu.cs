using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Lab04_Bai07;

namespace Lab04_Bai07.Client.Main_Menu
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            LoadFoodList();
        }
        private async void LoadFoodList()
        {
            var url = "https://nt106.uitiot.vn/api/v1/food?page=1&page_size=5";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JObject.Parse(responseString);

                var foodArray = responseObject["data"];
                flowLayoutPanel1.Controls.Clear();

                foreach (var food in foodArray)
                {
                    var name = food["ten_mon_an"].ToString();
                    var price = food["gia"].ToString();
                    var address = food["dia_chi"].ToString();
                    var description = food["mo_ta"].ToString();

                    var label = new Label
                    {
                        Text = $"{name} - {price}đ\n{address}\n{description}",
                        AutoSize = true,
                        Padding = new Padding(10)
                    };

                    flowLayoutPanel1.Controls.Add(label);
                }
            }
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
