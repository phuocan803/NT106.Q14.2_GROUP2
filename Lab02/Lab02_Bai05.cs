using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace NT106_Lab02
{
    /// <summary>
    /// Form quản lý đặt vé xem phim - Lab02 Bài 05
    /// Chức năng: Đặt vé phim, quản lý ghế ngồi, xuất thống kê doanh thu
    /// </summary>
    public partial class Lab02_Bai05 : Form
    {
        // Các trường dữ liệu
        private QuanLyPhim quanly_phim;
        private QuanLyGhe quanly_ghe;
        private Dictionary<string, Button> danh_sach_nut_ghe;
        private List<string> danh_sach_ghe_dang_chon;

        public Lab02_Bai05()
        {
            InitializeComponent();
            KhoiTao();
        }

        /// <summary>
        /// Khởi tạo các đối tượng và dữ liệu ban đầu
        /// </summary>
        private void KhoiTao()
        {
            quanly_phim = new QuanLyPhim();
            quanly_ghe = new QuanLyGhe();
            danh_sach_nut_ghe = new Dictionary<string, Button>();
            danh_sach_ghe_dang_chon = new List<string>();

            // Đọc dữ liệu phim từ file
            quanly_phim.DocDuLieuTuFile("input5.txt", this);
        }

        /// <summary>
        /// Xử lý sự kiện Load form
        /// </summary>
        private void Lab01_Bai05_Load(object sender, EventArgs e)
        {
            // Thiết lập form
            this.Text = "Lab02 Bài 05 - Quản lý đặt vé phim";
            textBox_ket_qua.ReadOnly = true;
            comboBox_phong_chieu.Enabled = false;

            // Tải danh sách phim
            TaiDanhSachPhim();

            // Tạo sơ đồ ghế
            TaoSoDoGheNgoi();

            // Focus vào ô nhập tên
            textBox_ho_ten.Focus();
        }

        /// <summary>
        /// Tải danh sách phim vào ComboBox
        /// </summary>
        private void TaiDanhSachPhim()
        {
            comboBox_phim.Items.Clear();
            comboBox_phim.Items.Add("-- Chọn phim --");

            foreach (var phim in quanly_phim.LayDanhSachPhim())
            {
                comboBox_phim.Items.Add(phim.Key);
            }

            comboBox_phim.SelectedIndex = 0;
        }

        /// <summary>
        /// Tạo sơ đồ ghế ngồi 13x14
        /// Ghế thật: A1-A5, B1-B5, C1-C5 (15 ghế)
        /// </summary>
        private void TaoSoDoGheNgoi()
        {
            panel_seating.Controls.Clear();
            danh_sach_nut_ghe.Clear();

            string[] cac_hang = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            int kich_thuoc_ghe = 26;
            int khoang_cach = 1;
            int vitri_x = 30;
            int vitri_y = 15;

            // Tạo từng hàng ghế
            for (int i = 0; i < cac_hang.Length; i++)
            {
                string hang = cac_hang[i];

                // Tạo label hiển thị tên hàng
                Label label_hang = new Label
                {
                    Text = hang,
                    Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                    Size = new Size(20, kich_thuoc_ghe),
                    Location = new Point(5, vitri_y + i * (kich_thuoc_ghe + khoang_cach)),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel_seating.Controls.Add(label_hang);

                // Tạo các ghế trong hàng
                for (int cot = 1; cot <= 14; cot++)
                {
                    string ma_ghe = string.Format("{0}{1}", hang, cot);
                    Button nut_ghe = TaoNutGhe(ma_ghe, hang, cot, kich_thuoc_ghe, khoang_cach, vitri_x, vitri_y, i);
                    
                    danh_sach_nut_ghe[ma_ghe] = nut_ghe;
                    panel_seating.Controls.Add(nut_ghe);
                }
            }
        }

        /// <summary>
        /// Tạo một nút ghế
        /// </summary>
        private Button TaoNutGhe(string ma_ghe, string hang, int cot, int kich_thuoc, 
            int khoang_cach, int vitri_x, int vitri_y, int chi_so_hang)
        {
            Button nut_ghe = new Button
            {
                Size = new Size(kich_thuoc, kich_thuoc),
                Location = new Point(vitri_x + (cot - 1) * (kich_thuoc + khoang_cach),
                                     vitri_y + chi_so_hang * (kich_thuoc + khoang_cach)),
                Text = cot.ToString(),
                Font = new Font("Microsoft Sans Serif", cot >= 10 ? 5 : 6, FontStyle.Bold),
                Tag = ma_ghe,
                FlatStyle = FlatStyle.Flat
            };
            nut_ghe.FlatAppearance.BorderSize = 1;

            // Kiểm tra ghế có thể đặt không (A1-A5, B1-B5, C1-C5)
            bool la_ghe_dat_duoc = (hang == "A" || hang == "B" || hang == "C") && cot <= 5;

            if (la_ghe_dat_duoc)
            {
                LoaiGhe loai = quanly_ghe.XacDinhLoaiGhe(ma_ghe);
                ThietLapMauGhe(nut_ghe, TrangThaiGhe.Trong, loai);
                nut_ghe.Click += XuLyClickGhe;
                nut_ghe.Cursor = Cursors.Hand;
            }
            else
            {
                // Ghế trang trí
                nut_ghe.BackColor = Color.LightGray;
                nut_ghe.ForeColor = Color.DarkGray;
                nut_ghe.Enabled = false;
            }

            return nut_ghe;
        }

        /// <summary>
        /// Thiết lập màu sắc cho ghế theo trạng thái
        /// </summary>
        private void ThietLapMauGhe(Button nut_ghe, TrangThaiGhe trang_thai, LoaiGhe loai)
        {
            switch (trang_thai)
            {
                case TrangThaiGhe.Trong:
                    nut_ghe.BackColor = Color.LightGray;
                    nut_ghe.ForeColor = Color.Black;
                    nut_ghe.Enabled = true;
                    break;
                case TrangThaiGhe.DangChon:
                    nut_ghe.BackColor = Color.Orange;
                    nut_ghe.ForeColor = Color.White;
                    break;
                case TrangThaiGhe.DaDat:
                    nut_ghe.BackColor = Color.Red;
                    nut_ghe.ForeColor = Color.White;
                    nut_ghe.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click vào ghế
        /// </summary>
        private void XuLyClickGhe(object sender, EventArgs e)
        {
            Button nut_ghe = sender as Button;
            string ma_ghe = nut_ghe.Tag.ToString();

            // Kiểm tra đã chọn phim và phòng chưa
            if (comboBox_phim.SelectedIndex <= 0 || comboBox_phong_chieu.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng chiếu trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string phong_hien_tai = comboBox_phong_chieu.SelectedItem.ToString();
            string ma_ghe_day_du = string.Format("{0}-{1}", phong_hien_tai, ma_ghe);

            // Kiểm tra ghế đã đặt chưa
            if (quanly_ghe.KiemTraGheDaDat(phong_hien_tai, ma_ghe))
            {
                MessageBox.Show(string.Format("Ghế {0} đã được đặt!", ma_ghe), "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xử lý chọn/bỏ chọn ghế
            if (danh_sach_ghe_dang_chon.Contains(ma_ghe_day_du))
            {
                // Bỏ chọn
                danh_sach_ghe_dang_chon.Remove(ma_ghe_day_du);
                ThietLapMauGhe(nut_ghe, TrangThaiGhe.Trong, quanly_ghe.XacDinhLoaiGhe(ma_ghe));
            }
            else
            {
                // Kiểm tra giới hạn 2 vé
                if (danh_sach_ghe_dang_chon.Count >= 2)
                {
                    MessageBox.Show("Không thể chọn nhiều hơn 2 vé!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giới hạn 2 phòng
                int so_phong = int.Parse(phong_hien_tai.Split(' ')[1]);
                if (!KiemTraGioiHanPhong(so_phong))
                    return;

                // Chọn ghế
                danh_sach_ghe_dang_chon.Add(ma_ghe_day_du);
                ThietLapMauGhe(nut_ghe, TrangThaiGhe.DangChon, quanly_ghe.XacDinhLoaiGhe(ma_ghe));
            }
        }

        /// <summary>
        /// Kiểm tra giới hạn không quá 2 phòng chiếu
        /// </summary>
        private bool KiemTraGioiHanPhong(int so_phong_moi)
        {
            var cac_phong_dang_chon = danh_sach_ghe_dang_chon
                .Select(ghe => int.Parse(ghe.Split('-')[0].Split(' ')[1]))
                .Distinct()
                .ToList();

            var cac_phong_da_dat = quanly_ghe.LayDanhSachPhongDaDat();
            var tat_ca_phong = cac_phong_dang_chon.Concat(cac_phong_da_dat).Distinct().ToList();

            if (!tat_ca_phong.Contains(so_phong_moi) && tat_ca_phong.Count >= 2)
            {
                MessageBox.Show("Không thể chọn vé ở nhiều hơn 2 phòng chiếu khác nhau!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Xử lý thay đổi lựa chọn phim
        /// </summary>
        private void comboBox_phim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_phim.SelectedIndex <= 0)
            {
                comboBox_phong_chieu.Enabled = false;
                comboBox_phong_chieu.Items.Clear();
                XoaGheDangChon();
                return;
            }

            string ten_phim = comboBox_phim.SelectedItem.ToString();
            TaiDanhSachPhong(ten_phim);
            XoaGheDangChon();
        }

        /// <summary>
        /// Tải danh sách phòng chiếu cho phim đã chọn
        /// </summary>
        private void TaiDanhSachPhong(string ten_phim)
        {
            comboBox_phong_chieu.Items.Clear();
            comboBox_phong_chieu.Items.Add("-- Chọn phòng chiếu --");

            var thong_tin = quanly_phim.LayThongTinPhim(ten_phim);
            if (thong_tin != null)
            {
                foreach (int phong in thong_tin.danh_sach_phong)
                {
                    comboBox_phong_chieu.Items.Add(string.Format("Phòng {0}", phong));
                }
            }

            comboBox_phong_chieu.SelectedIndex = 0;
            comboBox_phong_chieu.Enabled = true;
        }

        /// <summary>
        /// Xử lý thay đổi lựa chọn phòng chiếu
        /// </summary>
        private void comboBox_phong_chieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            XoaGheDangChon();
            CapNhatHienThiGhe();
        }

        /// <summary>
        /// Cập nhật hiển thị trạng thái ghế
        /// </summary>
        private void CapNhatHienThiGhe()
        {
            if (comboBox_phong_chieu.SelectedIndex <= 0)
                return;

            string phong_hien_tai = comboBox_phong_chieu.SelectedItem.ToString();

            foreach (var kvp in danh_sach_nut_ghe)
            {
                string ma_ghe = kvp.Key;
                Button nut_ghe = kvp.Value;

                char hang = ma_ghe[0];
                int cot = int.Parse(ma_ghe.Substring(1));
                bool la_ghe_dat_duoc = (hang == 'A' || hang == 'B' || hang == 'C') && cot <= 5;

                if (la_ghe_dat_duoc)
                {
                    if (quanly_ghe.KiemTraGheDaDat(phong_hien_tai, ma_ghe))
                    {
                        ThietLapMauGhe(nut_ghe, TrangThaiGhe.DaDat, quanly_ghe.XacDinhLoaiGhe(ma_ghe));
                    }
                    else
                    {
                        ThietLapMauGhe(nut_ghe, TrangThaiGhe.Trong, quanly_ghe.XacDinhLoaiGhe(ma_ghe));
                    }
                }
            }
        }

        /// <summary>
        /// Xóa tất cả ghế đang chọn
        /// </summary>
        private void XoaGheDangChon()
        {
            danh_sach_ghe_dang_chon.Clear();

            foreach (var kvp in danh_sach_nut_ghe)
            {
                string ma_ghe = kvp.Key;
                Button nut_ghe = kvp.Value;

                char hang = ma_ghe[0];
                int cot = int.Parse(ma_ghe.Substring(1));
                bool la_ghe_dat_duoc = (hang == 'A' || hang == 'B' || hang == 'C') && cot <= 5;

                if (la_ghe_dat_duoc && nut_ghe.Enabled)
                {
                    ThietLapMauGhe(nut_ghe, TrangThaiGhe.Trong, quanly_ghe.XacDinhLoaiGhe(ma_ghe));
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button Đặt vé
        /// </summary>
        private void button_dat_ve_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra validation
                if (!KiemTraDuLieuNhap())
                    return;

                // Lấy thông tin
                string ten_khach_hang = textBox_ho_ten.Text.Trim();
                string ten_phim = comboBox_phim.SelectedItem.ToString();
                string ten_phong = comboBox_phong_chieu.SelectedItem.ToString();
                int so_phong = int.Parse(ten_phong.Split(' ')[1]);

                // Tính tổng tiền
                decimal gia_co_ban = quanly_phim.LayGiaVe(ten_phim);
                decimal tong_tien = 0;
                var danh_sach_ghe = new List<string>();

                foreach (string ma_ghe_day_du in danh_sach_ghe_dang_chon)
                {
                    string ma_ghe = ma_ghe_day_du.Split('-')[1];
                    danh_sach_ghe.Add(ma_ghe);
                    tong_tien += quanly_ghe.TinhGiaGhe(ma_ghe, gia_co_ban);
                }

                // Đánh dấu ghế đã đặt
                foreach (string ghe in danh_sach_ghe)
                {
                    quanly_ghe.DatGhe(ten_phong, ghe, so_phong);
                }

                // Cập nhật thống kê
                quanly_phim.CapNhatThongKe(ten_phim, danh_sach_ghe.Count, tong_tien);

                // Hiển thị kết quả
                HienThiKetQua(ten_khach_hang, ten_phim, ten_phong, danh_sach_ghe, gia_co_ban, tong_tien);

                // Reset giao diện
                XoaGheDangChon();
                CapNhatHienThiGhe();

                MessageBox.Show("Đặt vé thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Đã xảy ra lỗi: {0}", ex.Message), "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập có hợp lệ không
        /// </summary>
        private bool KiemTraDuLieuNhap()
        {
            if (string.IsNullOrWhiteSpace(textBox_ho_ten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_ho_ten.Focus();
                return false;
            }

            if (comboBox_phim.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn phim!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBox_phong_chieu.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng chiếu!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (danh_sach_ghe_dang_chon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Hiển thị thông tin vé đã đặt
        /// </summary>
        private void HienThiKetQua(string ten_khach_hang, string ten_phim, string ten_phong, 
            List<string> danh_sach_ghe, decimal gia_co_ban, decimal tong_tien)
        {
            StringBuilder ket_qua = new StringBuilder();
            ket_qua.AppendLine("=== THÔNG TIN ĐẶT VÉ ===");
            ket_qua.AppendLine(string.Format("Họ và tên: {0}", ten_khach_hang));
            ket_qua.AppendLine(string.Format("Tên phim: {0}", ten_phim));
            ket_qua.AppendLine(string.Format("Phòng chiếu: {0}", ten_phong));
            ket_qua.AppendLine(string.Format("Ghế đã chọn: {0}", string.Join(", ", danh_sach_ghe)));
            ket_qua.AppendLine(string.Format("Giá vé chuẩn: {0:C0}", gia_co_ban));
            ket_qua.AppendLine("\nChi tiết giá vé:");

            foreach (string ghe in danh_sach_ghe)
            {
                LoaiGhe loai = quanly_ghe.XacDinhLoaiGhe(ghe);
                string ten_loai = quanly_ghe.LayTenLoaiGhe(loai);
                decimal gia_ghe = quanly_ghe.TinhGiaGhe(ghe, gia_co_ban);
                ket_qua.AppendLine(string.Format("  {0} ({1}): {2:C0}", ghe, ten_loai, gia_ghe));
            }

            ket_qua.AppendLine(string.Format("\nTổng tiền cần thanh toán: {0:C0}", tong_tien));

            if (textBox_ket_qua.Text.Length > 0)
            {
                textBox_ket_qua.Text += "\r\n\r\n" + ket_qua.ToString();
            }
            else
            {
                textBox_ket_qua.Text = ket_qua.ToString();
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button Xuất thống kê
        /// </summary>
        private void button_xuat_thong_ke_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo form hiển thị tiến trình
                Form form_tiendo = TaoFormTienDo();
                Label label_trangthai = form_tiendo.Controls[0] as Label;
                ProgressBar progressbar = form_tiendo.Controls[1] as ProgressBar;

                form_tiendo.Show();
                Application.DoEvents();

                // Xử lý xuất file
                var thong_ke = quanly_phim.LayThongKeDoanhThu();
                string noi_dung = TaoNoiDungThongKe(thong_ke, progressbar, label_trangthai);

                // Lưu file
                string duong_dan = LuuFileThongKe(noi_dung, progressbar, label_trangthai);

                // Đóng form tiến độ
                form_tiendo.Close();

                // Thông báo thành công và mở Explorer
                MessageBox.Show(
                    string.Format("Đã xuất thống kê thành công!\n\nĐường dẫn file:\n{0}", duong_dan),
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                System.Diagnostics.Process.Start("explorer.exe", string.Format("/select,\"{0}\"", duong_dan));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi khi xuất file: {0}", ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tạo form hiển thị tiến độ
        /// </summary>
        private Form TaoFormTienDo()
        {
            Form form = new Form
            {
                Text = "Đang xuất file...",
                Size = new Size(400, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label label = new Label
            {
                Text = "Đang xử lý dữ liệu...",
                Location = new Point(20, 20),
                AutoSize = true
            };
            form.Controls.Add(label);

            ProgressBar progressbar = new ProgressBar
            {
                Location = new Point(20, 50),
                Size = new Size(340, 30),
                Minimum = 0,
                Maximum = 100
            };
            form.Controls.Add(progressbar);

            return form;
        }

        /// <summary>
        /// Tạo nội dung file thống kê
        /// </summary>
        private string TaoNoiDungThongKe(List<ThongKePhim> thong_ke, ProgressBar progressbar, Label label)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("=".PadRight(100, '='));
            output.AppendLine("THỐNG KÊ DOANH THU RẠP CHIẾU PHIM".PadLeft(65));
            output.AppendLine("=".PadRight(100, '='));
            output.AppendLine();

            progressbar.Value = 20;
            label.Text = "Đang tạo báo cáo...";
            Application.DoEvents();
            Thread.Sleep(300);

            output.AppendLine(string.Format("{0,-5} {1,-30} {2,-15} {3,-15} {4,-15} {5,-20}",
                "Hạng", "Tên phim", "Vé bán ra", "Vé tồn", "Tỷ lệ bán (%)", "Doanh thu (VNĐ)"));
            output.AppendLine("-".PadRight(100, '-'));

            progressbar.Value = 40;
            Application.DoEvents();
            Thread.Sleep(300);

            int count = 0;
            foreach (var phim in thong_ke)
            {
                int tong_ve = phim.so_ve_ban_ra + phim.so_ve_ton;
                double ty_le = tong_ve > 0 ? (double)phim.so_ve_ban_ra / tong_ve * 100 : 0;

                output.AppendLine(string.Format("{0,-5} {1,-30} {2,-15} {3,-15} {4,-15:F2} {5,-20:N0}",
                    phim.xep_hang, phim.ten_phim, phim.so_ve_ban_ra, phim.so_ve_ton, ty_le, phim.doanh_thu));

                count++;
                progressbar.Value = 40 + (count * 40 / thong_ke.Count);
                Application.DoEvents();
                Thread.Sleep(200);
            }

            output.AppendLine("-".PadRight(100, '-'));
            output.AppendLine();
            output.AppendLine(string.Format("Tổng doanh thu: {0:N0} VNĐ", thong_ke.Sum(p => p.doanh_thu)));
            output.AppendLine(string.Format("Tổng số vé đã bán: {0}", thong_ke.Sum(p => p.so_ve_ban_ra)));
            output.AppendLine();
            output.AppendLine("=".PadRight(100, '='));
            output.AppendLine(string.Format("Xuất file lúc: {0:dd/MM/yyyy HH:mm:ss}", DateTime.Now));
            output.AppendLine("=".PadRight(100, '='));

            return output.ToString();
        }

        /// <summary>
        /// Lưu file thống kê
        /// </summary>
        private string LuuFileThongKe(string noi_dung, ProgressBar progressbar, Label label)
        {
            progressbar.Value = 90;
            label.Text = "Đang ghi file...";
            Application.DoEvents();
            Thread.Sleep(300);

            string thu_muc_project = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", ".."));
            string duong_dan;

            if (Directory.Exists(thu_muc_project))
            {
                duong_dan = Path.Combine(thu_muc_project, "output5.txt");
            }
            else
            {
                duong_dan = Path.Combine(Application.StartupPath, "output5.txt");
            }

            File.WriteAllText(duong_dan, noi_dung, Encoding.UTF8);

            progressbar.Value = 100;
            label.Text = "Hoàn thành!";
            Application.DoEvents();
            Thread.Sleep(500);

            return duong_dan;
        }

        /// <summary>
        /// Xử lý sự kiện click button Xóa
        /// </summary>
        private void button_xoa_Click(object sender, EventArgs e)
        {
            textBox_ho_ten.Clear();
            comboBox_phim.SelectedIndex = 0;
            comboBox_phong_chieu.Items.Clear();
            comboBox_phong_chieu.Enabled = false;
            textBox_ket_qua.Clear();

            KhoiTao();
            XoaGheDangChon();
            CapNhatHienThiGhe();
            textBox_ho_ten.Focus();
        }

        /// <summary>
        /// Xử lý sự kiện click button Thoát
        /// </summary>
        private void button_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    #region Các class hỗ trợ

    /// <summary>
    /// Class quản lý thông tin phim
    /// </summary>
    public class QuanLyPhim
    {
        private Dictionary<string, ThongTinPhim> danh_sach_phim;
        private Dictionary<string, ThongKePhim> thong_ke_doanh_thu;

        public QuanLyPhim()
        {
            danh_sach_phim = new Dictionary<string, ThongTinPhim>();
            thong_ke_doanh_thu = new Dictionary<string, ThongKePhim>();
        }

        /// <summary>
        /// Đọc dữ liệu phim từ file
        /// </summary>
        public void DocDuLieuTuFile(string ten_file, Form parent_form)
        {
            try
            {
                string duong_dan = TimDuongDanFile(ten_file);

                if (duong_dan == null)
                {
                    if (!HienThiDialogChonFile(ten_file, out duong_dan))
                    {
                        TaoDuLieuMacDinh();
                        return;
                    }
                }

                DocVaPhanTichFile(duong_dan);

                if (danh_sach_phim.Count == 0)
                {
                    MessageBox.Show("File input không có dữ liệu hợp lệ!\nSẽ sử dụng dữ liệu mặc định.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TaoDuLieuMacDinh();
                }
                else
                {
                    KhoiTaoThongKe();
                    MessageBox.Show(
                        string.Format("Đã đọc thành công {0} phim từ file:\n{1}", danh_sach_phim.Count, duong_dan),
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi đọc file: {0}\nSẽ sử dụng dữ liệu mặc định.", ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TaoDuLieuMacDinh();
                KhoiTaoThongKe();
            }
        }

        /// <summary>
        /// Tìm đường dẫn file trong các thư mục
        /// </summary>
        private string TimDuongDanFile(string ten_file)
        {
            List<string> cac_duong_dan = new List<string>
            {
                Path.Combine(Application.StartupPath, ten_file),
                Path.Combine(Application.StartupPath, "..", "..", ten_file),
                Path.Combine(Application.StartupPath, "..", "..", "..", ten_file),
                Path.Combine(Directory.GetCurrentDirectory(), ten_file),
                ten_file
            };

            foreach (string duong_dan in cac_duong_dan)
            {
                string duong_dan_day_du = Path.GetFullPath(duong_dan);
                if (File.Exists(duong_dan_day_du))
                {
                    return duong_dan_day_du;
                }
            }

            return null;
        }

        /// <summary>
        /// Hiển thị dialog chọn file
        /// </summary>
        private bool HienThiDialogChonFile(string ten_file, out string duong_dan)
        {
            duong_dan = null;

            DialogResult result = MessageBox.Show(
                string.Format("Không tìm thấy file {0}!\n\nBạn có muốn chọn file thủ công không?\n(Nhấn No để sử dụng dữ liệu mặc định)", ten_file),
                "Không tìm thấy file",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    ofd.Title = "Chọn file input5.txt";
                    ofd.FileName = ten_file;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        duong_dan = ofd.FileName;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Đọc và phân tích file
        /// </summary>
        private void DocVaPhanTichFile(string duong_dan)
        {
            string[] lines = File.ReadAllLines(duong_dan, Encoding.UTF8);

            for (int i = 0; i < lines.Length; i += 3)
            {
                if (i + 2 >= lines.Length) break;

                string ten_phim = lines[i].Trim();
                if (string.IsNullOrEmpty(ten_phim)) continue;

                decimal gia_ve;
                if (!decimal.TryParse(lines[i + 1].Trim(), out gia_ve))
                    continue;

                string[] phongs = lines[i + 2].Trim().Split(',');
                List<int> danh_sach_phong = new List<int>();

                foreach (string phong in phongs)
                {
                    int so_phong;
                    if (int.TryParse(phong.Trim(), out so_phong))
                    {
                        danh_sach_phong.Add(so_phong);
                    }
                }

                if (danh_sach_phong.Count == 0)
                    continue;

                danh_sach_phim[ten_phim] = new ThongTinPhim
                {
                    gia_co_ban = gia_ve,
                    danh_sach_phong = danh_sach_phong
                };
            }
        }

        /// <summary>
        /// Tạo dữ liệu mặc định
        /// </summary>
        private void TaoDuLieuMacDinh()
        {
            danh_sach_phim = new Dictionary<string, ThongTinPhim>
            {
                { "Dao, pho va piano", new ThongTinPhim { gia_co_ban = 45000, danh_sach_phong = new List<int> { 1, 2, 3 } } },
                { "Mai", new ThongTinPhim { gia_co_ban = 100000, danh_sach_phong = new List<int> { 2, 3 } } },
                { "Gap lai chi bau", new ThongTinPhim { gia_co_ban = 70000, danh_sach_phong = new List<int> { 1 } } },
                { "Tarot", new ThongTinPhim { gia_co_ban = 90000, danh_sach_phong = new List<int> { 3 } } }
            };
        }

        /// <summary>
        /// Khởi tạo thống kê cho các phim
        /// </summary>
        private void KhoiTaoThongKe()
        {
            thong_ke_doanh_thu.Clear();
            foreach (var phim in danh_sach_phim)
            {
                thong_ke_doanh_thu[phim.Key] = new ThongKePhim
                {
                    ten_phim = phim.Key,
                    gia_ve_chuan = phim.Value.gia_co_ban,
                    so_ve_ban_ra = 0,
                    so_ve_ton = 15 * phim.Value.danh_sach_phong.Count,
                    doanh_thu = 0,
                    xep_hang = 0
                };
            }
        }

        /// <summary>
        /// Lấy danh sách phim
        /// </summary>
        public Dictionary<string, ThongTinPhim> LayDanhSachPhim()
        {
            return danh_sach_phim;
        }

        /// <summary>
        /// Lấy thông tin phim
        /// </summary>
        public ThongTinPhim LayThongTinPhim(string ten_phim)
        {
            return danh_sach_phim.ContainsKey(ten_phim) ? danh_sach_phim[ten_phim] : null;
        }

        /// <summary>
        /// Lấy giá vé phim
        /// </summary>
        public decimal LayGiaVe(string ten_phim)
        {
            return danh_sach_phim[ten_phim].gia_co_ban;
        }

        /// <summary>
        /// Cập nhật thống kê doanh thu
        /// </summary>
        public void CapNhatThongKe(string ten_phim, int so_ve, decimal doanh_thu)
        {
            thong_ke_doanh_thu[ten_phim].so_ve_ban_ra += so_ve;
            thong_ke_doanh_thu[ten_phim].so_ve_ton -= so_ve;
            thong_ke_doanh_thu[ten_phim].doanh_thu += doanh_thu;
        }

        /// <summary>
        /// Lấy thống kê doanh thu đã sắp xếp
        /// </summary>
        public List<ThongKePhim> LayThongKeDoanhThu()
        {
            var danh_sach = thong_ke_doanh_thu.Values.OrderByDescending(p => p.doanh_thu).ToList();
            int xep_hang = 1;
            foreach (var phim in danh_sach)
            {
                phim.xep_hang = xep_hang++;
            }
            return danh_sach;
        }
    }

    /// <summary>
    /// Class quản lý ghế ngồi
    /// </summary>
    public class QuanLyGhe
    {
        private Dictionary<string, HashSet<string>> ghe_da_dat;
        private Dictionary<int, int> so_luong_ve_theo_phong;

        public QuanLyGhe()
        {
            ghe_da_dat = new Dictionary<string, HashSet<string>>();
            so_luong_ve_theo_phong = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } };

            for (int phong = 1; phong <= 3; phong++)
            {
                ghe_da_dat[string.Format("Phòng {0}", phong)] = new HashSet<string>();
            }
        }

        /// <summary>
        /// Xác định loại ghế
        /// </summary>
        public LoaiGhe XacDinhLoaiGhe(string ma_ghe)
        {
            if (ma_ghe == "A1" || ma_ghe == "A5" || ma_ghe == "C1" || ma_ghe == "C5")
                return LoaiGhe.VeVot;

            if (ma_ghe == "B2" || ma_ghe == "B3" || ma_ghe == "B4")
                return LoaiGhe.VIP;

            return LoaiGhe.Thuong;
        }

        /// <summary>
        /// Tính giá vé theo loại ghế
        /// </summary>
        public decimal TinhGiaGhe(string ma_ghe, decimal gia_co_ban)
        {
            LoaiGhe loai = XacDinhLoaiGhe(ma_ghe);

            switch (loai)
            {
                case LoaiGhe.VeVot:
                    return gia_co_ban * 0.25m;
                case LoaiGhe.VIP:
                    return gia_co_ban * 2m;
                case LoaiGhe.Thuong:
                default:
                    return gia_co_ban;
            }
        }

        /// <summary>
        /// Lấy tên loại ghế
        /// </summary>
        public string LayTenLoaiGhe(LoaiGhe loai)
        {
            switch (loai)
            {
                case LoaiGhe.VeVot: return "Vé vớt";
                case LoaiGhe.Thuong: return "Vé thường";
                case LoaiGhe.VIP: return "Vé VIP";
                default: return "Không xác định";
            }
        }

        /// <summary>
        /// Kiểm tra ghế đã đặt chưa
        /// </summary>
        public bool KiemTraGheDaDat(string ten_phong, string ma_ghe)
        {
            return ghe_da_dat[ten_phong].Contains(ma_ghe);
        }

        /// <summary>
        /// Đặt ghế
        /// </summary>
        public void DatGhe(string ten_phong, string ma_ghe, int so_phong)
        {
            ghe_da_dat[ten_phong].Add(ma_ghe);
            so_luong_ve_theo_phong[so_phong]++;
        }

        /// <summary>
        /// Lấy danh sách phòng đã đặt vé
        /// </summary>
        public List<int> LayDanhSachPhongDaDat()
        {
            return so_luong_ve_theo_phong.Where(kvp => kvp.Value > 0).Select(kvp => kvp.Key).ToList();
        }
    }

    /// <summary>
    /// Class lưu thông tin phim
    /// </summary>
    public class ThongTinPhim
    {
        public decimal gia_co_ban { get; set; }
        public List<int> danh_sach_phong { get; set; }
    }

    /// <summary>
    /// Class lưu thống kê phim
    /// </summary>
    public class ThongKePhim
    {
        public string ten_phim { get; set; }
        public decimal gia_ve_chuan { get; set; }
        public int so_ve_ban_ra { get; set; }
        public int so_ve_ton { get; set; }
        public decimal doanh_thu { get; set; }
        public int xep_hang { get; set; }
    }

    /// <summary>
    /// Enum loại ghế
    /// </summary>
    public enum LoaiGhe
    {
        VeVot,
        Thuong,
        VIP
    }

    /// <summary>
    /// Enum trạng thái ghế
    /// </summary>
    public enum TrangThaiGhe
    {
        Trong,
        DangChon,
        DaDat
    }

    #endregion

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
     * Vé thường (A2-A4,C2,C3,C4): 100% giá cơ bản  
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
