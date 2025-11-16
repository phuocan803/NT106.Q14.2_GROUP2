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
    /// Form đặt vé xem phim - Lab01 Bài 05
    /// Chức năng: Quản lý việc đặt vé xem phim với các loại ghế khác nhau và giá vé tương ứng
    /// </summary>
    public partial class Lab01_Bai05 : Form
    {
        // Dictionary để lưu thông tin phim và giá vé cơ bản
        private Dictionary<string, ThongTinPhim> danhSachPhim;
        
        // Dictionary để lưu thông tin ghế đã đặt theo từng phòng chiếu
        private Dictionary<string, HashSet<string>> gheOaDat;
        
        // Lưu trữ số lượng vé đã đặt theo phòng chiếu (để kiểm tra giới hạn tối đa 2 phòng)
        private Dictionary<int, int> soLuongVeTheoPhong;
        
        // Dictionary để lưu các button ghế trên giao diện người dùng
        private Dictionary<string, Button> cacNutGhe;
        
        // Danh sách lưu trữ các ghế đang được chọn
        private List<string> gheOangChon;

        /// <summary>
        /// Constructor - Khởi tạo form và các thành phần cần thiết
        /// </summary>
        public Lab01_Bai05()
        {
            InitializeComponent();
            KhoiTaoDuLieu();
            cacNutGhe = new Dictionary<string, Button>();
            gheOangChon = new List<string>();
        }

        /// <summary>
        /// Khởi tạo dữ liệu ban đầu cho ứng dụng
        /// Bao gồm: danh sách phim, phòng chiếu, ghế đã đặt, số lượng vé theo phòng
        /// </summary>
        private void KhoiTaoDuLieu()
        {
            // Khởi tạo dữ liệu phim theo yêu cầu đề bài
            danhSachPhim = new Dictionary<string, ThongTinPhim>
            {
                { "Đào, phở và piano", new ThongTinPhim { GiaCoBan = 45000, DanhSachPhong = new List<int> { 1, 2, 3 } } },
                { "Mai", new ThongTinPhim { GiaCoBan = 100000, DanhSachPhong = new List<int> { 2, 3 } } },
                { "Gặp lại chị bầu", new ThongTinPhim { GiaCoBan = 70000, DanhSachPhong = new List<int> { 1 } } },
                { "Tarot", new ThongTinPhim { GiaCoBan = 90000, DanhSachPhong = new List<int> { 3 } } }
            };

            // Khởi tạo danh sách ghế đã đặt cho mỗi phòng chiếu (ban đầu không có ghế nào được đặt)
            gheOaDat = new Dictionary<string, HashSet<string>>();
            soLuongVeTheoPhong = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } };

            // Tạo HashSet rỗng cho mỗi phòng để lưu danh sách ghế đã đặt
            for (int phong = 1; phong <= 3; phong++)
            {
                gheOaDat[$"Phòng {phong}"] = new HashSet<string>();
            }
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập giao diện ban đầu
        /// </summary>
        private void Lab01_Bai05_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Đặt vé phim";
            
            // Thiết lập textbox kết quả chỉ đọc
            textBox_ket_qua.ReadOnly = true;
            
            // Tải danh sách phim vào ComboBox
            TaiDanhSachPhim();
            
            // Đặt focus vào ô nhập tên
            textBox_ho_ten.Focus();
            
            // Vô hiệu hóa ComboBox phòng chiếu ban đầu
            comboBox_phong_chieu.Enabled = false;
            
            // Tạo layout sơ đồ ghế ngồi
            TaoSoDoGheNgoi();
        }

        /// <summary>
        /// Tải danh sách phim vào ComboBox
        /// </summary>
        private void TaiDanhSachPhim()
        {
            comboBox_phim.Items.Clear();
            comboBox_phim.Items.Add("-- Chọn phim --");
            
            // Thêm tất cả tên phim vào ComboBox
            foreach (var phim in danhSachPhim.Keys)
            {
                comboBox_phim.Items.Add(phim);
            }
            
            comboBox_phim.SelectedIndex = 0;
        }

        /// <summary>
        /// Tạo sơ đồ ghế ngồi trực quan trên giao diện
        /// Layout: A-M (13 hàng), 1-14 (14 cột)
        /// Chỉ ghế A1-A5, B1-B5, C1-C5 là ghế thật có thể đặt
        /// </summary>
        private void TaoSoDoGheNgoi()
        {
            panel_seating.Controls.Clear();
            cacNutGhe.Clear();
            
            // Định nghĩa các hàng ghế từ A đến M
            string[] cacHang = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            int kichThuocGhe = 26; // Kích thước nút ghế
            int khoangCach = 1;    // Khoảng cách giữa các ghế
            int viTriBatDauX = 30; // Margin bên trái
            int viTriBatDauY = 15; // Margin bên trên

            // Tạo từng hàng ghế
            for (int chiSoHang = 0; chiSoHang < cacHang.Length; chiSoHang++)
            {
                string hang = cacHang[chiSoHang];
                
                // Tạo label hiển thị tên hàng (A, B, C, ...)
                Label labelHang = new Label();
                labelHang.Text = hang;
                labelHang.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                labelHang.Size = new Size(20, kichThuocGhe);
                labelHang.Location = new Point(5, viTriBatDauY + chiSoHang * (kichThuocGhe + khoangCach));
                labelHang.TextAlign = ContentAlignment.MiddleCenter;
                panel_seating.Controls.Add(labelHang);

                // Tạo từng ghế trong hàng (1-14)
                for (int cot = 1; cot <= 14; cot++)
                {
                    Button nutGhe = new Button();
                    string maGhe = $"{hang}{cot}";
                    
                    // Thiết lập vị trí và kích thước nút ghế
                    nutGhe.Size = new Size(kichThuocGhe, kichThuocGhe);
                    nutGhe.Location = new Point(viTriBatDauX + (cot - 1) * (kichThuocGhe + khoangCach), 
                                                  viTriBatDauY + chiSoHang * (kichThuocGhe + khoangCach));
                    nutGhe.Text = cot.ToString();
                    
                    // Điều chỉnh font size dựa trên số chữ số
                    if (cot >= 10)
                    {
                        nutGhe.Font = new Font("Microsoft Sans Serif", 5, FontStyle.Bold);
                    }
                    else
                    {
                        nutGhe.Font = new Font("Microsoft Sans Serif", 6, FontStyle.Bold);
                    }
                    
                    nutGhe.Tag = maGhe;
                    nutGhe.FlatStyle = FlatStyle.Flat;
                    nutGhe.FlatAppearance.BorderSize = 1;

                    // Kiểm tra xem có phải ghế thật có thể đặt không
                    // Chỉ ghế A1-A5, B1-B5, C1-C5 mới là ghế thật có thể đặt
                    bool laGheCoTheDat = (hang == "A" || hang == "B" || hang == "C") && cot <= 5;
                    
                    if (laGheCoTheDat)
                    {
                        // Ghế có thể đặt - thiết lập màu sắc và sự kiện click
                        ThietLapHienThiGhe(nutGhe, TrangThaiGhe.TrongTrong, LayLoaiGhe(maGhe));
                        nutGhe.Click += SuKienClickNutGhe;
                        nutGhe.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        // Ghế trang trí - không thể click
                        nutGhe.BackColor = Color.LightGray;
                        nutGhe.ForeColor = Color.DarkGray;
                        nutGhe.Enabled = false;
                    }

                    // Lưu nút ghế vào dictionary để quản lý
                    cacNutGhe[maGhe] = nutGhe;
                    panel_seating.Controls.Add(nutGhe);
                }
            }
        }

        /// <summary>
        /// Xác định loại ghế dựa trên vị trí
        /// </summary>
        /// <param name="maGhe">Mã ghế (VD: A1, B2, C3)</param>
        /// <returns>Loại ghế: Vớt, Thường, VIP</returns>
        private LoaiGhe LayLoaiGhe(string maGhe)
        {
            // Vé vớt: A1, A5, C1, C5 (1/4 giá vé chuẩn)
            if (maGhe == "A1" || maGhe == "A5" || maGhe == "C1" || maGhe == "C5")
                return LoaiGhe.VeVot;
            
            // Vé VIP: B2, B3, B4 (2 lần giá vé chuẩn)
            if (maGhe == "B2" || maGhe == "B3" || maGhe == "B4")
                return LoaiGhe.VIP;
            
            // Vé thường: A2, A3, A4, C2, C3, C4 (1 lần giá vé chuẩn)
            return LoaiGhe.Thuong;
        }

        /// <summary>
        /// Thiết lập giao diện hiển thị cho ghế dựa trên trạng thái và loại ghế
        /// </summary>
        /// <param name="nutGhe">Nút ghế cần thiết lập</param>
        /// <param name="trangThai">Trạng thái ghế (Trống, Đang chọn, Đã đặt)</param>
        /// <param name="loaiGhe">Loại ghế (Vớt, Thường, VIP)</param>
        private void ThietLapHienThiGhe(Button nutGhe, TrangThaiGhe trangThai, LoaiGhe loaiGhe)
        {
            switch (trangThai)
            {
                case TrangThaiGhe.TrongTrong:
                    nutGhe.BackColor = Color.LightGray;
                    nutGhe.ForeColor = Color.Black;
                    break;
                case TrangThaiGhe.DangChon:
                    nutGhe.BackColor = Color.Orange;
                    nutGhe.ForeColor = Color.White;
                    break;
                case TrangThaiGhe.DaDat:
                    nutGhe.BackColor = Color.Red;
                    nutGhe.ForeColor = Color.White;
                    nutGhe.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Sự kiện click vào nút ghế - Xử lý việc chọn/bỏ chọn ghế
        /// </summary>
        private void SuKienClickNutGhe(object sender, EventArgs e)
        {
            Button nutDuocClick = sender as Button;
            string maGhe = nutDuocClick.Tag.ToString();
            
            // Kiểm tra xem đã chọn phim và phòng chiếu chưa
            if (comboBox_phim.SelectedIndex <= 0 || comboBox_phong_chieu.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng chiếu trước!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phongHienTai = comboBox_phong_chieu.SelectedItem.ToString();
            string maGheDayDu = $"{phongHienTai}-{maGhe}";
            
            // Kiểm tra ghế đã được đặt chưa
            if (gheOaDat[phongHienTai].Contains(maGhe))
            {
                MessageBox.Show($"Ghế {maGhe} đã được đặt!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xử lý chọn/bỏ chọn ghế
            if (gheOangChon.Contains(maGheDayDu))
            {
                // Bỏ chọn ghế
                gheOangChon.Remove(maGheDayDu);
                ThietLapHienThiGhe(nutDuocClick, TrangThaiGhe.TrongTrong, LayLoaiGhe(maGhe));
            }
            else
            {
                // Kiểm tra giới hạn tối đa 2 vé
                if (gheOangChon.Count >= 2)
                {
                    MessageBox.Show("Không thể chọn nhiều hơn 2 vé!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giới hạn phòng chiếu (tối đa 2 phòng)
                int soPhongHienTai = int.Parse(phongHienTai.Split(' ')[1]);
                if (!KiemTraGioiHanPhong(soPhongHienTai))
                    return;
                
                // Chọn ghế
                gheOangChon.Add(maGheDayDu);
                ThietLapHienThiGhe(nutDuocClick, TrangThaiGhe.DangChon, LayLoaiGhe(maGhe));
            }
        }

        /// <summary>
        /// Kiểm tra giới hạn không được chọn vé ở quá 2 phòng chiếu khác nhau
        /// </summary>
        /// <param name="soPhongMoi">Số phòng mới muốn chọn</param>
        /// <returns>True nếu hợp lệ, False nếu vi phạm giới hạn</returns>
        private bool KiemTraGioiHanPhong(int soPhongMoi)
        {
            // Lấy danh sách các phòng đã có ghế được chọn
            var cacPhongCoGheDuocChon = gheOangChon
                .Select(ghe => int.Parse(ghe.Split('-')[0].Split(' ')[1]))
                .Distinct()
                .ToList();
            
            // Lấy danh sách các phòng đã có vé đặt
            var cacPhongCoVeDat = soLuongVeTheoPhong.Where(kvp => kvp.Value > 0).Select(kvp => kvp.Key).ToList();
            
            // Tổng hợp tất cả các phòng đã sử dụng
            var tatCaCacPhongDaSuDung = cacPhongCoGheDuocChon.Concat(cacPhongCoVeDat).Distinct().ToList();
            
            // Kiểm tra giới hạn
            if (!tatCaCacPhongDaSuDung.Contains(soPhongMoi) && tatCaCacPhongDaSuDung.Count >= 2)
            {
                MessageBox.Show("Không thể chọn vé ở nhiều hơn 2 phòng chiếu khác nhau!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Sự kiện thay đổi lựa chọn phim
        /// </summary>
        private void comboBox_phim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_phim.SelectedIndex <= 0)
            {
                comboBox_phong_chieu.Enabled = false;
                comboBox_phong_chieu.Items.Clear();
                XoaGheDuocChon();
                return;
            }

            string phimDuocChon = comboBox_phim.SelectedItem.ToString();
            TaiDanhSachPhong(phimDuocChon);
            XoaGheDuocChon();
        }

        /// <summary>
        /// Tải danh sách phòng chiếu cho phim đã chọn
        /// </summary>
        /// <param name="tenPhim">Tên phim đã chọn</param>
        private void TaiDanhSachPhong(string tenPhim)
        {
            comboBox_phong_chieu.Items.Clear();
            comboBox_phong_chieu.Items.Add("-- Chọn phòng chiếu --");
            
            // Thêm các phòng chiếu của phim vào ComboBox
            if (danhSachPhim.ContainsKey(tenPhim))
            {
                foreach (int phong in danhSachPhim[tenPhim].DanhSachPhong)
                {
                    comboBox_phong_chieu.Items.Add($"Phòng {phong}");
                }
            }
            
            comboBox_phong_chieu.SelectedIndex = 0;
            comboBox_phong_chieu.Enabled = true;
        }

        /// <summary>
        /// Sự kiện thay đổi lựa chọn phòng chiếu
        /// </summary>
        private void comboBox_phong_chieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            XoaGheDuocChon();
            CapNhatHienThiSoDoGhe();
        }

        /// <summary>
        /// Cập nhật hiển thị sơ đồ ghế dựa trên phòng chiếu đã chọn
        /// </summary>
        private void CapNhatHienThiSoDoGhe()
        {
            if (comboBox_phong_chieu.SelectedIndex <= 0)
                return;

            string phongHienTai = comboBox_phong_chieu.SelectedItem.ToString();
            
            // Cập nhật trạng thái tất cả các ghế
            foreach (var kvp in cacNutGhe)
            {
                string maGhe = kvp.Key;
                Button nutGhe = kvp.Value;
                
                // Chỉ xử lý ghế có thể đặt (A1-A5, B1-B5, C1-C5)
                char hang = maGhe[0];
                int cot = int.Parse(maGhe.Substring(1));
                bool laGheCoTheDat = (hang == 'A' || hang == 'B' || hang == 'C') && cot <= 5;
                
                if (laGheCoTheDat)
                {
                    if (gheOaDat[phongHienTai].Contains(maGhe))
                    {
                        ThietLapHienThiGhe(nutGhe, TrangThaiGhe.DaDat, LayLoaiGhe(maGhe));
                    }
                    else
                    {
                        ThietLapHienThiGhe(nutGhe, TrangThaiGhe.TrongTrong, LayLoaiGhe(maGhe));
                        nutGhe.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Xóa tất cả ghế đang được chọn và reset giao diện
        /// </summary>
        private void XoaGheDuocChon()
        {
            // Xóa danh sách ghế đang chọn
            gheOangChon.Clear();
            
            // Reset giao diện hiển thị của tất cả ghế có thể đặt
            foreach (var kvp in cacNutGhe)
            {
                string maGhe = kvp.Key;
                Button nutGhe = kvp.Value;
                
                char hang = maGhe[0];
                int cot = int.Parse(maGhe.Substring(1));
                bool laGheCoTheDat = (hang == 'A' || hang == 'B' || hang == 'C') && cot <= 5;
                
                if (laGheCoTheDat && nutGhe.Enabled)
                {
                    ThietLapHienThiGhe(nutGhe, TrangThaiGhe.TrongTrong, LayLoaiGhe(maGhe));
                }
            }
        }

        /// <summary>
        /// Tính giá vé cho một ghế cụ thể dựa trên loại ghế và giá cơ bản
        /// </summary>
        /// <param name="maGhe">Mã ghế</param>
        /// <param name="giaCoBan">Giá cơ bản của phim</param>
        /// <returns>Giá vé cuối cùng</returns>
        private decimal TinhGiaGhe(string maGhe, decimal giaCoBan)
        {
            LoaiGhe loaiGhe = LayLoaiGhe(maGhe);
            
            switch (loaiGhe)
            {
                case LoaiGhe.VeVot:
                    return giaCoBan * 0.25m; // 1/4 giá vé chuẩn
                case LoaiGhe.VIP:
                    return giaCoBan * 2m; // 2 lần giá vé chuẩn
                case LoaiGhe.Thuong:
                default:
                    return giaCoBan; // 1 lần giá vé chuẩn
            }
        }

        /// <summary>
        /// Lấy tên hiển thị cho loại ghế
        /// </summary>
        /// <param name="loaiGhe">Loại ghế</param>
        /// <returns>Chuỗi mô tả loại ghế</returns>
        private string LayTenLoaiGhe(LoaiGhe loaiGhe)
        {
            switch (loaiGhe)
            {
                case LoaiGhe.VeVot: return "Vé vớt";
                case LoaiGhe.Thuong: return "Vé thường";
                case LoaiGhe.VIP: return "Vé VIP";
                default: return "Không xác định";
            }
        }

        /// <summary>
        /// Sự kiện click nút "Đặt vé" - Xử lý việc đặt vé và hiển thị kết quả
        /// </summary>
        private void button_dat_ve_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation đầu vào
                if (string.IsNullOrWhiteSpace(textBox_ho_ten.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ và tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_ho_ten.Focus();
                    return;
                }

                if (comboBox_phim.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng chọn phim!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox_phong_chieu.SelectedIndex <= 0)
                {
                    MessageBox.Show("Vui lòng chọn phòng chiếu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (gheOangChon.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một ghế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin đã chọn
                string tenKhachHang = textBox_ho_ten.Text.Trim();
                string tenPhim = comboBox_phim.SelectedItem.ToString();
                string tenPhong = comboBox_phong_chieu.SelectedItem.ToString();
                int soPhong = int.Parse(tenPhong.Split(' ')[1]);

                // Tính toán giá vé
                decimal giaCoBan = danhSachPhim[tenPhim].GiaCoBan;
                decimal tongTien = 0;
                var danhSachGheDuocChon = new List<string>();

                // Tính tổng tiền và lấy danh sách ghế
                foreach (string maGheDayDu in gheOangChon)
                {
                    string maGhe = maGheDayDu.Split('-')[1]; // Lấy tên ghế (A1, B2, etc.)
                    danhSachGheDuocChon.Add(maGhe);
                    tongTien += TinhGiaGhe(maGhe, giaCoBan);
                }

                // Đánh dấu ghế đã đặt trong hệ thống
                foreach (string ghe in danhSachGheDuocChon)
                {
                    gheOaDat[tenPhong].Add(ghe);
                }

                // Cập nhật số lượng vé đã đặt theo phòng
                soLuongVeTheoPhong[soPhong] += danhSachGheDuocChon.Count;

                // Hiển thị thông tin đặt vé
                HienThiKetQua(tenKhachHang, tenPhim, tenPhong, danhSachGheDuocChon, giaCoBan, tongTien);

                // Reset giao diện sau khi đặt vé thành công
                XoaGheDuocChon();
                CapNhatHienThiSoDoGhe();

                MessageBox.Show("Đặt vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị thông tin chi tiết về vé đã đặt
        /// </summary>
        /// <param name="tenKhachHang">Tên khách hàng</param>
        /// <param name="tenPhim">Tên phim</param>
        /// <param name="tenPhong">Tên phòng chiếu</param>
        /// <param name="danhSachGhe">Danh sách ghế đã đặt</param>
        /// <param name="giaCoBan">Giá vé cơ bản</param>
        /// <param name="tongTien">Tổng tiền cần thanh toán</param>
        private void HienThiKetQua(string tenKhachHang, string tenPhim, string tenPhong, List<string> danhSachGhe, decimal giaCoBan, decimal tongTien)
        {
            StringBuilder ketQua = new StringBuilder();
            ketQua.AppendLine("=== THÔNG TIN ĐẶT VÉ ===");
            ketQua.AppendLine($"Họ và tên: {tenKhachHang}");
            ketQua.AppendLine($"Tên phim: {tenPhim}");
            ketQua.AppendLine($"Phòng chiếu: {tenPhong}");
            ketQua.AppendLine($"Ghế đã chọn: {string.Join(", ", danhSachGhe)}");
            ketQua.AppendLine($"Giá vé chuẩn: {giaCoBan:C0}");
            
            // Hiển thị chi tiết giá từng ghế
            ketQua.AppendLine("\nChi tiết giá vé:");
            foreach (string ghe in danhSachGhe)
            {
                LoaiGhe loaiGhe = LayLoaiGhe(ghe);
                string tenLoaiGhe = LayTenLoaiGhe(loaiGhe);
                decimal giaGhe = TinhGiaGhe(ghe, giaCoBan);
                ketQua.AppendLine($"  {ghe} ({tenLoaiGhe}): {giaGhe:C0}");
            }
            
            ketQua.AppendLine($"\nTổng tiền cần thanh toán: {tongTien:C0}");
            
            // Thêm kết quả vào textbox (giữ lại thông tin cũ)
            if (textBox_ket_qua.Text.Length > 0)
            {
                textBox_ket_qua.Text += "\r\n\r\n" + ketQua.ToString();
            }
            else
            {
                textBox_ket_qua.Text = ketQua.ToString();
            }
        }

        /// <summary>
        /// Sự kiện click nút "Xóa" - Reset toàn bộ form và dữ liệu
        /// </summary>
        private void button_xoa_Click(object sender, EventArgs e)
        {
            // Xóa tất cả input
            textBox_ho_ten.Clear();
            comboBox_phim.SelectedIndex = 0;
            comboBox_phong_chieu.Items.Clear();
            comboBox_phong_chieu.Enabled = false;
            textBox_ket_qua.Clear();
            
            // Reset dữ liệu ghế đã đặt và số lượng vé
            KhoiTaoDuLieu();
            
            // Xóa ghế đang chọn và cập nhật hiển thị
            XoaGheDuocChon();
            CapNhatHienThiSoDoGhe();
            
            // Đặt focus về ô nhập tên
            textBox_ho_ten.Focus();
        }

        /// <summary>
        /// Sự kiện click nút "Thoát" - Đóng form
        /// </summary>
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    /// <summary>
    /// Class để lưu thông tin chi tiết về phim
    /// </summary>
    public class ThongTinPhim
    {
        /// <summary>
        /// Giá vé cơ bản (giá vé thường)
        /// </summary>
        public decimal GiaCoBan { get; set; }
        
        /// <summary>
        /// Danh sách các phòng chiếu phim này
        /// </summary>
        public List<int> DanhSachPhong { get; set; }
    }

    /// <summary>
    /// Enum định nghĩa các loại ghế và giá tương ứng
    /// </summary>
    public enum LoaiGhe
    {
        VeVot,  // Vé vớt - 1/4 giá cơ bản (A1, A5, C1, C5)
        Thuong, // Vé thường - 1x giá cơ bản (A2, A3, A4, C2, C3, C4)
        VIP     // Vé VIP - 2x giá cơ bản (B2, B3, B4)
    }

    /// <summary>
    /// Enum định nghĩa trạng thái của ghế
    /// </summary>
    public enum TrangThaiGhe
    {
        TrongTrong, // Ghế trống, có thể chọn
        DangChon,   // Đang được chọn (màu cam)
        DaDat       // Đã được đặt (màu đỏ, không thể chọn)
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE ===

1. KIẾN TRÚC TỔNG QUAN:
   - Form Windows Forms quản lý hệ thống đặt vé xem phim
   - Sử dụng các Dictionary để lưu trữ dữ liệu phim, ghế đã đặt, số lượng vé
   - Giao diện trực quan với sơ đồ ghế và các control input

2. DỮ LIỆU CHÍNH:
   - danhSachPhim: Thông tin 4 bộ phim với giá vé và phòng chiếu
   - gheOaDat: Ghế đã đặt theo từng phòng
   - soLuongVeTheoPhong: Đếm số vé đã đặt để kiểm tra giới hạn 2 phòng
   - cacNutGhe: Quản lý các nút ghế trên giao diện
   - gheOangChon: Danh sách ghế đang được chọn

3. LOGIC NGHIỆP VỤ:
   - Chỉ cho phép đặt tối đa 2 vé mỗi lần
   - Giới hạn đặt vé tối đa 2 phòng chiếu khác nhau
   - 3 loại ghế với giá khác nhau:
     * Vé vớt (A1,A5,C1,C5): 25% giá cơ bản
     * Vé thường (A2-A4,C2-C4): 100% giá cơ bản  
     * Vé VIP (B2-B4): 200% giá cơ bản

4. LUỒNG HOẠT ĐỘNG:
   a) Khởi tạo: Tạo dữ liệu, sơ đồ ghế 13x14 (chỉ 15 ghế thật có thể đặt)
   b) Chọn phim → Load phòng chiếu tương ứng
   c) Chọn phòng → Hiển thị trạng thái ghế (trống/đã đặt)
   d) Click ghế → Kiểm tra ràng buộc → Chọn/bỏ chọn
   e) Đặt vé → Validate → Tính tiền → Lưu thông tin → Hiển thị kết quả

5. TÍNH NĂNG CHÍNH:
   - Validation đầu vào đầy đủ
   - Giao diện trực quan với màu sắc phân biệt trạng thái ghế
   - Tính toán giá vé tự động theo loại ghế
   - Lưu trữ lịch sử đặt vé và hiển thị chi tiết
   - Reset/Clear toàn bộ dữ liệu

6. XỬ LÝ LỖI:
   - Try-catch cho các thao tác chính
   - MessageBox thông báo lỗi và hướng dẫn người dùng
   - Kiểm tra ràng buộc nghiệp vụ trước khi thực hiện thao tác
*/
