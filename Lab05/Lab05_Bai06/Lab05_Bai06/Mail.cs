using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab05_Bai02
{
    public partial class Mail : Form
    {
        string userEmail;
        string userPassword;

        string Folder_Inbox = "INBOX";
        string Folder_Sent = null;
        string Folder_Spam = null;
        string Folder_Trash = null;

        List<MimeMessage> mailCache = new List<MimeMessage>();
        List<MimeEntity> attachmentCache = new List<MimeEntity>();
        MimeMessage currentMail = null;

        public Mail(string email, string password)
        {
            InitializeComponent();

            userEmail = email;
            userPassword = password;

            Button_Compose.Click += Button_Compose_Click;
            Button_Stop.Click += Button_Stop_Click;

            Button_Reply.Click += Button_Reply_Click;
            Button_ReplyAll.Click += Button_ReplyAll_Click;
            Button_Down.Click += Button_Down_Click;

            ListView_Mails.SelectedIndexChanged += ListView_Mails_SelectedIndexChanged;

            Button_Reply.Visible = false;
            Button_ReplyAll.Visible = false;
            Button_Down.Visible = false;

            LoadMailFolder(Folder_Inbox);
        }

        private void DetectGmailFolders(ImapClient client)
        {
            Folder_Inbox = "INBOX";
            var gmail = client.GetFolder("[Gmail]");

            foreach (var folder in gmail.GetSubfolders(false))
            {
                string name = folder.FullName.ToLower();
                if (name.Contains("sent")) Folder_Sent = folder.FullName;
                if (name.Contains("spam")) Folder_Spam = folder.FullName;
                if (name.Contains("trash") || name.Contains("bin"))
                    Folder_Trash = folder.FullName;
            }

            if (Folder_Sent == null) Folder_Sent = "[Gmail]/Sent Mail";
            if (Folder_Spam == null) Folder_Spam = "[Gmail]/Spam";
            if (Folder_Trash == null) Folder_Trash = "[Gmail]/Trash";
        }

        private async void LoadMailFolder(string folderName)
        {
            try
            {
                ListView_Mails.Items.Clear();
                mailCache.Clear();
                attachmentCache.Clear();
                HideButtons();

                using (var client = new ImapClient())
                {
                    await client.ConnectAsync("imap.gmail.com", 993, true);
                    await client.AuthenticateAsync(userEmail, userPassword);

                    DetectGmailFolders(client);

                    var folder = await client.GetFolderAsync(folderName);
                    await folder.OpenAsync(FolderAccess.ReadOnly);

                    var uids = (await folder.SearchAsync(SearchQuery.All))
                               .OrderByDescending(u => u)
                               .ToList();

                    foreach (var uid in uids)
                    {
                        var mail = await folder.GetMessageAsync(uid);
                        mailCache.Add(mail);

                        ListView_Mails.Items.Add(new ListViewItem(new string[]
                        {
                            mail.From.ToString(),
                            mail.Subject ?? "(No subject)",
                            mail.Date.LocalDateTime.ToString("dd/MM/yyyy HH:mm")
                        }));
                    }

                    Label_Total.Text = $"Total: {mailCache.Count} emails";
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải mail!\n\n" + ex.Message,
                    "IMAP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListView_Mails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView_Mails.SelectedItems.Count == 0)
            {
                currentMail = null;
                HideButtons();
                return;
            }

            int index = ListView_Mails.SelectedItems[0].Index;
            currentMail = mailCache[index];

            Label_Subject.Text = currentMail.Subject;
            Label_From.Text = "From: " + currentMail.From;
            Label_Date.Text = currentMail.Date.LocalDateTime.ToString();

            DisplayHtmlMail(currentMail);

            attachmentCache.Clear();
            foreach (var att in currentMail.Attachments)
                attachmentCache.Add(att);

            Button_Reply.Visible = true;
            Button_ReplyAll.Visible = true;
            Button_Down.Visible = attachmentCache.Count > 0;
        }

        private void DisplayHtmlMail(MimeMessage mail)
        {
            if (string.IsNullOrEmpty(mail.HtmlBody))
            {
                ViewMail.DocumentText = "<pre>" + mail.TextBody + "</pre>";
                return;
            }

            string html = mail.HtmlBody;
            string tempDir = Path.Combine(Path.GetTempPath(), "MailImages");
            Directory.CreateDirectory(tempDir);

            foreach (var part in mail.BodyParts)
            {
                if (part is MimePart img &&
                    img.ContentId != null &&
                    img.ContentType.MediaType == "image")
                {
                    string cid = img.ContentId.Trim('<', '>');
                    string filePath = Path.Combine(
                        tempDir, cid + "." + img.ContentType.MediaSubtype);

                    using (var fs = File.Create(filePath))
                        img.Content.DecodeTo(fs);

                    html = html.Replace(
                        "cid:" + cid,
                        "file:///" + filePath.Replace("\\", "/"));
                }
            }

            ViewMail.DocumentText = html;
        }

        private void Button_Reply_Click(object sender, EventArgs e)
        {
            if (currentMail == null) return;

            var f = new Lab05_Bai06.Sent(userEmail, userPassword);
            f.SetReplyData(
                currentMail.From.ToString(),
                "",
                "Re: " + currentMail.Subject
            );
            f.Show();
        }

        private void Button_ReplyAll_Click(object sender, EventArgs e)
        {
            if (currentMail == null) return;

            var f = new Lab05_Bai06.Sent(userEmail, userPassword);
            string cc = currentMail.Cc.Count > 0
                        ? string.Join(",", currentMail.Cc.Mailboxes)
                        : "";

            f.SetReplyData(
                currentMail.From.ToString(),
                cc,
                "Re: " + currentMail.Subject
            );
            f.Show();
        }

        private void Button_Down_Click(object sender, EventArgs e)
        {
            if (attachmentCache.Count == 0)
            {
                MessageBox.Show("Email không có tệp đính kèm.");
                return;
            }

            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Chọn thư mục lưu tệp đính kèm";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                foreach (var entity in attachmentCache)
                {
                    if (entity is MimePart part)
                    {
                        string path = Path.Combine(dlg.SelectedPath, part.FileName);
                        using (var stream = File.Create(path))
                            part.Content.DecodeTo(stream);
                    }
                    else if (entity is MessagePart msgPart)
                    {
                        string path = Path.Combine(dlg.SelectedPath, "attached.eml");
                        using (var stream = File.Create(path))
                            msgPart.Message.WriteTo(stream);
                    }
                }
            }

            MessageBox.Show("Tải tệp đính kèm thành công!");
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            ListView_Mails.SelectedItems.Clear();
            ViewMail.DocumentText = "";
            Label_Subject.Text = "";
            Label_From.Text = "";
            Label_Date.Text = "";
            HideButtons();
            currentMail = null;
        }

        private void Button_Compose_Click(object sender, EventArgs e)
        {
            new Lab05_Bai06.Sent(userEmail, userPassword).Show();
        }

        private void HideButtons()
        {
            Button_Reply.Visible = false;
            Button_ReplyAll.Visible = false;
            Button_Down.Visible = false;
        }
    }
}
