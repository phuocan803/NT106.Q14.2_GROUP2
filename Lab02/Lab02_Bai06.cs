using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab02_Bai6
{
    public partial class Bai06 : Form
    {

        private readonly string _dbPath = Path.Combine(Application.StartupPath, "monan.db");
        private string ConnStr => $"Data Source={_dbPath}";
        private readonly Dictionary<int, string> _nccById = new Dictionary<int, string>();


        public Bai06()
        {
            InitializeComponent();
        }
        public Bai06(Point location, Size size)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = location;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitListViews();
            InitControls();
            EnsureDatabase();
            LoadNcc();
            LoadMonAn();
        }
        
        private void InitControls()
        {
            // Set PictureBox to stretch images properly
            pictureBox_HinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            
            // Make textboxes read-only (display only)
            textBox_TenMonAn.ReadOnly = true;
            textBox_TenNCC.ReadOnly = true;
        }
        
        private void RecreateSchema()
        {
            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();

                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
            DROP VIEW  IF EXISTS v_DanhSachMonAn;
            DROP TABLE IF EXISTS MonAn;
            DROP TABLE IF EXISTS NguoiDung;";
                    cmd.ExecuteNonQuery();
                }

                // chạy lại schema để tạo bảng + seed
                EnsureDatabase();
            }
        }
        private void RebuildDb()
        {
            if (File.Exists(_dbPath)) File.Delete(_dbPath);
            EnsureDatabase(); // chạy lại schema để tạo bảng + seed
        }

        private void EnsureDatabase()
        {
            var schemaPath = Path.Combine(Application.StartupPath, "schema_lab02_bai06.sqlite.sql");
            if (!File.Exists(schemaPath))
            {
                MessageBox.Show("Không tìm thấy file schema ở:\n" + schemaPath);
                return;
            }

            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();

                // chạy schema
                var sql = File.ReadAllText(schemaPath, Encoding.UTF8);
                using (var tx = cn.BeginTransaction())
                using (var cmd = cn.CreateCommand())
                {
                    cmd.Transaction = tx;
                    cmd.CommandText = sql;        // có thể chứa nhiều lệnh
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                }

                // sanity check: bảng phải tồn tại
                using (var check = cn.CreateCommand())
                {
                    check.CommandText = @"SELECT COUNT(1)
                          FROM sqlite_master
                          WHERE type='table' AND name IN ('NguoiDung','MonAn');";
                    var have = Convert.ToInt32(check.ExecuteScalar());
                    if (have < 2)
                    {
                        MessageBox.Show(
                            "Schema chưa áp dụng (thiếu bảng NguoiDung/MonAn).\n" +
                            "Kiểm tra nội dung file schema và đường dẫn DB:\n" +
                            _dbPath);
                    }
                }
            }
        }

        private void LoadNcc()
        {
            _nccById.Clear();
            listView_NCC.Items.Clear();

            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IDNCC, HoVaTen, QuyenHan FROM NguoiDung ORDER BY IDNCC;";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            int id = rd.GetInt32(0);
                            string ten = rd.GetString(1);
                            string quyen = rd.GetString(2);

                            // add vào ListView phải
                            var it = new ListViewItem(id.ToString());
                            it.SubItems.Add(ten);
                            it.SubItems.Add(quyen);
                            listView_NCC.Items.Add(it);

                            // *** cache để tra nhanh khi click món ăn
                            _nccById[id] = ten;
                        }
                    }
                }
            }
        }

        private void LoadMonAn()
        {
            listView_MonAn.Items.Clear();
            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IDMA, TenMonAn, IFNULL(HinhAnh,''), IDNCC FROM MonAn ORDER BY IDMA;";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var it = new ListViewItem(rd.GetInt32(0).ToString());
                            it.SubItems.Add(rd.GetString(1));
                            it.SubItems.Add(rd.GetString(2));
                            it.SubItems.Add(rd.GetInt32(3).ToString());
                            listView_MonAn.Items.Add(it);
                        }
                    }
                }
            }
        }
        private void TestConnection()
        {
            using (var cn = new SQLiteConnection(ConnStr))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT sqlite_version();";
                    var ver = (string)cmd.ExecuteScalar();
                    MessageBox.Show("SQLite OK - Version: " + ver);
                }
            }
        }
        private void InitListViews()
        {
            listView_MonAn.View = View.Details;
            listView_MonAn.FullRowSelect = true;
            listView_MonAn.GridLines = true;
            if (listView_MonAn.Columns.Count == 0)
            {
                listView_MonAn.Columns.Add("IDMA", 70);
                listView_MonAn.Columns.Add("TenMonAn", 160);
                listView_MonAn.Columns.Add("HinhAnh", 180);
                listView_MonAn.Columns.Add("IDNCC", 70);
            }

            listView_NCC.View = View.Details;
            listView_NCC.FullRowSelect = true;
            listView_NCC.GridLines = true;
            if (listView_NCC.Columns.Count == 0)
            {
                listView_NCC.Columns.Add("IDNCC", 70);
                listView_NCC.Columns.Add("HoVaTen", 150);
                listView_NCC.Columns.Add("QuyenHan", 90);
            }
        }
        private void listView_MonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_MonAn.SelectedItems.Count == 0) return;

            var it = listView_MonAn.SelectedItems[0];
            textBox_TenMonAn.Text = it.SubItems[1].Text;

            // ảnh
            ShowImageSafe(it.SubItems[2].Text);

            // tên NCC theo ID (không cần quét ListView_NCC)
            if (int.TryParse(it.SubItems[3].Text, out int idNcc) &&
                _nccById.TryGetValue(idNcc, out var tenNcc))
                textBox_TenNCC.Text = tenNcc;
            else
                textBox_TenNCC.Clear();
        }

        private void button_TimMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cn = new SQLiteConnection(ConnStr))
                {
                    cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT MA.IDMA, MA.TenMonAn, IFNULL(MA.HinhAnh,''), ND.HoVaTen
                        FROM MonAn MA JOIN NguoiDung ND ON ND.IDNCC = MA.IDNCC
                        ORDER BY RANDOM() LIMIT 1;";
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                var idma = rd.GetInt32(0).ToString();
                                textBox_TenMonAn.Text = rd.GetString(1);
                                ShowImageSafe(rd.GetString(2));
                                textBox_TenNCC.Text = rd.GetString(3);
                                
                                // chọn dòng tương ứng trong ListView
                                foreach (ListViewItem li in listView_MonAn.Items)
                                {
                                    li.Selected = (li.Text == idma);
                                    if (li.Selected)
                                        li.EnsureVisible();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy món ăn nào trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void ShowImageSafe(string path)
        {
            try
            {
                if (pictureBox_HinhAnh.Image != null)
                {
                    pictureBox_HinhAnh.Image.Dispose();
                    pictureBox_HinhAnh.Image = null;
                }

                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        pictureBox_HinhAnh.Image = Image.FromStream(fs);
                    }
                }
            }
            catch
            {
                // bỏ qua lỗi đọc ảnh
            }
        }
    }
}