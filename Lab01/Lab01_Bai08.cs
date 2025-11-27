using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace NT106_Lab01
{
    /// <summary>
    /// Form phân tích dữ liệu học sinh - Lab01 Bài 08
    /// Chức năng: Nhập và phân tích dữ liệu học sinh theo định dạng chuỗi
    /// Format: "Họ tên, điểm1, điểm2, điểm3, ..."
    /// </summary>
    public partial class Lab01_Bai08 : Form
    {
        /// <summary>
        /// Constructor - Khởi tạo form
        /// </summary>
        public Lab01_Bai08()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện click nút "Tính toán" - Phân tích dữ liệu học sinh và hiển thị kết quả
        /// </summary>
        private void button_tinh_toan_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa kết quả trước đó
                XoaKetQuaTruocDo();
                
                string duLieuNhap = textBox_nhap_du_lieu.Text.Trim();
                
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(duLieuNhap))
                {
                    HienThiLoi("Vui lòng nhập dữ liệu!");
                    return;
                }

                // Phân tích dữ liệu học sinh
                var ketQuaPhanTich = PhanTichDuLieuHocSinh(duLieuNhap);
                
                if (!ketQuaPhanTich.HopLe)
                {
                    HienThiLoi(ketQuaPhanTich.ThongBaoLoi);
                    return;
                }

                // Hiển thị kết quả phân tích
                HienThiKetQua(ketQuaPhanTich.TenHocSinh, ketQuaPhanTich.DanhSachDiem);
                HienThiThanhCong("Đã nhập đúng format!");
            }
            catch (Exception ex)
            {
                HienThiLoi($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Phân tích chuỗi dữ liệu học sinh thành tên và danh sách điểm
        /// </summary>
        /// <param name="duLieuNhap">Chuỗi dữ liệu đầu vào</param>
        /// <returns>Kết quả phân tích bao gồm tính hợp lệ, thông báo lỗi, tên học sinh và điểm số</returns>
        private (bool HopLe, string ThongBaoLoi, string TenHocSinh, List<double> DanhSachDiem) PhanTichDuLieuHocSinh(string duLieuNhap)
        {
            try
            {
                // Tách chuỗi theo dấu phẩy và loại bỏ khoảng trắng thừa
                string[] cacPhan = duLieuNhap.Split(',').Select(s => s.Trim()).ToArray();
                
                // Kiểm tra số lượng phần tối thiểu (tên + ít nhất 1 điểm)
                if (cacPhan.Length < 2)
                {
                    return (false, "Sai format! Cần có ít nhất họ tên và 1 điểm.", "", null);
                }

                // Lấy tên học sinh (phần đầu tiên)
                string tenHocSinh = cacPhan[0];
                
                if (string.IsNullOrEmpty(tenHocSinh))
                {
                    return (false, "Sai format! Họ tên không được để trống.", "", null);
                }

                // Phân tích các điểm số
                List<double> danhSachDiem = new List<double>();
                
                for (int i = 1; i < cacPhan.Length; i++)
                {
                    // Thử chuyển đổi chuỗi thành số thực
                    if (double.TryParse(cacPhan[i], NumberStyles.Float, CultureInfo.InvariantCulture, out double diem))
                    {
                        // Kiểm tra điểm trong khoảng hợp lệ (0-10)
                        if (diem < 0 || diem > 10)
                        {
                            return (false, $"Sai format! Điểm phải từ 0 đến 10. Điểm '{cacPhan[i]}' không hợp lệ.", "", null);
                        }
                        danhSachDiem.Add(diem);
                    }
                    else
                    {
                        return (false, $"Sai format! '{cacPhan[i]}' không phải là điểm số hợp lệ.", "", null);
                    }
                }

                // Kiểm tra có ít nhất một điểm
                if (danhSachDiem.Count == 0)
                {
                    return (false, "Sai format! Cần có ít nhất 1 điểm số.", "", null);
                }

                return (true, "", tenHocSinh, danhSachDiem);
            }
            catch (Exception ex)
            {
                return (false, $"Sai format! Lỗi phân tích dữ liệu: {ex.Message}", "", null);
            }
        }

        /// <summary>
        /// Hiển thị kết quả phân tích lên giao diện
        /// </summary>
        /// <param name="tenHocSinh">Tên học sinh</param>
        /// <param name="danhSachDiem">Danh sách điểm số</param>
        private void HienThiKetQua(string tenHocSinh, List<double> danhSachDiem)
        {
            // Hiển thị tên học sinh
            textBox_ho_ten.Text = tenHocSinh;

            // Hiển thị danh sách điểm
            StringBuilder danhSachDiemText = new StringBuilder();
            for (int i = 0; i < danhSachDiem.Count; i++)
            {
                danhSachDiemText.AppendLine($"Môn {i + 1}: {danhSachDiem[i]}");
            }
            textBox_danh_sach_diem.Text = danhSachDiemText.ToString();

            // Tính điểm trung bình
            double diemTrungBinh = danhSachDiem.Average();
            textBox_diem_tb.Text = diemTrungBinh.ToString("F2");

            // Tìm điểm cao nhất và thấp nhất
            double diemCaoNhat = danhSachDiem.Max();
            double diemThapNhat = danhSachDiem.Min();
            textBox_diem_cao_nhat.Text = diemCaoNhat.ToString("F1");
            textBox_diem_thap_nhat.Text = diemThapNhat.ToString("F1");

            // Đếm số môn đậu và không đậu (điểm đậu >= 5.0)
            int soMonDau = danhSachDiem.Count(diem => diem >= 5.0);
            int soMonKhongDau = danhSachDiem.Count - soMonDau;
            textBox_mon_dau.Text = soMonDau.ToString();
            textBox_mon_khong_dau.Text = soMonKhongDau.ToString();

            // Tính xếp loại học lực
            string xepLoai = TinhXepLoaiHocLuc(diemTrungBinh, danhSachDiem);
            textBox_xep_loai.Text = xepLoai;
        }

        /// <summary>
        /// Tính xếp loại học lực dựa trên điểm trung bình và điều kiện từng môn
        /// </summary>
        /// <param name="diemTrungBinh">Điểm trung bình</param>
        /// <param name="danhSachDiem">Danh sách điểm các môn</param>
        /// <returns>Xếp loại học lực</returns>
        private string TinhXepLoaiHocLuc(double diemTrungBinh, List<double> danhSachDiem)
        {
            // Giỏi: ĐTB >= 8, không có môn nào < 6.5
            if (diemTrungBinh >= 8.0 && danhSachDiem.All(diem => diem >= 6.5))
            {
                return "Giỏi";
            }
            
            // Khá: ĐTB >= 6.5, không có môn nào < 5
            if (diemTrungBinh >= 6.5 && danhSachDiem.All(diem => diem >= 5.0))
            {
                return "Khá";
            }
            
            // Trung bình: ĐTB >= 5, không có môn nào < 3.5
            if (diemTrungBinh >= 5.0 && danhSachDiem.All(diem => diem >= 3.5))
            {
                return "Trung bình";
            }
            
            // Yếu: ĐTB >= 3.5, không có môn nào < 2
            if (diemTrungBinh >= 3.5 && danhSachDiem.All(diem => diem >= 2.0))
            {
                return "Yếu";
            }
            
            // Kém: Các trường hợp còn lại
            return "Kém";
        }

        /// <summary>
        /// Xóa tất cả kết quả hiển thị trước đó
        /// </summary>
        private void XoaKetQuaTruocDo()
        {
            textBox_ho_ten.Clear();
            textBox_danh_sach_diem.Clear();
            textBox_diem_tb.Clear();
            textBox_diem_cao_nhat.Clear();
            textBox_diem_thap_nhat.Clear();
            textBox_mon_dau.Clear();
            textBox_mon_khong_dau.Clear();
            textBox_xep_loai.Clear();
            label_ket_qua.Text = "";
        }

        /// <summary>
        /// Hiển thị thông báo lỗi với màu đỏ
        /// </summary>
        /// <param name="thongBao">Nội dung thông báo lỗi</param>
        private void HienThiLoi(string thongBao)
        {
            label_ket_qua.Text = $"❌ {thongBao}";
            label_ket_qua.ForeColor = Color.Red;
        }

        /// <summary>
        /// Hiển thị thông báo thành công với màu xanh
        /// </summary>
        /// <param name="thongBao">Nội dung thông báo thành công</param>
        private void HienThiThanhCong(string thongBao)
        {
            label_ket_qua.Text = $"✅ {thongBao}";
            label_ket_qua.ForeColor = Color.Green;
        }
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 08 ===

1. CHỨC NĂNG CHÍNH:
   - Phân tích dữ liệu học sinh từ chuỗi định dạng
   - Tính toán thống kê điểm số và xếp loại học lực
   - Validation dữ liệu đầu vào nghiêm ngặt

2. ĐỊNH DẠNG DỮ LIỆU:
   - Input format: "Họ tên, điểm1, điểm2, điểm3, ..."
   - Tách bằng dấu phẩy (comma-separated values)
   - Hỗ trợ số lượng điểm không giới hạn

3. THÀNH PHẦN GIAO DIỆN:
   - 1 TextBox input: nhập chuỗi dữ liệu
   - 8 TextBox output: hiển thị các thông tin đã phân tích
   - 1 Button: thực hiện phân tích
   - 1 Label: hiển thị trạng thái kết quả

4. THUẬT TOÁN PHÂN TÍCH:
   - String parsing: Tách chuỗi theo dấu phẩy
   - Data validation: Kiểm tra tên và điểm hợp lệ
   - Statistical calculation: Tính các chỉ số thống kê
   - Classification: Xếp loại theo tiêu chuẩn giáo dục

5. CÁC THỐNG KÊ ĐƯỢC TÍNH:
   - Điểm trung bình: Average của tất cả điểm
   - Điểm cao nhất/thấp nhất: Max/Min
   - Số môn đậu/rớt: Đếm theo ngưỡng 5.0
   - Xếp loại học lực: Theo quy định chuẩn

6. QUY TẮC XẾP LOẠI:
   - Giỏi: ĐTB ≥ 8.0, tất cả môn ≥ 6.5
   - Khá: ĐTB ≥ 6.5, tất cả môn ≥ 5.0
   - Trung bình: ĐTB ≥ 5.0, tất cả môn ≥ 3.5
   - Yếu: ĐTB ≥ 3.5, tất cả môn ≥ 2.0
   - Kém: Các trường hợp còn lại

7. XỬ LÝ LỖI VÀ VALIDATION:
   - Format validation: Kiểm tra định dạng chuỗi
   - Name validation: Tên không được rỗng
   - Score validation: Điểm trong khoảng 0-10
   - Count validation: Ít nhất 1 điểm số
   - Type validation: Kiểm tra kiểu số thực

8. TÍNH NĂNG ĐẶC BIỆT:
   - Flexible input: Chấp nhận số lượng điểm bất kỳ
   - Comprehensive statistics: Thống kê đầy đủ
   - Visual feedback: Màu sắc phân biệt lỗi/thành công
   - Cultural formatting: Sử dụng InvariantCulture cho số
   - Real-time validation: Kiểm tra ngay khi nhập
*/
