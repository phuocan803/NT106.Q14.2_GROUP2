using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.IO;
using System.Windows.Forms;

namespace Lab05_Bai06
{
    public partial class Sent : Form
    {
        private readonly string senderEmail;
        private readonly string senderPassword;

        string attachPath = "";

        public Sent(string email, string password)
        {
            InitializeComponent();

            senderEmail = email;
            senderPassword = password;

            Button_Send.Click += Button_Send_Click;
            Button_Browse.Click += Button_Browse_Click;
        }

        // API cho Reply / Reply All
        public void SetReplyData(string to, string cc, string subject)
        {
            User_To.Text = to;
            User_CC.Text = cc;
            TextBox_Subject.Text = subject;
        }

        // Chọn file đính kèm
        private void Button_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn tệp đính kèm";
            dlg.Filter = "All files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                attachPath = dlg.FileName;
                TextBox_Attach.Text = attachPath;
            }
        }

        // Gửi email
        private async void Button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(User_To.Text))
                {
                    MessageBox.Show("Vui lòng nhập email người nhận!",
                        "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(senderEmail));

                message.To.AddRange(InternetAddressList.Parse(User_To.Text));

                if (!string.IsNullOrWhiteSpace(User_CC.Text))
                    message.Cc.AddRange(InternetAddressList.Parse(User_CC.Text));

                message.Subject = TextBox_Subject.Text;

                var builder = new BodyBuilder();

                // HTML hoặc Text
                if (Check_HTML.Checked)
                    builder.HtmlBody = TextBox_Content.Text;
                else
                    builder.TextBody = TextBox_Content.Text;

                // Đính kèm file
                if (!string.IsNullOrEmpty(attachPath) && File.Exists(attachPath))
                {
                    builder.Attachments.Add(attachPath);
                }

                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                MessageBox.Show("Gửi email thành công!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi email!\n\n" + ex.Message,
                    "SMTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
