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
    public partial class Lab02_Bai03 : Form
    {
        private const string INPUT_FILE = "input3.txt";
        private const string OUTPUT_FILE = "output3.txt";

        public Lab02_Bai03()
        {
            InitializeComponent();
        }

        private void button_doc_tinhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                string duong_dan_input = TimDuongDanFile(INPUT_FILE);
                if (duong_dan_input == null)
                {
                    MessageBox.Show(string.Format("Không tìm thấy file {0}!", INPUT_FILE), 
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] cac_dong = File.ReadAllLines(duong_dan_input, Encoding.UTF8);

                richtextbox_input.Text = string.Join(Environment.NewLine, cac_dong);

                StringBuilder ket_qua = new StringBuilder();
                foreach (string dong in cac_dong)
                {
                    if (!string.IsNullOrWhiteSpace(dong))
                    {
                        int tong = TinhTong(dong);
                        ket_qua.AppendLine(string.Format("{0} = {1}", dong, tong));
                    }
                }

                richtextbox_output.Text = ket_qua.ToString();

                string duong_dan_output = Path.Combine(
                    Path.GetDirectoryName(duong_dan_input), OUTPUT_FILE);
                File.WriteAllText(duong_dan_output, ket_qua.ToString(), Encoding.UTF8);

                MessageBox.Show(
                    string.Format("Đã tính toán và ghi kết quả!\nFile output: {0}", duong_dan_output),
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi: {0}", ex.Message), 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private int TinhTong(string bieu_thuc)
        {
            string[] cac_phan_tu = bieu_thuc.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            int tong = 0;
            int dau = 1;

            foreach (string phan_tu in cac_phan_tu)
            {
                if (phan_tu == "+")
                {
                    dau = 1;
                }
                else if (phan_tu == "-")
                {
                    dau = -1;
                }
                else
                {
                    int so;
                    if (int.TryParse(phan_tu, out so))
                    {
                        tong += dau * so;
                    }
                }
            }

            return tong;
        }
    }
}
