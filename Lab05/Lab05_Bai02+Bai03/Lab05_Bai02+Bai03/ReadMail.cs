using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace Lab05_Bai02_Bai03
{
    public partial class ReadMail : Form
    {
        public ReadMail()
        {
            InitializeComponent();
        }

        private void button_Login_IMAP_Click(object sender, EventArgs e)
        {
            listView_Mails.Items.Clear();

            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate(textBox_Email.Text, textBox_Password.Text);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                label_Total.Text = label_Total.Text + " " + inbox.Count.ToString();
                label_Recent.Text = label_Recent.Text + " " + inbox.Recent.ToString();

                // lấy 15 mail gần nhất
                int limit = Math.Min(16, inbox.Count);

                for (int i = inbox.Count - 1; i >= inbox.Count - limit; i--)
                {
                    var message = inbox.GetMessage(i);

                    ListViewItem item = new ListViewItem(message.Subject);
                    item.SubItems.Add(message.From.ToString());
                    item.SubItems.Add(message.Date.ToString("dd/MM/yyyy HH:mm"));

                    listView_Mails.Items.Add(item);
                }

                client.Disconnect(true);
            }
        }

        private void button_Login_POP3_Click(object sender, EventArgs e)
        {
            listView_Mails.Items.Clear();
            try
            {
                using (var client = new MailKit.Net.Pop3.Pop3Client())
                {
                    client.Connect("pop.gmail.com", 995, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(textBox_Email.Text, textBox_Password.Text);

                    int count = client.Count;
                    label_Total.Text = label_Total.Text + " " + client.Count.ToString();
                    label_Recent.Text = label_Recent.Text + " " + "0";

                    int limit = Math.Min(16, count);

                    for (int i = count - 1; i >= Math.Max(0, count - limit); i--)
                    {
                        MimeMessage message = client.GetMessage(i);

                        ListViewItem item = new ListViewItem(message.Subject ?? "(No subject)");
                        item.SubItems.Add(message.From.ToString());
                        item.SubItems.Add(message.Date.ToString("dd/MM/yyyy HH:mm"));

                        listView_Mails.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ResizeColumns()
        {
            int totalWidth = listView_Mails.ClientSize.Width;

            listView_Mails.Columns[0].Width = (int)(totalWidth * 0.55); 
            listView_Mails.Columns[1].Width = (int)(totalWidth * 0.30);
            listView_Mails.Columns[2].Width = (int)(totalWidth * 0.15); 
        }


        private void ReadMail_Load(object sender, EventArgs e)
        {
            listView_Mails.Clear();

            listView_Mails.View = View.Details;
            listView_Mails.FullRowSelect = true;
            listView_Mails.GridLines = true;
            listView_Mails.HideSelection = false;

            listView_Mails.Columns.Add("Subject");
            listView_Mails.Columns.Add("From");
            listView_Mails.Columns.Add("Time");
            ResizeColumns();
        }
    }
}
