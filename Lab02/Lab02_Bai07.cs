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

namespace NT106_Lab02
{
    /// <summary>
    /// Form duyệt file và thư mục - Lab02 Bài 07
    /// Chức năng: Duyệt file system, hiển thị nội dung file
    /// </summary>
    public partial class Lab02_Bai07 : Form
    {
        // Class xử lý file system
        private QuanLyFileSystem quanly_file;

        // Dictionary lưu các icon
        private Dictionary<string, int> danh_sach_icon;

        public Lab02_Bai07()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện Load form
        /// </summary>
        private void Lab02_Bai07_Load(object sender, EventArgs e)
        {
            // Thiết lập form
            this.Text = "Lab02 Bai 07 - File Explorer";
            
            // Khởi tạo quản lý file system
            quanly_file = new QuanLyFileSystem();
            
            // Khởi tạo icon
            KhoiTaoIcon();
            
            // Tải danh sách ổ đĩa
            TaiDanhSachODia();
        }

        /// <summary>
        /// Khởi tạo icon cho thư mục và file
        /// </summary>
        private void KhoiTaoIcon()
        {
            try
            {
                // Tạo icon thư mục (màu vàng)
                Bitmap icon_thu_muc = TaoIconThuMuc();
                
                // Tạo icon file (màu trắng)
                Bitmap icon_file = TaoIconFile();
                
                // Thêm vào ImageList
                imageList.Images.Add("folder", icon_thu_muc);
                imageList.Images.Add("file", icon_file);
                
                // Lưu index
                danh_sach_icon = new Dictionary<string, int>
                {
                    { "folder", 0 },
                    { "file", 1 }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Cảnh báo: Không thể tạo icon: {0}", ex.Message), 
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Tạo icon thư mục
        /// </summary>
        private Bitmap TaoIconThuMuc()
        {
            Bitmap icon = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(icon))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 204, 0)))
                {
                    g.FillRectangle(brush, 2, 5, 12, 9);
                    g.FillPolygon(brush, new Point[] { 
                        new Point(2, 5), new Point(6, 2), new Point(10, 5) 
                    });
                }
                using (Pen pen = new Pen(Color.FromArgb(255, 153, 102, 0), 1))
                {
                    g.DrawRectangle(pen, 2, 5, 12, 9);
                    g.DrawLine(pen, 2, 5, 6, 2);
                    g.DrawLine(pen, 6, 2, 10, 5);
                }
            }
            return icon;
        }

        /// <summary>
        /// Tạo icon file
        /// </summary>
        private Bitmap TaoIconFile()
        {
            Bitmap icon = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(icon))
            {
                g.Clear(Color.Transparent);
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(brush, 4, 2, 8, 12);
                }
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    g.DrawRectangle(pen, 4, 2, 8, 12);
                    g.DrawLine(pen, 6, 5, 10, 5);
                    g.DrawLine(pen, 6, 7, 10, 7);
                    g.DrawLine(pen, 6, 9, 10, 9);
                }
            }
            return icon;
        }

        /// <summary>
        /// Tải danh sách ổ đĩa vào TreeView
        /// </summary>
        private void TaiDanhSachODia()
        {
            treeView_files.Nodes.Clear();
            
            try
            {
                // Lấy tất cả ổ đĩa
                DriveInfo[] cac_o_dia = DriveInfo.GetDrives();
                
                foreach (DriveInfo o_dia in cac_o_dia)
                {
                    if (o_dia.IsReady)
                    {
                        // Tạo node cho ổ đĩa
                        TreeNode node_o_dia = new TreeNode(
                            string.Format("{0} {1}", o_dia.Name, o_dia.VolumeLabel))
                        {
                            Tag = o_dia.RootDirectory,
                            ImageKey = "folder",
                            SelectedImageKey = "folder"
                        };
                        
                        // Thêm node dummy để có thể expand
                        node_o_dia.Nodes.Add("Loading...");
                        
                        treeView_files.Nodes.Add(node_o_dia);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi tải danh sách ổ đĩa: {0}", ex.Message), 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện trước khi expand node
        /// </summary>
        private void treeView_files_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // Kiểm tra node đã được load chưa
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "Loading...")
            {
                e.Node.Nodes.Clear();
                
                DirectoryInfo thu_muc = e.Node.Tag as DirectoryInfo;
                if (thu_muc != null && thu_muc.Exists)
                {
                    TaiNoiDungThuMuc(e.Node, thu_muc);
                }
            }
        }

        /// <summary>
        /// Tải nội dung thư mục (thư mục con và file)
        /// </summary>
        private void TaiNoiDungThuMuc(TreeNode node_cha, DirectoryInfo thu_muc)
        {
            try
            {
                // Tải thư mục con
                DirectoryInfo[] cac_thu_muc_con = thu_muc.GetDirectories();
                foreach (DirectoryInfo thu_muc_con in cac_thu_muc_con)
                {
                    // Bỏ qua thư mục ẩn và system
                    if (quanly_file.LaFileAnHoacSystem(thu_muc_con.Attributes))
                        continue;

                    TreeNode node_thu_muc = new TreeNode(thu_muc_con.Name)
                    {
                        Tag = thu_muc_con,
                        ImageKey = "folder",
                        SelectedImageKey = "folder"
                    };
                    
                    // Thêm node dummy
                    node_thu_muc.Nodes.Add("Loading...");
                    
                    node_cha.Nodes.Add(node_thu_muc);
                }

                // Tải file
                FileInfo[] cac_file = thu_muc.GetFiles();
                foreach (FileInfo file in cac_file)
                {
                    // Bỏ qua file ẩn và system
                    if (quanly_file.LaFileAnHoacSystem(file.Attributes))
                        continue;

                    TreeNode node_file = new TreeNode(file.Name)
                    {
                        Tag = file,
                        ImageKey = "file",
                        SelectedImageKey = "file"
                    };
                    
                    node_cha.Nodes.Add(node_file);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Thư mục không có quyền truy cập
                TreeNode node_loi = new TreeNode("[Không có quyền truy cập]")
                {
                    ForeColor = Color.Red
                };
                node_cha.Nodes.Add(node_loi);
            }
            catch (Exception ex)
            {
                // Lỗi khác
                TreeNode node_loi = new TreeNode(string.Format("[Lỗi: {0}]", ex.Message))
                {
                    ForeColor = Color.Red
                };
                node_cha.Nodes.Add(node_loi);
            }
        }

        /// <summary>
        /// Xử lý sự kiện sau khi chọn node
        /// </summary>
        private void treeView_files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is FileInfo)
            {
                FileInfo file = (FileInfo)e.Node.Tag;
                HienThiNoiDungFile(file);
            }
            else
            {
                // Chọn thư mục - xóa nội dung hiển thị
                XoaNoiDungHienThi();
            }
        }

        /// <summary>
        /// Hiển thị nội dung file
        /// </summary>
        private void HienThiNoiDungFile(FileInfo file)
        {
            try
            {
                label_file_content.Text = string.Format("File Content: {0}", file.Name);
                
                string phan_mo_rong = file.Extension.ToLower();
                
                // Kiểm tra loại file
                if (quanly_file.LaFileAnh(phan_mo_rong))
                {
                    HienThiFileAnh(file);
                }
                else if (quanly_file.LaFileVanBan(phan_mo_rong))
                {
                    HienThiFileVanBan(file);
                }
                else
                {
                    HienThiThongTinFile(file);
                }
            }
            catch (Exception ex)
            {
                richTextBox_content.Visible = true;
                pictureBox_preview.Visible = false;
                richTextBox_content.Text = string.Format("Lỗi đọc file: {0}", ex.Message);
            }
        }

        /// <summary>
        /// Hiển thị file ảnh
        /// </summary>
        private void HienThiFileAnh(FileInfo file)
        {
            richTextBox_content.Visible = false;
            pictureBox_preview.Visible = true;
            
            // Giải phóng ảnh cũ nếu có
            if (pictureBox_preview.Image != null)
            {
                pictureBox_preview.Image.Dispose();
                pictureBox_preview.Image = null;
            }
            
            // Đọc và hiển thị ảnh mới
            using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                pictureBox_preview.Image = Image.FromStream(fs);
            }
        }

        /// <summary>
        /// Hiển thị file văn bản
        /// </summary>
        private void HienThiFileVanBan(FileInfo file)
        {
            pictureBox_preview.Visible = false;
            richTextBox_content.Visible = true;
            
            // Giải phóng ảnh cũ nếu có
            if (pictureBox_preview.Image != null)
            {
                pictureBox_preview.Image.Dispose();
                pictureBox_preview.Image = null;
            }
            
            // Kiểm tra kích thước file (giới hạn 1MB)
            if (file.Length > 1024 * 1024)
            {
                richTextBox_content.Text = string.Format(
                    "[File quá lớn để hiển thị. Kích thước: {0}]", 
                    quanly_file.DinhDangKichThuoc(file.Length));
            }
            else
            {
                richTextBox_content.Text = File.ReadAllText(file.FullName, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Hiển thị thông tin file
        /// </summary>
        private void HienThiThongTinFile(FileInfo file)
        {
            pictureBox_preview.Visible = false;
            richTextBox_content.Visible = true;
            
            // Giải phóng ảnh cũ nếu có
            if (pictureBox_preview.Image != null)
            {
                pictureBox_preview.Image.Dispose();
                pictureBox_preview.Image = null;
            }
            
            StringBuilder thong_tin = new StringBuilder();
            thong_tin.AppendLine("Thông tin File:");
            thong_tin.AppendLine("==================");
            thong_tin.AppendLine(string.Format("Tên: {0}", file.Name));
            thong_tin.AppendLine(string.Format("Đường dẫn: {0}", file.FullName));
            thong_tin.AppendLine(string.Format("Kích thước: {0}", quanly_file.DinhDangKichThuoc(file.Length)));
            thong_tin.AppendLine(string.Format("Ngày tạo: {0}", file.CreationTime));
            thong_tin.AppendLine(string.Format("Ngày sửa: {0}", file.LastWriteTime));
            thong_tin.AppendLine(string.Format("Phần mở rộng: {0}", file.Extension));
            thong_tin.AppendLine();
            thong_tin.AppendLine("[Không thể xem trước loại file này]");
            
            richTextBox_content.Text = thong_tin.ToString();
        }

        /// <summary>
        /// Xóa nội dung hiển thị
        /// </summary>
        private void XoaNoiDungHienThi()
        {
            richTextBox_content.Clear();
            
            if (pictureBox_preview.Image != null)
            {
                pictureBox_preview.Image.Dispose();
                pictureBox_preview.Image = null;
            }
            
            pictureBox_preview.Visible = false;
            richTextBox_content.Visible = true;
            label_file_content.Text = "File Content";
        }
    }

    /// <summary>
    /// Class quản lý file system
    /// </summary>
    public class QuanLyFileSystem
    {
        // Danh sách phần mở rộng file ảnh
        private readonly string[] phan_mo_rong_anh = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".ico" };
        
        // Danh sách phần mở rộng file văn bản
        private readonly string[] phan_mo_rong_van_ban = { 
            ".txt", ".cs", ".xml", ".json", ".log", ".config",
            ".html", ".css", ".js", ".ini", ".md", ".csv" 
        };

        /// <summary>
        /// Kiểm tra file có phải file ẩn hoặc system không
        /// </summary>
        public bool LaFileAnHoacSystem(FileAttributes thuoc_tinh)
        {
            return (thuoc_tinh & FileAttributes.Hidden) == FileAttributes.Hidden ||
                   (thuoc_tinh & FileAttributes.System) == FileAttributes.System;
        }

        /// <summary>
        /// Kiểm tra file có phải file ảnh không
        /// </summary>
        public bool LaFileAnh(string phan_mo_rong)
        {
            return phan_mo_rong_anh.Contains(phan_mo_rong.ToLower());
        }

        /// <summary>
        /// Kiểm tra file có phải file văn bản không
        /// </summary>
        public bool LaFileVanBan(string phan_mo_rong)
        {
            return phan_mo_rong_van_ban.Contains(phan_mo_rong.ToLower());
        }

        /// <summary>
        /// Định dạng kích thước file dạng dễ đọc
        /// </summary>
        public string DinhDangKichThuoc(long bytes)
        {
            string[] don_vi = { "B", "KB", "MB", "GB", "TB" };
            double kich_thuoc = bytes;
            int cap_do = 0;
            
            while (kich_thuoc >= 1024 && cap_do < don_vi.Length - 1)
            {
                cap_do++;
                kich_thuoc = kich_thuoc / 1024;
            }
            
            return string.Format("{0:0.##} {1}", kich_thuoc, don_vi[cap_do]);
        }
    }
}
