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
    /// Form máy tính cộng hai số - Lab01 Bài 01
    /// Chức năng: Nhập hai số và thực hiện phép cộng đơn giản
    /// </summary>
    public partial class Lab01_Bai01 : Form
    {
        /// <summary>
        /// Constructor - Khởi tạo form
        /// </summary>
        public Lab01_Bai01()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập tiêu đề và giao diện ban đầu
        /// </summary>
        private void Lab01_Bai01_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Máy tính cộng hai số";
            
            // Đặt focus vào ô nhập số thứ nhất
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
        /// Sự kiện click label số thứ hai (không sử dụng)
        /// </summary>
        private void label_so_thu_hai_Click(object sender, EventArgs e)
        {
            // Sự kiện không được sử dụng
        }

        /// <summary>
        /// Sự kiện click label kết quả (không sử dụng)
        /// </summary>
        private void label_ket_qua_Click(object sender, EventArgs e)
        {
            // Sự kiện không được sử dụng
        }

        /// <summary>
        /// Sự kiện thay đổi nội dung TextBox số thứ nhất
        /// </summary>
        private void textBox_so_thu_nhat_TextChanged(object sender, EventArgs e)
        {
            // Có thể xóa kết quả khi người dùng thay đổi input
            // textBox_ket_qua.Clear();
        }

        /// <summary>
        /// Sự kiện thay đổi nội dung TextBox số thứ hai
        /// </summary>
        private void textBox_so_thu_hai_TextChanged(object sender, EventArgs e)
        {
            // Có thể xóa kết quả khi người dùng thay đổi input
            // textBox_ket_qua.Clear();
        }

        /// <summary>
        /// Sự kiện thay đổi nội dung TextBox kết quả (không sử dụng)
        /// </summary>
        private void textBox_ket_qua_TextChanged(object sender, EventArgs e)
        {
            // Sự kiện không được sử dụng
        }

        /// <summary>
        /// Sự kiện click nút "Xóa" - Xóa tất cả các ô nhập liệu
        /// </summary>
        private void button_xoa_Click(object sender, EventArgs e)
        {
            // Xóa nội dung tất cả các TextBox
            textBox_so_thu_nhat.Clear();
            textBox_so_thu_hai.Clear();
            textBox_ket_qua.Clear();
            
            // Đặt focus về ô nhập số thứ nhất
            textBox_so_thu_nhat.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Tính toán" - Thực hiện phép cộng hai số
        /// </summary>
        private void button_ket_qua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation đầu vào cho số thứ nhất
                if (string.IsNullOrWhiteSpace(textBox_so_thu_nhat.Text))
                {
                    MessageBox.Show("Vui lòng nhập số thứ nhất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_so_thu_nhat.Focus();
                    return;
                }

                // Kiểm tra validation đầu vào cho số thứ hai
                if (string.IsNullOrWhiteSpace(textBox_so_thu_hai.Text))
                {
                    MessageBox.Show("Vui lòng nhập số thứ hai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_so_thu_hai.Focus();
                    return;
                }

                // Chuyển đổi chuỗi input thành số thực
                double soThuNhat = double.Parse(textBox_so_thu_nhat.Text.Trim());
                double soThuHai = double.Parse(textBox_so_thu_hai.Text.Trim());

                // Thực hiện phép cộng
                double ketQua = soThuNhat + soThuHai;

                // Hiển thị kết quả
                textBox_ket_qua.Text = ketQua.ToString();
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
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 01 ===

1. CHỨC NĂNG CHÍNH:
   - Máy tính cộng hai số đơn giản
   - Nhập hai số thực và hiển thị kết quả phép cộng

2. THÀNH PHẦN GIAO DIỆN:
   - 3 TextBox: nhập số thứ nhất, số thứ hai, hiển thị kết quả
   - 2 Button: tính toán và xóa
   - Labels mô tả cho các ô nhập

3. LOGIC XỬ LÝ:
   - Validation: Kiểm tra input không được để trống
   - Parse: Chuyển đổi string sang double
   - Calculation: Thực hiện phép cộng đơn giản
   - Display: Hiển thị kết quả ra TextBox

4. XỬ LÝ LỖI:
   - FormatException: Khi input không phải số hợp lệ
   - Validation: Thông báo khi thiếu input
   - Focus management: Đưa con trỏ về ô cần nhập

5. TÍNH NĂNG:
   - Clear function: Xóa tất cả input và reset form
   - Error handling: Xử lý lỗi với MessageBox thân thiện
   - Input validation: Đảm bảo dữ liệu hợp lệ trước khi tính toán
*/
