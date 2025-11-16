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
    /// Form đọc số - Lab01 Bài 03
    /// Chức năng: Nhập một chữ số (0-9) và chuyển đổi thành cách đọc tiếng Việt
    /// </summary>
    public partial class Lab01_Bai03 : Form
    {
        /// <summary>
        /// Constructor - Khởi tạo form
        /// </summary>
        public Lab01_Bai03()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập giao diện ban đầu
        /// </summary>
        private void Lab01_Bai03_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Đọc số";
            
            // Thiết lập TextBox kết quả chỉ đọc
            textBox_ket_qua.ReadOnly = true;
            
            // Đặt focus vào ô nhập số
            textBox_nhap_so.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Đọc" - Chuyển đổi số thành cách đọc tiếng Việt
        /// </summary>
        private void button_doc_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation đầu vào
                if (string.IsNullOrWhiteSpace(textBox_nhap_so.Text))
                {
                    MessageBox.Show("Vui lòng nhập một số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_nhap_so.Focus();
                    return;
                }

                // Lấy chuỗi input và loại bỏ khoảng trắng
                string input = textBox_nhap_so.Text.Trim();
                
                // Kiểm tra input có phải là một chữ số duy nhất không
                if (input.Length != 1 || !char.IsDigit(input[0]))
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên từ 0 đến 9!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_nhap_so.Focus();
                    return;
                }

                // Chuyển đổi chuỗi thành số nguyên
                int soNguyen = int.Parse(input);

                // Chuyển đổi số thành cách đọc tiếng Việt bằng switch-case
                string ketQua;
                switch (soNguyen)
                {
                    case 0:
                        ketQua = "Không";
                        break;
                    case 1:
                        ketQua = "Một";
                        break;
                    case 2:
                        ketQua = "Hai";
                        break;
                    case 3:
                        ketQua = "Ba";
                        break;
                    case 4:
                        ketQua = "Bốn";
                        break;
                    case 5:
                        ketQua = "Năm";
                        break;
                    case 6:
                        ketQua = "Sáu";
                        break;
                    case 7:
                        ketQua = "Bảy";
                        break;
                    case 8:
                        ketQua = "Tám";
                        break;
                    case 9:
                        ketQua = "Chín";
                        break;
                    default:
                        ketQua = "Số không hợp lệ";
                        break;
                }

                // Hiển thị kết quả đọc số
                textBox_ket_qua.Text = ketQua;
            }
            catch (FormatException)
            {
                // Xử lý lỗi định dạng số không hợp lệ
                MessageBox.Show("Vui lòng nhập một số hợp lệ từ 0 đến 9!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_nhap_so.Focus();
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện click nút "Xóa" - Xóa nội dung các ô nhập liệu và kết quả
        /// </summary>
        private void button_xoa_Click(object sender, EventArgs e)
        {
            // Xóa nội dung cả hai TextBox
            textBox_nhap_so.Clear();
            textBox_ket_qua.Clear();
            
            // Đặt focus về ô nhập số
            textBox_nhap_so.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Thoát" - Đóng form
        /// </summary>
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sự kiện click label kết quả (không sử dụng)
        /// </summary>
        private void label_ket_qua_Click(object sender, EventArgs e)
        {
            // Sự kiện không được sử dụng
        }

        /// <summary>
        /// Sự kiện thay đổi nội dung TextBox nhập số (không sử dụng)
        /// </summary>
        private void textBox_nhap_so_TextChanged(object sender, EventArgs e)
        {
            // Sự kiện không được sử dụng
        }
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 03 ===

1. CHỨC NĂNG CHÍNH:
   - Đọc số: Chuyển đổi một chữ số (0-9) thành cách đọc tiếng Việt
   - Sử dụng cấu trúc switch-case để ánh xạ số sang chữ

2. THÀNH PHẦN GIAO DIỆN:
   - 1 TextBox input: nhập một chữ số từ 0-9
   - 1 TextBox output: hiển thị cách đọc tiếng Việt (readonly)
   - 3 Button: đọc, xóa, thoát
   - Labels mô tả cho input và output

3. THUẬT TOÁN CHUYỂN ĐỔI:
   - Input validation: Kiểm tra chỉ nhận một chữ số duy nhất
   - Switch-case mapping: Ánh xạ từ số (0-9) sang cách đọc tiếng Việt
   - 10 cases cụ thể cho các chữ số từ 0 đến 9

4. LOGIC XỬ LÝ:
   - Input validation: Kiểm tra độ dài và tính hợp lệ của chữ số
   - Character validation: Sử dụng char.IsDigit() để kiểm tra
   - Conversion: Switch-case cho chuyển đổi trực tiếp
   - Output: Hiển thị cách đọc vào TextBox readonly

5. XỬ LÝ LỖI:
   - Length validation: Chỉ chấp nhận một ký tự
   - Digit validation: Chỉ chấp nhận chữ số 0-9
   - FormatException: Xử lý lỗi parse
   - User guidance: Hướng dẫn nhập đúng định dạng

6. TÍNH NĂNG ĐẶC BIỆT:
   - Single digit focus: Chỉ xử lý một chữ số tại một thời điểm
   - Vietnamese mapping: Bảng ánh xạ chuẩn tiếng Việt
   - Clear function: Reset form để nhập lại
   - Input restriction: Ngăn nhập nhiều hơn một chữ số
*/
