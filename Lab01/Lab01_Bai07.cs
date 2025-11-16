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
    /// Form xem cung hoàng đạo - Lab01 Bài 07
    /// Chức năng: Xác định cung hoàng đạo dựa trên ngày sinh được chọn
    /// </summary>
    public partial class Lab01_Bai07 : Form
    {
        /// <summary>
        /// Constructor - Khởi tạo form
        /// </summary>
        public Lab01_Bai07()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện Load form - Thiết lập giao diện ban đầu
        /// </summary>
        private void Lab01_Bai07_Load(object sender, EventArgs e)
        {
            // Thiết lập tiêu đề form
            this.Text = "Bài 07 - Cung hoàng đạo";
            
            // Thiết lập TextBox kết quả chỉ đọc
            textBox_ket_qua.ReadOnly = true;
            
            // Thiết lập DateTimePicker hiển thị ngày hiện tại
            dateTimePicker.Value = DateTime.Now;
            dateTimePicker.Format = DateTimePickerFormat.Short;
        }

        /// <summary>
        /// Sự kiện click nút "Xem" - Xác định và hiển thị cung hoàng đạo
        /// </summary>
        private void button_xem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày được chọn từ DateTimePicker
                DateTime ngayDuocChon = dateTimePicker.Value;
                int ngay = ngayDuocChon.Day;
                int thang = ngayDuocChon.Month;
                
                // Xác định cung hoàng đạo dựa trên ngày và tháng
                string cungHoangDao = LayTenCungHoangDao(ngay, thang);
                
                // Hiển thị kết quả
                textBox_ket_qua.Text = cungHoangDao;
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi không mong muốn
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xác định cung hoàng đạo dựa trên ngày và tháng sinh
        /// </summary>
        /// <param name="ngay">Ngày sinh</param>
        /// <param name="thang">Tháng sinh</param>
        /// <returns>Tên cung hoàng đạo tương ứng</returns>
        private string LayTenCungHoangDao(int ngay, int thang)
        {
            // Sử dụng switch-case để xác định cung hoàng đạo theo tháng
            switch (thang)
            {
                case 1: // Tháng 1 (January)
                    if (ngay >= 21)
                        return "Cung Bảo Bình"; // 21/01 – 19/02
                    else
                        return "Cung Ma Kết"; // 22/12 – 20/01
                
                case 2: // Tháng 2 (February)
                    if (ngay >= 20)
                        return "Cung Song Ngư"; // 20/02 – 20/03
                    else
                        return "Cung Bảo Bình"; // 21/01 – 19/02
                
                case 3: // Tháng 3 (March)
                    if (ngay >= 21)
                        return "Cung Bạch Dương"; // 21/03 – 20/04
                    else
                        return "Cung Song Ngư"; // 20/02 – 20/03
                
                case 4: // Tháng 4 (April)
                    if (ngay >= 21)
                        return "Cung Kim Ngưu"; // 21/04 – 21/05
                    else
                        return "Cung Bạch Dương"; // 21/03 – 20/04
                
                case 5: // Tháng 5 (May)
                    if (ngay >= 22)
                        return "Cung Song Tử"; // 22/05 – 21/06
                    else
                        return "Cung Kim Ngưu"; // 21/04 – 21/05
                
                case 6: // Tháng 6 (June)
                    if (ngay >= 22)
                        return "Cung Cư Giải"; // 22/06 – 22/07
                    else
                        return "Cung Song Tử"; // 22/05 – 21/06
                
                case 7: // Tháng 7 (July)
                    if (ngay >= 23)
                        return "Cung Sư Tử"; // 23/07 – 22/08
                    else
                        return "Cung Cư Giải"; // 22/06 – 22/07
                
                case 8: // Tháng 8 (August)
                    if (ngay >= 23)
                        return "Cung Xử Nữ"; // 23/08 – 23/09
                    else
                        return "Cung Sư Tử"; // 23/07 – 22/08
                
                case 9: // Tháng 9 (September)
                    if (ngay >= 24)
                        return "Cung Thiên Bình"; // 24/09 – 23/10
                    else
                        return "Cung Xử Nữ"; // 23/08 – 23/09
                
                case 10: // Tháng 10 (October)
                    if (ngay >= 24)
                        return "Cung Thần Nông"; // 24/10 – 22/11
                    else
                        return "Cung Thiên Bình"; // 24/09 – 23/10
                
                case 11: // Tháng 11 (November)
                    if (ngay >= 23)
                        return "Cung Nhân Mã"; // 23/11 – 21/12
                    else
                        return "Cung Thần Nông"; // 24/10 – 22/11
                
                case 12: // Tháng 12 (December)
                    if (ngay >= 22)
                        return "Cung Ma Kết"; // 22/12 – 20/01
                    else
                        return "Cung Nhân Mã"; // 23/11 – 21/12
                
                default:
                    return "Ngày tháng không hợp lệ";
            }
        }

        /// <summary>
        /// Sự kiện thay đổi giá trị DateTimePicker - Xóa kết quả cũ
        /// </summary>
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Xóa kết quả khi ngày thay đổi để người dùng biết cần bấm "Xem" lại
            textBox_ket_qua.Clear();
        }
    }
}

/*
=== SƠ LƯỢC VỀ LOGIC CODE - BÀI 07 ===

1. CHỨC NĂNG CHÍNH:
   - Ứng dụng tra cứu cung hoàng đạo dựa trên ngày sinh
   - Sử dụng DateTimePicker để chọn ngày tháng thân thiện
   - Áp dụng logic phân chia 12 cung hoàng đạo theo lịch phương Tây

2. THÀNH PHẦN GIAO DIỆN:
   - 1 DateTimePicker: chọn ngày sinh (định dạng ngắn)
   - 1 TextBox output: hiển thị tên cung hoàng đạo (readonly)
   - 1 Button: xem cung hoàng đạo
   - Labels mô tả chức năng

3. THUẬT TOÁN XÁC ĐỊNH:
   - 12 cung hoàng đạo với khoảng thời gian cụ thể
   - Switch-case theo tháng, if-else theo ngày
   - Xử lý các trường hợp biên giới giữa các cung

4. DANH SÁCH 12 CUNG HOÀNG ĐẠO:
   - Ma Kết: 22/12 – 20/01
   - Bảo Bình: 21/01 – 19/02  
   - Song Ngư: 20/02 – 20/03
   - Bạch Dương: 21/03 – 20/04
   - Kim Ngưu: 21/04 – 21/05
   - Song Tử: 22/05 – 21/06
   - Cư Giải: 22/06 – 22/07
   - Sư Tử: 23/07 – 22/08
   - Xử Nữ: 23/08 – 23/09
   - Thiên Bình: 24/09 – 23/10
   - Thần Nông: 24/10 – 22/11
   - Nhân Mã: 23/11 – 21/12

5. LOGIC XỬ LÝ:
   - Date extraction: Tách ngày và tháng từ DateTime
   - Month-based switching: Switch theo tháng trước
   - Day-based comparison: So sánh ngày để xác định cung chính xác
   - Boundary handling: Xử lý các ngày ranh giới giữa các cung

6. USER EXPERIENCE:
   - Current date default: Mặc định hiển thị ngày hiện tại
   - Short date format: Định dạng ngày ngắn gọn dễ đọc
   - Auto-clear result: Tự động xóa kết quả khi đổi ngày
   - Immediate feedback: Hiển thị kết quả ngay khi bấm nút

7. TÍNH NĂNG ĐẶC BIỆT:
   - Cross-month zodiac: Xử lý các cung trải dài qua 2 tháng
   - DateTimePicker integration: Sử dụng control chuyên dụng cho ngày
   - Error handling: Xử lý lỗi không mong muốn
   - Vietnamese zodiac names: Tên cung hoàng đạo bằng tiếng Việt
*/
