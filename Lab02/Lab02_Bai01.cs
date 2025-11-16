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
    public partial class Lab02_Bai01 : Form
    {
        private const string INPUT_FILE = "input1.txt";
        private const string OUTPUT_FILE = "output1.txt";

        public Lab02_Bai01()
        {
            InitializeComponent();
        }

        private void button_doc_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(INPUT_FILE))
                {
                    MessageBox.Show(
                        string.Format("File không tồn tại!\nĐường dẫn: {0}", Path.GetFullPath(INPUT_FILE)),
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                string content;
                using (StreamReader reader = new StreamReader(INPUT_FILE))
                {
                    content = reader.ReadToEnd();
                }

                richtextbox_noidung.Text = content;

                MessageBox.Show("Đọc file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi đọc file:\n{0}", ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ghi_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richtextbox_noidung.Text))
                {
                    MessageBox.Show(
                        "Không có nội dung để ghi.\nVui lòng đọc file trước!",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string uppercaseContent = richtextbox_noidung.Text.ToUpper();

                string projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\")).TrimEnd(Path.DirectorySeparatorChar);
                string outputPath = Path.Combine(projectPath, OUTPUT_FILE);

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.Write(uppercaseContent);
                }

                MessageBox.Show(
                    string.Format("Ghi file thành công!\nĐã lưu vào: {0}", outputPath),
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi ghi file:\n{0}", ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
