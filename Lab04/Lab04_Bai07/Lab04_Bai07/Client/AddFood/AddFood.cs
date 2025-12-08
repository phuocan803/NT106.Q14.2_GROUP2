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
using Newtonsoft.Json.Linq; 

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
            //
        }

        private void textBox_Food_Name_TextChanged(object sender, EventArgs e)
        {
            //
        }
        private async void button_Add_Click(object sender, EventArgs e)
        {
            string tenMon = textBox_Food_Name.Text;
            string giaRaw = textBox_Price.Text;
            string diaChi = textBox_Address.Text;
            string moTa = textBox_Description.Text;
            string hinhAnh = textBox_Image.Text;

            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(tenMon) || string.IsNullOrWhiteSpace(giaRaw))
            {
                MessageBox.Show("Vui lòng nhập tên món và giá.");
                return;
            }

            // XỬ LÝ GIÁ TIỀN 
            // Xóa ,
            string giaClean = System.Text.RegularExpressions.Regex.Replace(giaRaw, "[^0-9]", "");

            // Nếu không nhập là 0d
            if (string.IsNullOrEmpty(giaClean)) giaClean = "0";

            // API Thêm món
            var url = "https://nt106.uitiot.vn/api/v1/monan/add";

            try
            {
                using (var client = new HttpClient())
                {
                    // Thêm Token xác thực
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    // TẠO JSON BODY 
                    var monAn = new JObject
                    {
                        ["ten_mon_an"] = tenMon,
                        ["gia"] = long.Parse(giaClean), 
                        ["dia_chi"] = diaChi,
                        ["hinh_anh"] = hinhAnh,
                        ["mo_ta"] = moTa
                    };

                    // Đóng gói dữ liệu thành JSON String
                    var content = new StringContent(monAn.ToString(), Encoding.UTF8, "application/json");

                    // Gửi yêu cầu POST
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thêm món ăn thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Thêm món thất bại.\nLỗi: {responseString}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ứng dụng: " + ex.Message);
            }
        }
    }
}