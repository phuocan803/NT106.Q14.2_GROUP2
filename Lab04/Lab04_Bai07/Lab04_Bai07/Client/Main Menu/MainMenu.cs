using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab04_Bai07.Client.Main_Menu
{
    public partial class MainMenu : Form
    {
        // Biến quản lý trạng thái
        private int currentPage = 1;
        private int pageSize = 5;
        private bool isMyFood = false;

        public MainMenu()
        {
            InitializeComponent();

            // CẤU HÌNH GIAO DIỆN 
            comboBox_Page_Size.Items.AddRange(new object[] { "5", "10", "15", "20" });
            comboBox_Page_Size.SelectedIndex = 0;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadFoodList();
        }

        // --- XỬ LÝ CHUYỂN TAB ---
        private void tabControl_Food_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            isMyFood = tabControl_Food_List.SelectedIndex == 1;

            // Reset về page 1 mỗi khi chuyển tab
            currentPage = 1;
            comboBox_Page.Items.Clear();
            comboBox_Page.Text = "1";

            LoadFoodList();
        }

        // TẢI DANH SÁCH MÓN ĂN 
        private async void LoadFoodList()
        {
            var url = isMyFood
                ? "https://nt106.uitiot.vn/api/v1/monan/my-dishes"
                : "https://nt106.uitiot.vn/api/v1/monan/all";

            FlowLayoutPanel targetPanel = isMyFood ? flowLayoutPanel_MyFood : flowLayoutPanel_All;

            try
            {
                targetPanel.SuspendLayout();

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    var body = new JObject
                    {
                        ["current"] = currentPage,
                        ["pageSize"] = pageSize
                    };
                    Console.WriteLine($"Đang yêu cầu: Page {currentPage}, Size {pageSize}");
                    var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = JObject.Parse(responseString);
                        var data = jsonResponse["data"];
                        var pagination = jsonResponse["pagination"];
                        int totalFromApi = (int)pagination["total"];
                        DisplayFoodItems(data, targetPanel);

                        if (pagination != null)
                        {
                            UpdatePagination(pagination);
                        }
                    }
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            MessageBox.Show("Phiên đăng nhập hết hạn.");
                            this.Close();
                        }
                        else
                        {
                            targetPanel.Controls.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                targetPanel.ResumeLayout();
            }
        }

        // HIỂN THỊ MÓN ĂN 
        private void DisplayFoodItems(JToken foodArray, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();

            // Kiểm tra danh sách rỗng
            if (foodArray == null || !foodArray.HasValues)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Không tìm thấy món ăn nào.";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.Padding = new Padding(20);
                panel.Controls.Add(lblEmpty);
                return;
            }

            foreach (var food in foodArray)
            {
                // 1. TẠO PANEL CHÍNH 
                Panel pnl = new Panel();
                pnl.Width = panel.Width - 30; 
                pnl.Height = 150;             
                pnl.BackColor = Color.White;
                pnl.Padding = new Padding(5);
                pnl.Margin = new Padding(0, 0, 0, 10); 

                // 2. TẠO KHUNG ẢNH (PICTURE BOX) 
                PictureBox picFood = new PictureBox();
                picFood.Size = new Size(140, 140); 
                picFood.Location = new Point(5, 5);
                picFood.SizeMode = PictureBoxSizeMode.Zoom; 
                picFood.BackColor = Color.WhiteSmoke; 

                // Tải ảnh từ URL (nếu có)
                string imgUrl = food["hinh_anh"]?.ToString();
                if (!string.IsNullOrEmpty(imgUrl) && imgUrl.StartsWith("http"))
                {
                    try
                    {
                        picFood.LoadAsync(imgUrl); 
                    }
                    catch {  }
                }

                // 3. CÁC THÔNG TIN TEXT 
                int leftMargin = 155; 

                // Tên món - Giá
                Label lblName = new Label();
                lblName.Text = $"{food["ten_mon_an"]} - {food["gia"]} VNĐ";
                lblName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblName.ForeColor = Color.DarkSlateBlue;
                lblName.AutoSize = true;
                lblName.Location = new Point(leftMargin, 5);

                // Địa chỉ
                Label lblAddr = new Label();
                lblAddr.Text = $"📍 {food["dia_chi"]}";
                lblAddr.Font = new Font("Segoe UI", 10);
                lblAddr.Location = new Point(leftMargin, 35);
                lblAddr.AutoSize = true;

                // Mô tả
                Label lblDesc = new Label();
                string desc = food["mo_ta"]?.ToString() ?? "";
                if (desc.Length > 80) desc = desc.Substring(0, 80) + "..."; // Cắt ngắn nếu dài quá
                lblDesc.Text = desc;
                lblDesc.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                lblDesc.ForeColor = Color.Gray;
                lblDesc.Location = new Point(leftMargin, 60);
                lblDesc.AutoSize = true;
                lblDesc.MaximumSize = new Size(pnl.Width - leftMargin - 10, 0); // Tự xuống dòng

                // 4. NÚT XÓA (TAB TÔI ĐÓNG GÓP) HOẶC NGƯỜI ĐĂNG (TAB CỘNG ĐỒNG)
                if (isMyFood)
                {
                    //Button btnDel = new Button();
                    //btnDel.Text = "Xóa";
                    //btnDel.BackColor = Color.IndianRed;
                    //btnDel.ForeColor = Color.White;
                    //btnDel.FlatStyle = FlatStyle.Flat;
                    //btnDel.FlatAppearance.BorderSize = 0;
                    //btnDel.Size = new Size(60, 30);
                    // Neo góc phải trên
                    //btnDel.Location = new Point(pnl.Width - 70, 10);
                    //btnDel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    //btnDel.Click += async (s, e) => { await DeleteFood(food["id"].ToString()); };
                    //pnl.Controls.Add(btnDel);
                }
                else
                {
                    // Tab Cộng Đồng: Hiện tên người đóng góp
                    Label lblUser = new Label();
                    lblUser.Text = $"👤 Đóng góp: {food["nguoi_dong_gop"]}";
                    lblUser.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    lblUser.ForeColor = Color.DarkGray;
                    lblUser.Location = new Point(leftMargin, 120); // Nằm dưới cùng
                    lblUser.AutoSize = true;
                    pnl.Controls.Add(lblUser);
                }

                // Add các control vào Panel
                pnl.Controls.Add(picFood);
                pnl.Controls.Add(lblName);
                pnl.Controls.Add(lblAddr);
                pnl.Controls.Add(lblDesc);

                // Add Panel vào danh sách
                panel.Controls.Add(pnl);
            }
        }
        // CẬP NHẬT PHÂN TRANG 
        private void UpdatePagination(JToken pagination)
        {
            int totalItems = (int)pagination["total"];

            // Tính toán số trang
            int totalPages = totalItems / pageSize;
            if (totalItems % pageSize != 0) totalPages++;
            if (totalPages == 0) totalPages = 1;

            // Xóa sự kiện để tránh lỗi lặp vô tận khi thay đổi Items
            comboBox_Page.SelectedIndexChanged -= comboBox_Page_SelectedIndexChanged;

            // Luôn xóa và thêm lại để đảm bảo chính xác (Bỏ logic if count != total cũ đi)
            comboBox_Page.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                comboBox_Page.Items.Add(i.ToString());
            }
            if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }
            comboBox_Page.Text = currentPage.ToString();

            
        }
        private void comboBox_Page_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBox_Page.SelectedItem?.ToString(), out int page))
            {
                if (currentPage != page)
                {
                    currentPage = page;
                    LoadFoodList();
                }
            }
        }
        private void comboBox_Page_Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(comboBox_Page_Size.SelectedItem?.ToString(), out int size))
            {
                pageSize = size;
                currentPage = 1;
                LoadFoodList();
            }
        }
        // XÓA MÓN ĂN 
        private async Task DeleteFood(string foodId)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    var response = await client.DeleteAsync($"https://nt106.uitiot.vn/api/v1/monan/{foodId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadFoodList(); 
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button_Add_Food_Click(object sender, EventArgs e)
        {
            var f = new AddFood.AddFood();
            f.ShowDialog();
            LoadFoodList();
        }

        private async void button_Choose_Food_Click(object sender, EventArgs e)
        {
            // api random
            string url = "https://nt106.uitiot.vn/api/v1/monan/all";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue(Session.TokenType, Session.AccessToken);

                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                        string msg = $"GỢI Ý MÓN ĂN:\n\n" +
                                     $"{json["ten_mon_an"]}\n" +
                                     $"{json["dia_chi"]}";
                        MessageBox.Show(msg, "Ăn gì giờ?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy món nào!");
                    }
                }
            }
            catch { }
        }

        private void flowLayoutPanel_All_Paint(object sender, PaintEventArgs e) 
        {
        
        }
        private void flowLayoutPanel_MyFood_Paint(object sender, PaintEventArgs e) 
        {
        
        }
    }
}