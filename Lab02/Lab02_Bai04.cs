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
using System.Globalization;

namespace NT106_Lab02
{
    public partial class Lab02_Bai04 : Form
    {
        private List<SinhVien> danh_sach_sinh_vien;
        private int chi_so_hien_tai;
        private string duong_dan_input;
        private string duong_dan_output;
        private const string TEN_FILE_INPUT = "input4.txt";
        private const string TEN_FILE_OUTPUT = "output4.txt";

        public Lab02_Bai04()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            danh_sach_sinh_vien = new List<SinhVien>();
            chi_so_hien_tai = 0;

            duong_dan_input = TimDuongDanFile(TEN_FILE_INPUT);
            duong_dan_output = TimDuongDanFile(TEN_FILE_OUTPUT);

            if (duong_dan_input == null)
            {
                string thu_muc_project = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", ".."));
                duong_dan_input = Path.Combine(thu_muc_project, TEN_FILE_INPUT);
            }

            if (duong_dan_output == null)
            {
                string thu_muc_project = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", ".."));
                duong_dan_output = Path.Combine(thu_muc_project, TEN_FILE_OUTPUT);
            }
        }

        private string TimDuongDanFile(string ten_file)
        {
            List<string> cac_duong_dan = new List<string>
            {
                Path.Combine(Application.StartupPath, ten_file),
                Path.Combine(Application.StartupPath, "..", "..", ten_file),
                Path.Combine(Directory.GetCurrentDirectory(), ten_file)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraDuLieuNhapHopLe())
                    return;

                SinhVien sinh_vien_moi = TaoSinhVienTuForm();
                danh_sach_sinh_vien.Add(sinh_vien_moi);
                GhiSinhVienVaoFileText(sinh_vien_moi);
                CapNhatHienThiDanhSach();
                XoaFormNhapLieu();
                
                MessageBox.Show(
                    string.Format("?ã thêm sinh viên: {0}", sinh_vien_moi.ten),
                    "Thành công", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("L?i khi thêm sinh viên:\n{0}", ex.Message),
                    "L?i",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDuLieuNhapHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                HienThiThongBaoLoi("Vui lòng nh?p h? tên!", txtName);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                HienThiThongBaoLoi("Vui lòng nh?p mã sinh viên!", txtID);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                HienThiThongBaoLoi("Vui lòng nh?p s? ?i?n tho?i!", txtPhone);
                return false;
            }

            if (!KiemTraDiemHopLe(txtCourse1.Text, "?i?m môn 1", txtCourse1))
                return false;

            if (!KiemTraDiemHopLe(txtCourse2.Text, "?i?m môn 2", txtCourse2))
                return false;

            if (!KiemTraDiemHopLe(txtCourse3.Text, "?i?m môn 3", txtCourse3))
                return false;

            return true;
        }

        private bool KiemTraDiemHopLe(string diem_text, string ten_mon, TextBox textbox)
        {
            float diem;
            if (!float.TryParse(diem_text, out diem) || diem < 0 || diem > 10)
            {
                HienThiThongBaoLoi(
                    string.Format("{0} không h?p l?! Vui lòng nh?p ?i?m t? 0 ??n 10.", ten_mon),
                    textbox);
                return false;
            }
            return true;
        }

        private void HienThiThongBaoLoi(string thong_bao, TextBox textbox)
        {
            MessageBox.Show(thong_bao, "L?i nh?p li?u", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textbox.Focus();
        }

        private SinhVien TaoSinhVienTuForm()
        {
            return new SinhVien
            {
                ten = txtName.Text.Trim(),
                ma_sinh_vien = txtID.Text.Trim(),
                so_dien_thoai = txtPhone.Text.Trim(),
                diem_mon1 = float.Parse(txtCourse1.Text.Trim()),
                diem_mon2 = float.Parse(txtCourse2.Text.Trim()),
                diem_mon3 = float.Parse(txtCourse3.Text.Trim())
            };
        }

        private void GhiSinhVienVaoFileText(SinhVien sinh_vien)
        {
            string dong = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                sinh_vien.ten,
                sinh_vien.ma_sinh_vien,
                sinh_vien.so_dien_thoai,
                sinh_vien.diem_mon1.ToString(CultureInfo.InvariantCulture),
                sinh_vien.diem_mon2.ToString(CultureInfo.InvariantCulture),
                sinh_vien.diem_mon3.ToString(CultureInfo.InvariantCulture));

            File.AppendAllText(duong_dan_input, dong + Environment.NewLine, Encoding.UTF8);
        }

        private void CapNhatHienThiDanhSach()
        {
            StringBuilder danh_sach_text = new StringBuilder();
            danh_sach_text.AppendLine("========================================");
            danh_sach_text.AppendLine("   DANH SACH SINH VIEN DA THEM");
            danh_sach_text.AppendLine("========================================");
            danh_sach_text.AppendLine();

            for (int i = 0; i < danh_sach_sinh_vien.Count; i++)
            {
                SinhVien sv = danh_sach_sinh_vien[i];
                danh_sach_text.AppendLine(string.Format("{0}. {1}", i + 1, sv.ten));
                danh_sach_text.AppendLine(string.Format("   MSSV: {0}", sv.ma_sinh_vien));
                danh_sach_text.AppendLine(string.Format("   SDT: {0}", sv.so_dien_thoai));
                danh_sach_text.AppendLine();
            }

            danh_sach_text.AppendLine(string.Format("Tong: {0} sinh vien", danh_sach_sinh_vien.Count));

            rtbDanhSach.Text = danh_sach_text.ToString();
        }

        private void XoaFormNhapLieu()
        {
            txtName.Clear();
            txtID.Clear();
            txtPhone.Clear();
            txtCourse1.Clear();
            txtCourse2.Clear();
            txtCourse3.Clear();
            txtName.Focus();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(duong_dan_input))
                {
                    MessageBox.Show(
                        string.Format("File {0} không t?n t?i!\nVui lòng thêm sinh viên tr??c.", TEN_FILE_INPUT),
                        "L?i",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                danh_sach_sinh_vien = DocVaParseSinhVienTuFileText();
                
                if (danh_sach_sinh_vien.Count == 0)
                {
                    MessageBox.Show("File input không có d? li?u h?p l?!", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TinhDiemTrungBinhChoTatCaSinhVien();
                string json = ChuyenDoiDanhSachThanhJson(danh_sach_sinh_vien);
                File.WriteAllText(duong_dan_output, json, Encoding.UTF8);

                MessageBox.Show(
                    string.Format("?ã ghi {0} sinh viên vào file JSON!\n\n???ng d?n:\n{1}",
                        danh_sach_sinh_vien.Count, duong_dan_output),
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                System.Diagnostics.Process.Start("explorer.exe", 
                    string.Format("/select,\"{0}\"", duong_dan_output));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("L?i khi ghi file:\n{0}", ex.Message),
                    "L?i",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private List<SinhVien> DocVaParseSinhVienTuFileText()
        {
            string[] cac_dong = File.ReadAllLines(duong_dan_input, Encoding.UTF8);
            List<SinhVien> danh_sach = new List<SinhVien>();

            foreach (string dong in cac_dong)
            {
                if (string.IsNullOrWhiteSpace(dong))
                    continue;

                string[] cac_truong = dong.Split('|');
                
                if (cac_truong.Length >= 6)
                {
                    try
                    {
                        SinhVien sv = new SinhVien
                        {
                            ten = cac_truong[0].Trim(),
                            ma_sinh_vien = cac_truong[1].Trim(),
                            so_dien_thoai = cac_truong[2].Trim(),
                            diem_mon1 = float.Parse(cac_truong[3].Trim(), CultureInfo.InvariantCulture),
                            diem_mon2 = float.Parse(cac_truong[4].Trim(), CultureInfo.InvariantCulture),
                            diem_mon3 = float.Parse(cac_truong[5].Trim(), CultureInfo.InvariantCulture)
                        };

                        danh_sach.Add(sv);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            string.Format("L?i parse dòng: {0}\nChi ti?t: {1}", dong, ex.Message),
                            "C?nh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }

            return danh_sach;
        }

        private void TinhDiemTrungBinhChoTatCaSinhVien()
        {
            foreach (SinhVien sv in danh_sach_sinh_vien)
            {
                sv.diem_trung_binh = (sv.diem_mon1 + sv.diem_mon2 + sv.diem_mon3) / 3;
            }
        }

        private string ChuyenDoiDanhSachThanhJson(List<SinhVien> danh_sach)
        {
            StringBuilder json = new StringBuilder();
            json.AppendLine("[");

            for (int i = 0; i < danh_sach.Count; i++)
            {
                SinhVien sv = danh_sach[i];
                json.AppendLine("  {");
                json.AppendLine(string.Format("    \"ten\": \"{0}\",", sv.ten));
                json.AppendLine(string.Format("    \"ma_sinh_vien\": \"{0}\",", sv.ma_sinh_vien));
                json.AppendLine(string.Format("    \"so_dien_thoai\": \"{0}\",", sv.so_dien_thoai));
                json.AppendLine(string.Format("    \"diem_mon1\": {0},", 
                    sv.diem_mon1.ToString(CultureInfo.InvariantCulture)));
                json.AppendLine(string.Format("    \"diem_mon2\": {0},", 
                    sv.diem_mon2.ToString(CultureInfo.InvariantCulture)));
                json.AppendLine(string.Format("    \"diem_mon3\": {0},", 
                    sv.diem_mon3.ToString(CultureInfo.InvariantCulture)));
                json.AppendLine(string.Format("    \"diem_trung_binh\": {0}", 
                    sv.diem_trung_binh.ToString(CultureInfo.InvariantCulture)));
                
                if (i < danh_sach.Count - 1)
                    json.AppendLine("  },");
                else
                    json.AppendLine("  }");
            }

            json.AppendLine("]");
            return json.ToString();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(duong_dan_output))
                {
                    MessageBox.Show(
                        string.Format("File {0} không t?n t?i!\n\nVui lòng nh?n nút 'Write to a file' tr??c.", TEN_FILE_OUTPUT),
                        "L?i",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                string json = File.ReadAllText(duong_dan_output, Encoding.UTF8);
                danh_sach_sinh_vien = ParseJsonThanhDanhSach(json);

                if (danh_sach_sinh_vien == null || danh_sach_sinh_vien.Count == 0)
                {
                    MessageBox.Show(
                        "File JSON không có d? li?u!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                chi_so_hien_tai = 0;
                HienThiThongTinSinhVien(chi_so_hien_tai);

                MessageBox.Show(
                    string.Format("?ã ??c thành công {0} sinh viên t? file JSON!", 
                        danh_sach_sinh_vien.Count),
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("L?i khi ??c file:\n{0}", ex.Message),
                    "L?i",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private List<SinhVien> ParseJsonThanhDanhSach(string json)
        {
            List<SinhVien> danh_sach = new List<SinhVien>();
            string[] lines = json.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            SinhVien sv = null;
            foreach (string line in lines)
            {
                string trimmed = line.Trim();

                if (trimmed == "{")
                {
                    sv = new SinhVien();
                }
                else if (trimmed == "}" || trimmed == "},")
                {
                    if (sv != null)
                    {
                        danh_sach.Add(sv);
                        sv = null;
                    }
                }
                else if (sv != null && trimmed.Contains(":"))
                {
                    ParseJsonProperty(trimmed, sv);
                }
            }

            return danh_sach;
        }

        private void ParseJsonProperty(string json_line, SinhVien sinh_vien)
        {
            string[] parts = json_line.Split(new[] { ':' }, 2);
            if (parts.Length != 2) return;

            string key = parts[0].Trim().Trim('"');
            string value = parts[1].Trim().TrimEnd(',').Trim('"');

            switch (key)
            {
                case "ten":
                    sinh_vien.ten = value;
                    break;
                case "ma_sinh_vien":
                    sinh_vien.ma_sinh_vien = value;
                    break;
                case "so_dien_thoai":
                    sinh_vien.so_dien_thoai = value;
                    break;
                case "diem_mon1":
                    sinh_vien.diem_mon1 = float.Parse(value, CultureInfo.InvariantCulture);
                    break;
                case "diem_mon2":
                    sinh_vien.diem_mon2 = float.Parse(value, CultureInfo.InvariantCulture);
                    break;
                case "diem_mon3":
                    sinh_vien.diem_mon3 = float.Parse(value, CultureInfo.InvariantCulture);
                    break;
                case "diem_trung_binh":
                    sinh_vien.diem_trung_binh = float.Parse(value, CultureInfo.InvariantCulture);
                    break;
            }
        }

        private void HienThiThongTinSinhVien(int chi_so)
        {
            if (chi_so < 0 || chi_so >= danh_sach_sinh_vien.Count)
                return;

            SinhVien sv = danh_sach_sinh_vien[chi_so];

            txtName_1.Text = sv.ten;
            txtID_1.Text = sv.ma_sinh_vien;
            txtPhone_1.Text = sv.so_dien_thoai;
            txtCourse1_1.Text = sv.diem_mon1.ToString("F2");
            txtCourse2_1.Text = sv.diem_mon2.ToString("F2");
            txtCourse3_1.Text = sv.diem_mon3.ToString("F2");
            txtAverage.Text = sv.diem_trung_binh.ToString("F2");

            lblPage.Text = string.Format("{0} / {1}", chi_so + 1, danh_sach_sinh_vien.Count);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (!KiemTraDanhSachCoSinhVien())
                return;

            if (chi_so_hien_tai > 0)
            {
                chi_so_hien_tai--;
                HienThiThongTinSinhVien(chi_so_hien_tai);
            }
            else
            {
                MessageBox.Show(
                    "?ây là sinh viên ??u tiên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!KiemTraDanhSachCoSinhVien())
                return;

            if (chi_so_hien_tai < danh_sach_sinh_vien.Count - 1)
            {
                chi_so_hien_tai++;
                HienThiThongTinSinhVien(chi_so_hien_tai);
            }
            else
            {
                MessageBox.Show(
                    "?ây là sinh viên cu?i cùng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private bool KiemTraDanhSachCoSinhVien()
        {
            if (danh_sach_sinh_vien.Count == 0)
            {
                MessageBox.Show(
                    "Ch?a có d? li?u sinh viên!\n\nVui lòng nh?n nút 'Read from a file' ?? ??c d? li?u.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }

    public class SinhVien
    {
        public string ten { get; set; }
        public string ma_sinh_vien { get; set; }
        public string so_dien_thoai { get; set; }
        public float diem_mon1 { get; set; }
        public float diem_mon2 { get; set; }
        public float diem_mon3 { get; set; }
        public float diem_trung_binh { get; set; }
    }
}
