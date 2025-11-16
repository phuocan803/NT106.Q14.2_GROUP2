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
    /// Form tìm món ăn ngẫu nhiên - Lab01 Bài 09
    /// Chức năng: Quản lý danh sách món ăn và chọn ngẫu nhiên món ăn
    /// </summary>
    public partial class Lab01_Bai09 : Form
    {
        // Danh sách các món ăn được quản lý
        private List<string> danhSachMonAn;
        
        // Generator số ngẫu nhiên để chọn món ăn
        private Random boTaoSoNgauNhien;

        /// <summary>
        /// Constructor - Khởi tạo form và dữ liệu mặc định
        /// </summary>
        public Lab01_Bai09()
        {
            InitializeComponent();
            boTaoSoNgauNhien = new Random();
            
            // Khởi tạo danh sách món ăn mặc định
            KhoiTaoDanhSachMonAnMacDinh();
        }

        /// <summary>
        /// Khởi tạo danh sách món ăn mặc định với các món phổ biến
        /// </summary>
        private void KhoiTaoDanhSachMonAnMacDinh()
        {
            danhSachMonAn = new List<string>
            {
                "Ăn gì cũng được",
                "Bún riêu",
                "Bún thịt nướng",
                "Cơm tấm sườn trứng",
                "Phở",
                "Gỏi cuốn"
            };
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập giao diện ban đầu
        /// </summary>
        private void Lab01_Bai09_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Tìm món ăn ngẫu nhiên";
            
            // Tải danh sách món ăn vào ListBox
            CapNhatHienThiDanhSachMonAn();
            
            // Xóa kết quả hiển thị
            textBox_ket_qua.Clear();
            
            // Đặt focus vào ô nhập món ăn
            textBox_nhap_mon_an.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Thêm" - Thêm món ăn mới vào danh sách
        /// </summary>
        private void button_them_Click(object sender, EventArgs e)
        {
            string monAnMoi = textBox_nhap_mon_an.Text.Trim();
            
            // Kiểm tra input không được để trống
            if (string.IsNullOrEmpty(monAnMoi))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_nhap_mon_an.Focus();
                return;
            }
            
            // Kiểm tra món ăn đã tồn tại chưa (so sánh không phân biệt hoa thường)
            if (danhSachMonAn.Any(mon => mon.Equals(monAnMoi, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Món ăn này đã có trong danh sách!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_nhap_mon_an.SelectAll();
                textBox_nhap_mon_an.Focus();
                return;
            }
            
            // Thêm món ăn mới vào danh sách
            danhSachMonAn.Add(monAnMoi);
            
            // Cập nhật hiển thị ListBox
            CapNhatHienThiDanhSachMonAn();
            
            // Xóa nội dung ô nhập và đặt focus
            textBox_nhap_mon_an.Clear();
            textBox_nhap_mon_an.Focus();
            
            // Thông báo thành công
            MessageBox.Show($"Đã thêm '{monAnMoi}' vào danh sách!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Sự kiện click nút "Tìm món ăn" - Chọn ngẫu nhiên một món ăn từ danh sách
        /// </summary>
        private void button_tim_mon_an_Click(object sender, EventArgs e)
        {
            // Kiểm tra danh sách có món ăn không
            if (danhSachMonAn.Count == 0)
            {
                MessageBox.Show("Danh sách món ăn trống!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Tạo số ngẫu nhiên để chọn món ăn
            int viTriNgauNhien = boTaoSoNgauNhien.Next(0, danhSachMonAn.Count);
            string monAnDuocChon = danhSachMonAn[viTriNgauNhien];
            
            // Hiển thị món ăn được chọn
            textBox_ket_qua.Text = monAnDuocChon;
            
            // Đánh dấu món ăn được chọn trong ListBox
            listBox_mon_an.SelectedIndex = viTriNgauNhien;
            listBox_mon_an.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Xóa" - Xóa món ăn được chọn khỏi danh sách
        /// </summary>
        private void button_xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra có món ăn nào được chọn không
            if (listBox_mon_an.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string monAnCanXoa = listBox_mon_an.SelectedItem.ToString();
            
            // Xác nhận việc xóa
            DialogResult ketQuaXacNhan = MessageBox.Show($"Bạn có chắc muốn xóa '{monAnCanXoa}' khỏi danh sách?", 
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (ketQuaXacNhan == DialogResult.Yes)
            {
                // Xóa món ăn khỏi danh sách
                danhSachMonAn.Remove(monAnCanXoa);
                
                // Cập nhật hiển thị ListBox
                CapNhatHienThiDanhSachMonAn();
                
                // Xóa kết quả nếu món ăn bị xóa đang được hiển thị
                if (textBox_ket_qua.Text == monAnCanXoa)
                {
                    textBox_ket_qua.Clear();
                }
                
                MessageBox.Show($"Đã xóa '{monAnCanXoa}' khỏi danh sách!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Sự kiện click nút "Thoát" - Đóng ứng dụng với xác nhận
        /// </summary>
        private void button_thoat_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi thoát
            DialogResult ketQuaXacNhan = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (ketQuaXacNhan == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Sự kiện nhấn phím trong TextBox nhập món ăn - Hỗ trợ Enter để thêm nhanh
        /// </summary>
        private void textBox_nhap_mon_an_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép nhấn Enter để thêm món ăn nhanh
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn tiếng beep khi nhấn Enter
                button_them_Click(sender, e);
            }
        }

        /// <summary>
        /// Cập nhật hiển thị danh sách món ăn trong ListBox
        /// </summary>
        private void CapNhatHienThiDanhSachMonAn()
        {
            // Xóa tất cả items trong ListBox
            listBox_mon_an.Items.Clear();
            
            // Thêm tất cả món ăn từ danh sách vào ListBox
            foreach (string monAn in danhSachMonAn)
            {
                listBox_mon_an.Items.Add(monAn);
            }
        }

        /// <summary>
        /// Sự kiện thay đổi nội dung TextBox nhập món ăn (không sử dụng)
        /// </summary>
        private void textBox_nhap_mon_an_TextChanged(object sender, EventArgs e)
        {
            // Sự kiện không được sử dụng
        }
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 09 ===

1. CHỨC NĂNG CHÍNH:
   - Ứng dụng gợi ý món ăn ngẫu nhiên
   - Quản lý danh sách món ăn (thêm, xóa, hiển thị)
   - Chọn ngẫu nhiên món ăn từ danh sách có sẵn

2. THÀNH PHẦN GIAO DIỆN:
   - 1 TextBox input: nhập tên món ăn mới
   - 1 ListBox: hiển thị danh sách tất cả món ăn
   - 1 TextBox output: hiển thị món ăn được chọn ngẫu nhiên
   - 4 Button: thêm, tìm món ăn, xóa, thoát

3. CẤU TRÚC DỮ LIỆU:
   - List<string>: Lưu trữ danh sách món ăn
   - Random: Generator số ngẫu nhiên
   - Default data: 6 món ăn mặc định phổ biến

4. TÍNH NĂNG CHÍNH:
   a) Thêm món ăn:
      - Validation input không rỗng
      - Kiểm tra trùng lặp (case-insensitive)
      - Cập nhật ListBox tự động
   
   b) Tìm món ăn ngẫu nhiên:
      - Random selection từ danh sách
      - Highlight món được chọn trong ListBox
      - Hiển thị kết quả rõ ràng
   
   c) Xóa món ăn:
      - Selection-based deletion
      - Confirmation dialog
      - Auto-clear result nếu cần

5. USER EXPERIENCE:
   - Enter key support: Nhấn Enter để thêm nhanh
   - Auto-focus management: Luôn focus đúng control
   - Confirmation dialogs: Xác nhận các thao tác quan trọng
   - Visual feedback: Selection highlighting trong ListBox

6. DATA MANAGEMENT:
   - Dynamic list: Danh sách thay đổi theo thao tác người dùng
   - Persistent display: ListBox luôn đồng bộ với data
   - Default initialization: Có sẵn 6 món ăn phổ biến
   - Case-insensitive comparison: So sánh không phân biệt hoa thường

7. LOGIC ALGORITHM:
   - Random selection: Random.Next() cho chọn ngẫu nhiên
   - Duplicate detection: LINQ Any() với StringComparison
   - List synchronization: Đồng bộ List và ListBox
   - Event-driven updates: Cập nhật theo sự kiện người dùng

8. ERROR HANDLING:
   - Empty input validation: Kiểm tra input trống
   - Empty list handling: Xử lý danh sách trống
   - Duplicate prevention: Ngăn thêm món trùng
   - Selection validation: Kiểm tra có chọn item để xóa

9. TÍNH NĂNG ĐẶC BIỆT:
   - Real-time synchronization: Đồng bộ ngay lập tức
   - Visual selection feedback: Đánh dấu món được chọn
   - Keyboard shortcut: Enter để thêm nhanh
   - Confirmation dialogs: UX thân thiện và an toàn
*/
