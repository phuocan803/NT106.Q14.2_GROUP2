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
    /// Form đọc số nâng cao - Lab01 Bài 04
    /// Chức năng: Chuyển đổi số nguyên lớn thành cách đọc tiếng Việt đầy đủ
    /// </summary>
    public partial class Lab01_Bai04 : Form
    {
        /// <summary>
        /// Constructor - Khởi tạo form
        /// </summary>
        public Lab01_Bai04()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập giao diện ban đầu
        /// </summary>
        private void Lab01_Bai04_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Đọc số nâng cao";
            
            // Thiết lập TextBox kết quả
            textBox_ket_qua.ReadOnly = true;
            textBox_ket_qua.Multiline = true;
            textBox_ket_qua.ScrollBars = ScrollBars.Vertical;
            
            // Đặt focus vào ô nhập số
            textBox_nhap_so.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Đọc" - Chuyển đổi số nguyên thành cách đọc tiếng Việt
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

                string input = textBox_nhap_so.Text.Trim();

                // Kiểm tra input chỉ chứa số
                if (!input.All(char.IsDigit))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_nhap_so.Focus();
                    return;
                }

                // Chuyển đổi thành long để xử lý số lớn
                long soNguyen = long.Parse(input);

                // Chuyển đổi số thành cách đọc tiếng Việt
                string ketQua = ChuyenSoThanhChu(soNguyen);

                // Hiển thị kết quả
                textBox_ket_qua.Text = ketQua;
            }
            catch (OverflowException)
            {
                // Xử lý lỗi số quá lớn
                MessageBox.Show("Số quá lớn! Vui lòng nhập số nhỏ hơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_nhap_so.Focus();
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chuyển đổi số nguyên thành cách đọc tiếng Việt
        /// </summary>
        /// <param name="so">Số cần chuyển đổi</param>
        /// <returns>Cách đọc tiếng Việt của số</returns>
        private string ChuyenSoThanhChu(long so)
        {
            // Xử lý trường hợp đặc biệt: số 0
            if (so == 0)
                return "Không";

            // Xử lý số âm
            if (so < 0)
                return "Âm " + ChuyenSoThanhChu(-so);

            string ketQua = "";

            // Xử lý hàng tỷ (billions)
            if (so >= 1000000000)
            {
                ketQua += ChuyenSoThanhChu(so / 1000000000) + " tỷ ";
                so %= 1000000000;
            }

            // Xử lý hàng triệu (millions)
            if (so >= 1000000)
            {
                ketQua += ChuyenSoThanhChu(so / 1000000) + " triệu ";
                so %= 1000000;
            }

            // Xử lý hàng nghìn (thousands)
            if (so >= 1000)
            {
                ketQua += ChuyenSoThanhChu(so / 1000) + " nghìn ";
                so %= 1000;
            }

            // Xử lý hàng trăm (hundreds)
            if (so >= 100)
            {
                ketQua += ChuyenDonViThanhChu(so / 100) + " trăm ";
                so %= 100;
            }

            // Xử lý hàng chục và đơn vị (tens and units)
            if (so >= 20)
            {
                ketQua += ChuyenDonViThanhChu(so / 10) + " mười ";
                so %= 10;
                if (so > 0)
                {
                    // Xử lý trường hợp đặc biệt: "lăm" thay vì "năm" ở cuối
                    if (so == 5)
                        ketQua += "lăm";
                    else
                        ketQua += ChuyenDonViThanhChu(so);
                }
            }
            else if (so >= 10)
            {
                ketQua += "mười ";
                so %= 10;
                if (so > 0)
                {
                    // Xử lý trường hợp đặc biệt: "mười lăm"
                    if (so == 5)
                        ketQua += "lăm";
                    else
                        ketQua += ChuyenDonViThanhChu(so);
                }
            }
            else if (so > 0)
            {
                ketQua += ChuyenDonViThanhChu(so);
            }

            return ketQua.Trim();
        }

        /// <summary>
        /// Chuyển đổi chữ số đơn lẻ (1-9) thành cách đọc tiếng Việt
        /// </summary>
        /// <param name="so">Số đơn lẻ cần chuyển đổi</param>
        /// <returns>Cách đọc tiếng Việt của chữ số</returns>
        private string ChuyenDonViThanhChu(long so)
        {
            switch (so)
            {
                case 1: return "một";
                case 2: return "hai";
                case 3: return "ba";
                case 4: return "bốn";
                case 5: return "năm";
                case 6: return "sáu";
                case 7: return "bảy";
                case 8: return "tám";
                case 9: return "chín";
                default: return "";
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
        /// Sự kiện click label nhập số nguyên (không sử dụng)
        /// </summary>
        private void label_nhap_so_nguyen_Click(object sender, EventArgs e)
        {

        }
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 04 ===

1. CHỨC NĂNG CHÍNH:
   - Đọc số nâng cao: Chuyển đổi số nguyên lớn (long) thành cách đọc tiếng Việt đầy đủ
   - Hỗ trợ số âm và các đơn vị lớn (nghìn, triệu, tỷ)

2. THÀNH PHẦN GIAO DIỆN:
   - 1 TextBox input: nhập số nguyên (có thể rất lớn)
   - 1 TextBox output: hiển thị cách đọc tiếng Việt (multiline, scrollable)
   - 3 Button: đọc, xóa, thoát
   - Labels mô tả chức năng

3. THUẬT TOÁN CHUYỂN ĐỔI:
   - Recursive approach: Hàm đệ quy để xử lý các hàng số lớn
   - Hierarchical processing: Xử lý từ hàng lớn nhất đến nhỏ nhất
   - Special cases: Xử lý "lăm" thay vì "năm" ở cuối từ

4. CẤU TRÚC PHÂN CẤP:
   - Tỷ (1,000,000,000): Hàng tỷ
   - Triệu (1,000,000): Hàng triệu  
   - Nghìn (1,000): Hàng nghìn
   - Trăm (100): Hàng trăm
   - Chục và đơn vị: Xử lý đặc biệt cho "mười", "lăm"

5. LOGIC XỬ LÝ:
   - Input validation: Chỉ chấp nhận chữ số
   - Long parsing: Hỗ trợ số lớn trong phạm vi long
   - Recursive decomposition: Chia nhỏ số theo đơn vị
   - String building: Ghép chuỗi kết quả theo thứ tự

6. TÍNH NĂNG ĐẶC BIỆT:
   - Negative number support: Hỗ trợ số âm
   - Large number handling: Xử lý số lên đến 19 chữ số
   - Vietnamese pronunciation rules: Áp dụng quy tắc phát âm tiếng Việt
   - Multiline output: Hiển thị kết quả dài trên nhiều dòng

7. XỬ LÝ NGOẠI LỆ:
   - OverflowException: Số quá lớn ngoài phạm vi long
   - Format validation: Kiểm tra chỉ chứa chữ số
   - Comprehensive error handling: Thông báo lỗi chi tiết
*/
