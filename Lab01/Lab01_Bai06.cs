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
    /// Form tính toán các giá trị - Lab01 Bài 06
    /// Chức năng: Thực hiện hai loại tính toán khác nhau dựa trên lựa chọn người dùng
    /// - Bằng cửu chương: Tính B - A rồi hiển thị bảng cửu chương của kết quả
    /// - Tính toán giá trị: Tính (A-B)! và tổng S = A¹ + A² + ... + A^B
    /// </summary>
    public partial class Lab01_Bai06 : Form
    {
        /// <summary>
        /// Constructor - Khởi tạo form và ComboBox
        /// </summary>
        public Lab01_Bai06()
        {
            InitializeComponent();
            KhoiTaoComboBox();
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập giao diện ban đầu
        /// </summary>
        private void Lab01_Bai06_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Bài 06 - Tính toán các giá trị";
            
            // Thiết lập TextBox kết quả
            textBox_ket_qua.ReadOnly = true;
            textBox_ket_qua.Multiline = true;
            textBox_ket_qua.ScrollBars = ScrollBars.Vertical;
            
            // Đặt focus vào ô nhập đầu tiên
            textBox_nhap_a.Focus();
        }

        /// <summary>
        /// Khởi tạo các lựa chọn trong ComboBox
        /// </summary>
        private void KhoiTaoComboBox()
        {
            // Thêm các tùy chọn tính toán vào ComboBox
            comboBox_loai.Items.Add("Bằng cửu chương");
            comboBox_loai.Items.Add("Tính toán giá trị");
            comboBox_loai.SelectedIndex = 0; // Thiết lập lựa chọn mặc định
        }

        /// <summary>
        /// Tính giai thừa của một số
        /// </summary>
        /// <param name="n">Số cần tính giai thừa</param>
        /// <returns>Kết quả giai thừa</returns>
        private long TinhGiaiThua(int n)
        {
            if (n <= 1)
                return 1;
            
            long ketQua = 1;
            for (int i = 2; i <= n; i++)
            {
                ketQua *= i;
            }
            return ketQua;
        }

        /// <summary>
        /// Sự kiện click nút "Tính" - Thực hiện tính toán dựa trên lựa chọn
        /// </summary>
        private void button_tinh_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation cho giá trị A
                if (string.IsNullOrWhiteSpace(textBox_nhap_a.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá trị A!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_nhap_a.Focus();
                    return;
                }

                // Kiểm tra validation cho giá trị B
                if (string.IsNullOrWhiteSpace(textBox_nhap_b.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá trị B!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_nhap_b.Focus();
                    return;
                }

                // Kiểm tra đã chọn loại tính toán chưa
                if (comboBox_loai.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại tính toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox_loai.Focus();
                    return;
                }

                // Chuyển đổi giá trị input thành số nguyên
                int A = int.Parse(textBox_nhap_a.Text.Trim());
                int B = int.Parse(textBox_nhap_b.Text.Trim());

                // Lấy lựa chọn từ ComboBox
                string luaChonDuocChon = comboBox_loai.SelectedItem.ToString();
                StringBuilder ketQua = new StringBuilder();

                if (luaChonDuocChon == "Bằng cửu chương")
                {
                    // Tính B - A
                    int ketQuaTru = B - A;
                    ketQua.AppendLine($"Tính toán: B - A = {B} - {A} = {ketQuaTru}");
                    ketQua.AppendLine();
                    
                    // Hiển thị bảng cửu chương của kết quả
                    if (ketQuaTru <= 0)
                    {
                        ketQua.AppendLine($"Không thể hiển thị bảng cửu chương cho số {ketQuaTru} (phải là số dương)");
                    }
                    else
                    {
                        ketQua.AppendLine($"Bảng cửu chương của {ketQuaTru}:");
                        ketQua.AppendLine(new string('=', 20));
                        
                        // In bảng cửu chương từ 1 đến 10
                        for (int i = 1; i <= 10; i++)
                        {
                            int tichSo = ketQuaTru * i;
                            ketQua.AppendLine($"{ketQuaTru} x {i} = {tichSo}");
                        }
                    }
                }
                else if (luaChonDuocChon == "Tính toán giá trị")
                {
                    // Kiểm tra A < B
                    if (A < B)
                    {
                        MessageBox.Show("(A-B)! Không hợp lệ vì A < B", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tính (A-B)!
                    int hieuAB = A - B;
                    long giaiThua = TinhGiaiThua(hieuAB);
                    
                    ketQua.AppendLine($"Tính (A-B)! = ({A} - {B})! = {hieuAB}! = {giaiThua}");
                    ketQua.AppendLine();

                    // Tính tổng S = A¹ + A² + A³ + ... + A^B
                    if (B <= 0)
                    {
                        MessageBox.Show("Giá trị B phải là số nguyên dương để tính tổng lũy thừa!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    long tongS = 0;
                    ketQua.AppendLine($"Tính tổng S = A¹ + A² + A³ + ... + A^B:");
                    ketQua.AppendLine($"Với A = {A}, B = {B}");
                    ketQua.AppendLine();

                    // Tính từng lũy thừa và cộng dồn
                    for (int i = 1; i <= B; i++)
                    {
                        long luyThua = (long)Math.Pow(A, i);
                        tongS += luyThua;
                        
                        // Hiển thị tất cả số hạng nếu B <= 10, hoặc chỉ hiển thị 10 số hạng đầu
                        if (B <= 10 || i <= 10)
                        {
                            if (i == 1)
                                ketQua.Append($"S = {A}^{i}");
                            else
                                ketQua.Append($" + {A}^{i}");
                        }
                        else if (i == 11)
                        {
                            ketQua.Append(" + ...");
                        }
                    }
                    
                    ketQua.AppendLine();
                    ketQua.AppendLine($"S = {tongS:N0}");
                    
                    // Hiển thị kết quả tổng hợp
                    ketQua.AppendLine();
                    ketQua.AppendLine("=== KẾT QUẢ TỔNG HỢP ===");
                    ketQua.AppendLine($"(A - B)! = ({A} - {B})! = {giaiThua}");
                    ketQua.AppendLine($"Tổng S = {A}^1 + {A}^2 + ... + {A}^{B} = {tongS:N0}");
                }

                // Hiển thị kết quả
                textBox_ket_qua.Text = ketQua.ToString();
            }
            catch (FormatException)
            {
                // Xử lý lỗi định dạng số không hợp lệ
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho A và B!", "Lỗi định dạng", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                // Xử lý lỗi tràn số
                MessageBox.Show("Giá trị quá lớn! Vui lòng nhập số nhỏ hơn.", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện click nút "Xóa" - Reset toàn bộ form
        /// </summary>
        private void button_xoa_Click(object sender, EventArgs e)
        {
            // Xóa nội dung tất cả các TextBox
            textBox_nhap_a.Clear();
            textBox_nhap_b.Clear();
            textBox_ket_qua.Clear();
            
            // Reset ComboBox về lựa chọn mặc định
            comboBox_loai.SelectedIndex = 0;
            
            // Đặt focus về ô nhập đầu tiên
            textBox_nhap_a.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Thoát" - Đóng form
        /// </summary>
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sự kiện click label (không sử dụng)
        /// </summary>
        private void label2_Click(object sender, EventArgs e)
        {
            // Giữ phương thức trống như cũ
        }

        /// <summary>
        /// Sự kiện thay đổi nội dung TextBox (không sử dụng)
        /// </summary>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Giữ phương thức trống như cũ
        }

        /// <summary>
        /// Sự kiện thay đổi lựa chọn ComboBox (không sử dụng)
        /// </summary>
        private void comboBox_loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Phương thức trống cho sự kiện thay đổi lựa chọn ComboBox
        }
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 06 ===

1. CHỨC NĂNG CHÍNH:
   - Ứng dụng đa chức năng với 2 loại tính toán khác nhau
   - Sử dụng ComboBox để chọn loại tính toán
   - Tính toán và hiển thị kết quả chi tiết

2. THÀNH PHẦN GIAO DIỆN:
   - 2 TextBox input: nhập giá trị A và B
   - 1 ComboBox: chọn loại tính toán
   - 1 TextBox output: hiển thị kết quả (multiline, scrollable)
   - 3 Button: tính, xóa, thoát

3. HAI CHỨC NĂNG CHÍNH:
   a) Bằng cửu chương: Tính B - A rồi hiển thị bảng cửu chương của kết quả
   b) Tính toán giá trị: Tính (A-B)! và tổng S = A¹ + A² + ... + A^B

4. LOGIC TÍNH TOÁN:
   - Multiplication table: Tính B-A rồi hiển thị bảng cửu chương của kết quả
   - Factorial: Tính (A-B)! với validation A >= B
   - Power series: Tính tổng chuỗi lũy thừa với vòng lặp
   - Result formatting: Định dạng đẹp với dòng kẻ phân cách

5. XỬ LÝ ĐẶC BIỆT:
   - A < B validation: Hiển thị lỗi "(A-B)! Không hợp lệ vì A < B"
   - Factorial calculation: Thuật toán tính giai thừa hiệu quả
   - Overflow handling: Xử lý số quá lớn với long
   - Mathematical precision: Sử dụng Math.Pow cho lũy thừa

6. TÍNH NĂNG MỚI:
   - Factorial function: Hàm TinhGiaiThua() riêng biệt
   - Validation logic: Kiểm tra A >= B trước khi tính giai thừa
   - Combined results: Hiển thị cả (A-B)! và tổng S
   - Error messages: Thông báo lỗi cụ thể theo yêu cầu

7. VÍ DỤ HOẠT ĐỘNG:
   - Input: A=5, B=2
   - Output: (A-B)! = (5-2)! = 3! = 6
   - Tổng S = 5¹ + 5² = 5 + 25 = 30
   - Nếu A < B: Hiển thị MessageBox lỗi
*/
