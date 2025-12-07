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

namespace Lab04_Bai07.Client.AddFood
{
    public partial class AddFood : Form
    {
        public AddFood()
        {
            InitializeComponent();
        }

        private void textBox_Description_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button_Add_Click(object sender, EventArgs e)
        {
            string tenMon = textBox_Food_Name.Text;
            string gia = textBox_Price.Text;
            string diaChi = textBox_Address.Text;
            string moTa = textBox_Description.Text;
            string hinhAnh = textBox_Image.Text;

            if (string.IsNullOrWhiteSpace(tenMon) || string.IsNullOrWhiteSpace(gia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên món và giá.");
                return;
            }

            var url = "https://nt106.uitiot.vn/api/v1/food";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                var content = new MultipartFormDataContent
                {
                    { new StringContent(tenMon), "ten_mon_an" },
                    { new StringContent(gia), "gia" },
                    { new StringContent(diaChi), "dia_chi" },
                    { new StringContent(moTa), "mo_ta" },
                    { new StringContent(hinhAnh), "hinh_anh" }
                };

                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm món ăn thành công!");
                    this.Close(); // hoặc chuyển về MainMenu
                }
                else
                {
                    MessageBox.Show("Thêm món ăn thất bại: " + responseString);
                }
            }
        }

        private void textBox_Food_Name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
