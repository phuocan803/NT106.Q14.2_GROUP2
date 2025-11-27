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
    public partial class Lab02_Bai02 : Form
    {
        public Lab02_Bai02()
        {
            InitializeComponent();
        }

        private void button_docfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|All Files|*.*";
            ofd.Title = "Chọn file văn bản";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);

                    textbox_tenfile.Text = ofd.SafeFileName;
                    textbox_kichco.Text = FormatFileSize(fileInfo.Length);
                    textbox_url.Text = ofd.FileName;

                    string content;
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        content = reader.ReadToEnd();
                    }

                    int lineCount = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                    int wordCount = content.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
                    int charCount = content.Length;

                    textbox_sodong.Text = lineCount.ToString();
                    textbox_sotu.Text = wordCount.ToString();
                    textbox_sokytu.Text = charCount.ToString();

                    richtextbox_noidung.Text = content;

                    MessageBox.Show("Đọc file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Lỗi đọc file:\n{0}", ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
    }
}
