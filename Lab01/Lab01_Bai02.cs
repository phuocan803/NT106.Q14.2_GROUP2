using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_Lab01
{
    /// <summary>
    /// Form tìm số lớn nhất và nhỏ nhất - Lab01 Bài 02
    /// Chức năng: Nhập ba số và tìm ra số lớn nhất và nhỏ nhất trong ba số đó
    /// </summary>
    public partial class Lab01_Bai02 : Form
    {
        /// <summary>
        /// Constructor - Khởi tạo form
        /// </summary>
        public Lab01_Bai02()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập giao diện ban đầu
        /// </summary>
        private void Lab01_Bai02_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Tìm số lớn nhất, nhỏ nhất";
            
            // Thiết lập các TextBox kết quả chỉ đọc
            textBox_so_lon_nhat.ReadOnly = true;
            textBox_so_nho_nhat.ReadOnly = true;
            
            // Đặt focus vào ô nhập đầu tiên
            textBox_so_thu_nhat.Focus();
        }

        /// <summary>
        /// Sự kiện click label số thứ nhất (không sử dụng)
        /// </summary>
        private void label_so_thu_nhat_Click(object sender, EventArgs e)
        {
            // Sự kiện không được sử dụng
        }

        /// <summary>
        /// Sự kiện click nút "Tìm" - Tìm số lớn nhất và nhỏ nhất trong ba số
        /// </summary>
        private void button_tim_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation cho số thứ nhất
                if (string.IsNullOrWhiteSpace(textBox_so_thu_nhat.Text))
                {
                    MessageBox.Show("Vui lòng nhập số thứ nhất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_so_thu_nhat.Focus();
                    return;
                }

                // Kiểm tra validation cho số thứ hai
                if (string.IsNullOrWhiteSpace(textBox_so_thu_hai.Text))
                {
                    MessageBox.Show("Vui lòng nhập số thứ hai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_so_thu_hai.Focus();
                    return;
                }

                // Kiểm tra validation cho số thứ ba
                if (string.IsNullOrWhiteSpace(textBox_so_thu_ba.Text))
                {
                    MessageBox.Show("Vui lòng nhập số thứ ba!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_so_thu_ba.Focus();
                    return;
                }

                // Chuyển đổi chuỗi input thành số thực
                double so1 = double.Parse(textBox_so_thu_nhat.Text.Trim());
                double so2 = double.Parse(textBox_so_thu_hai.Text.Trim());
                double so3 = double.Parse(textBox_so_thu_ba.Text.Trim());

                // Tìm số lớn nhất và nhỏ nhất bằng câu lệnh if-else
                double soLonNhat, soNhoNhat;

                // Tìm số lớn nhất bằng cách so sánh từng cặp
                if (so1 >= so2 && so1 >= so3)
                {
                    soLonNhat = so1; // so1 là số lớn nhất
                }
                else if (so2 >= so1 && so2 >= so3)
                {
                    soLonNhat = so2; // so2 là số lớn nhất
                }
                else
                {
                    soLonNhat = so3; // so3 là số lớn nhất
                }

                // Tìm số nhỏ nhất bằng cách so sánh từng cặp
                if (so1 <= so2 && so1 <= so3)
                {
                    soNhoNhat = so1; // so1 là số nhỏ nhất
                }
                else if (so2 <= so1 && so2 <= so3)
                {
                    soNhoNhat = so2; // so2 là số nhỏ nhất
                }
                else
                {
                    soNhoNhat = so3; // so3 là số nhỏ nhất
                }

                // Hiển thị kết quả vào các TextBox tương ứng
                textBox_so_lon_nhat.Text = soLonNhat.ToString();
                textBox_so_nho_nhat.Text = soNhoNhat.ToString();
            }
            catch (FormatException)
            {
                // Xử lý lỗi định dạng số không hợp lệ
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện click nút "Xóa" - Xóa tất cả các ô nhập liệu và kết quả
        /// </summary>
        private void button_xoa_Click(object sender, EventArgs e)
        {
            // Xóa nội dung tất cả các TextBox
            textBox_so_thu_nhat.Clear();
            textBox_so_thu_hai.Clear();
            textBox_so_thu_ba.Clear();
            textBox_so_lon_nhat.Clear();
            textBox_so_nho_nhat.Clear();
            
            // Đặt focus về ô nhập đầu tiên
            textBox_so_thu_nhat.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Thoát" - Đóng form
        /// </summary>
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 02 ===

1. CHỨC NĂNG CHÍNH:
   - Tìm số lớn nhất và nhỏ nhất trong ba số thực
   - Sử dụng thuật toán so sánh tuần tự với câu lệnh if-else

2. THÀNH PHẦN GIAO DIỆN:
   - 3 TextBox input: nhập ba số cần so sánh
   - 2 TextBox output: hiển thị số lớn nhất và nhỏ nhất (readonly)
   - 3 Button: tìm, xóa, thoát
   - Labels mô tả cho các ô nhập và kết quả

3. THUẬT TOÁN SO SÁNH:
   - Tìm số lớn nhất: So sánh từng số với hai số còn lại
   - Tìm số nhỏ nhất: So sánh từng số với hai số còn lại
   - Sử dụng cấu trúc if-else thay vì Math.Max/Min để rõ ràng logic

4. LOGIC XỬ LÝ:
   - Input validation: Kiểm tra ba số đều được nhập
   - Parsing: Chuyển đổi string sang double
   - Comparison: So sánh ba số theo thuật toán tuần tự
   - Output: Hiển thị kết quả vào TextBox readonly

5. XỬ LÝ LỖI:
   - FormatException: Xử lý input không phải số
   - Validation: Thông báo khi thiếu input
   - Focus management: Hướng dẫn người dùng nhập đúng vị trí

6. TÍNH NĂNG BỔ SUNG:
   - Clear function: Reset toàn bộ form
   - Readonly output: Ngăn người dùng chỉnh sửa kết quả
   - Comprehensive error handling với MessageBox
*/
