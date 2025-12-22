using System.Net;
using System.Net.Mail;

namespace Lab05
{
    public partial class Lab05_Bai01 : Form
    {
        public Lab05_Bai01()
        {
            InitializeComponent();
            
            txtFrom.Text = "huynhphuocan.ja@gmail.com";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFrom.Text))
                {
                    MessageBox.Show("Please enter sender email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFrom.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTo.Text))
                {
                    MessageBox.Show("Please enter recipient email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSubject.Text))
                {
                    MessageBox.Show("Please enter email subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSubject.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBody.Text))
                {
                    MessageBox.Show("Please enter email body.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBody.Focus();
                    return;
                }


                var client = new SmtpClient("smtp.gmail.com", 587); 
                client.EnableSsl = true; 
                
                client.Credentials = new NetworkCredential("huynhphuocan.ja@gmail.com", "wwri kxei hdvl veju");


                var message = new MailMessage();
                message.From = new MailAddress(txtFrom.Text);
                message.To.Add(new MailAddress(txtTo.Text));
                message.Subject = txtSubject.Text;
                
                message.Body = txtBody.Text;

                client.Send(message);

                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFrom.Clear();
                txtTo.Clear();
                txtSubject.Clear();
                txtBody.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

