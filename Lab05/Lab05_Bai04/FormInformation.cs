using Lab05_Bai04.service;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using MovieBookingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05_Bai04
{
    public partial class FormInformation : Form
    {
        private readonly Movie movie;
        private readonly string bookingFile =
            Path.Combine(Application.StartupPath, "data", "bookings.json");

        public FormInformation(Movie movie)
        {
            InitializeComponent();
            this.movie = movie;

            // load movie info
            Label_Title.Text = movie.TenPhim;
            TextBox_Genre.Text = movie.TheLoai;
            TextBox_Duration.Text = movie.ThoiLuong;
            TextBox_Price.Text = movie.GiaVe.ToString();

            try { PictureBox_Movie.Load(movie.PosterUrl); }
            catch { PictureBox_Movie.Image = null; }

            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "data"));
        }

        private void MovieDetailForm_Load(object sender, EventArgs e)
        {
            // Suất chiếu
            ComboBox_Time.Items.AddRange(new string[]
            {
                "8:00 AM", "10:30 AM", "1:00 PM", "3:30 PM",
                "5:30 PM", "7:00 PM", "9:00 PM", "10:30 PM"
            });

            // Phòng chiếu
            ComboBox_Room.Items.AddRange(new string[]
            {
                "Room 1", "Room 2", "Room 3", "Room 4", "Room 5"
            });

            // Ghế theo loại vé Beta
            for (int i = 1; i <= 5; i++)
                ComboBox_Seat.Items.Add($"Vé vớt - A{i}");

            for (char row = 'B'; row <= 'E'; row++)
                for (int i = 1; i <= 5; i++)
                    ComboBox_Seat.Items.Add($"Vé thường - {row}{i}");

            for (int i = 1; i <= 5; i++)
                ComboBox_Seat.Items.Add($"Vé VIP - F{i}");

            ComboBox_Seat.SelectedIndexChanged += ComboBox_Seat_SelectedIndexChanged;
        }

        // Kiểm tra tên
        private bool KiemTraTen(string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }


        // validate email
        private bool KiemTraEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // cập nhật giá theo loại vé
        private void ComboBox_Seat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_Seat.SelectedItem == null) return;

            string seat = ComboBox_Seat.SelectedItem.ToString();
            int price = 0;

            if (seat.StartsWith("Vé vớt")) price = 40000;
            else if (seat.StartsWith("Vé thường")) price = 80000;
            else if (seat.StartsWith("Vé VIP")) price = 120000;

            TextBox_Price.Text = price.ToString();
        }

        private async void btnBook_Click(object sender, EventArgs e)
        {
            string ten = TextBox_Customer.Text.Trim();
            string email = TextBox_Email.Text.Trim();
            string time = ComboBox_Time.Text;
            string room = ComboBox_Room.Text;
            string seat = ComboBox_Seat.Text;

            if (!KiemTraTen(ten)) { MessageBox.Show("Tên khách không hợp lệ!", "Lỗi"); return; }
            if (!KiemTraEmail(email)) { MessageBox.Show("Email không hợp lệ!", "Lỗi"); return; }
            if (time == "") { MessageBox.Show("Vui lòng chọn suất chiếu!"); return; }
            if (room == "") { MessageBox.Show("Vui lòng chọn phòng chiếu!"); return; }
            if (seat == "") { MessageBox.Show("Vui lòng chọn ghế!"); return; }

            decimal total = decimal.Parse(TextBox_Price.Text);

            MessageBox.Show(
                $"Khách: {ten}\n" +
                $"Email: {email}\n" +
                $"Phim: {movie.TenPhim}\n" +
                $"Suất chiếu: {time}\n" +
                $"Phòng: {room}\n" +
                $"Ghế: {seat}\n" +
                $"Tổng tiền: {total:N0} VND",
                "Đặt vé thành công"
            );

            var booking = new
            {
                TenPhim = movie.TenPhim,
                KhachHang = ten,
                Email = email,
                TheLoai = movie.TheLoai,
                GioChieu = time,
                PhongChieu = room,
                Ghe = seat,
                GiaVe = TextBox_Price.Text,
                TongTien = total,
                NgayDat = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            };

            List<object> list = new List<object>();
            if (File.Exists(bookingFile))
            {
                string old = File.ReadAllText(bookingFile);
                if (!string.IsNullOrWhiteSpace(old))
                    list = JsonConvert.DeserializeObject<List<object>>(old);
            }

            list.Add(booking);
            File.WriteAllText(bookingFile, JsonConvert.SerializeObject(list, Formatting.Indented));

            Button_Book.Enabled = false;
            Button_Book.Text = "Đang gửi email...";

            try
            {
                await GuiEmailXacNhanAsync(
                    email,
                    ten,
                    movie.TenPhim,
                    time,
                    room,
                    seat,
                    total,
                    movie.PosterUrl
                );

                MessageBox.Show("Đã gửi email xác nhận cho khách!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message);
            }
            finally
            {
                Button_Book.Enabled = true;
                Button_Book.Text = "Book";
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(bookingFile))
            {
                MessageBox.Show("Chưa có dữ liệu để lưu!");
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "JSON file (*.json)|*.json",
                FileName = "bookings.json"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.Copy(bookingFile, dlg.FileName, true);
                MessageBox.Show("Đã lưu file JSON.");
            }
        }

        private async Task GuiEmailXacNhanAsync(
    string emailNguoiNhan,
    string tenKhach,
    string tenPhim,
    string suatChieu,
    string phong,
    string ghe,
    decimal tongTien,
    string posterUrl)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Beta Cinema", EmailConfig.SenderEmail));
            message.To.Add(new MailboxAddress(tenKhach, emailNguoiNhan));
            message.Subject = $"Xác nhận đặt vé - {tenPhim}";

            // HTML email – poster bên phải khung
            string htmlBody = $@"
<div style='font-family:Arial; max-width:850px; margin:auto; padding:20px;'>
    <table style='width:100%; border-spacing:0;'>
        <tr>
            <!-- KHUNG THÔNG TIN BÊN TRÁI -->
            <td style='width:60%; vertical-align:top;'>
                <div style='padding:20px; background:#fafafa; border:1px solid #ddd;
                            border-radius:10px;'>
                    <h2 style='color:#2b57d9; text-align:center; margin:0;'>BETA CINEMA</h2>
                    <h3 style='text-align:center; margin-top:5px; color:#555;'>
                        XÁC NHẬN ĐẶT VÉ THÀNH CÔNG
                    </h3>

                    <hr style='border:0; border-top:1px solid #ccc; margin:20px 0;' />

                    <p><b>Khách hàng:</b> {tenKhach}</p>
                    <p><b>Phim:</b> {tenPhim}</p>
                    <p><b>Suất chiếu:</b> {suatChieu}</p>
                    <p><b>Phòng:</b> {phong}</p>
                    <p><b>Ghế:</b> {ghe}</p>
                    <p><b>Tổng tiền:</b> 
                       <span style='color:#d92525; font-weight:bold;'>{tongTien:N0} VND</span>
                    </p>

                    <hr style='border:0; border-top:1px solid #ccc; margin:20px 0;' />
                    <p style='font-size:14px;'>
                        Cảm ơn bạn đã tin tưởng và đặt vé tại <b>Beta Cinema</b>.<br>
                        Chúc bạn có một buổi xem phim thật vui vẻ!
                    </p>

                    <p style='text-align:center; margin-top:30px; font-size:12px; color:#888;'>
                        Đây là email tự động, vui lòng không trả lời tin nhắn này.
                    </p>
                </div>
            </td>

            <!-- POSTER BÊN PHẢI (KHÔNG DÙNG CID) -->
            <td style='width:40%; vertical-align:top; text-align:right; padding-left:15px;'>
                <img src='{posterUrl}' 
                     style='width:250px; border-radius:10px; border:1px solid #ddd;' />
            </td>
        </tr>
    </table>
</div>";

            var builder = new BodyBuilder();
            builder.HtmlBody = htmlBody;

            message.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync("smtp.gmail.com", 587, false);
                await smtp.AuthenticateAsync(EmailConfig.SenderEmail, EmailConfig.SenderPassword);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void Label_Customer_Click(object sender, EventArgs e) { }
        private void groupBoxDetail_Enter(object sender, EventArgs e) { }
    }
}
