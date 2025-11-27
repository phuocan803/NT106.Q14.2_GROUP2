using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Lab04_Bai02 : Form
    {
        public Lab04_Bai02()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrl.Text))
                {
                    MessageBox.Show("Please enter a URL.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUrl.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPath.Text))
                {
                    MessageBox.Show("Please enter a save path.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPath.Focus();
                    return;
                }

                string url = txtUrl.Text.Trim();
                
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                    txtUrl.Text = url;
                }

                string savePath = txtPath.Text.Trim();

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                string fileName = "downloaded_content.html";
                Uri uri;
                if (Uri.TryCreate(url, UriKind.Absolute, out uri))
                {
                    string pathFileName = Path.GetFileName(uri.LocalPath);
                    if (!string.IsNullOrEmpty(pathFileName) && pathFileName != "/")
                    {
                        fileName = pathFileName;
                    }
                    else
                    {
                        fileName = uri.Host.Replace(".", "_") + ".html";
                    }
                }

                if (!fileName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) && 
                    !fileName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                {
                    fileName += ".html";
                }

                string fullFilePath = Path.Combine(savePath, fileName);

                rtbContent.Text = "Downloading...\n";

                using (WebClient myClient = new WebClient())
                {
                    myClient.DownloadFile(url, fullFilePath);
                }

                string result = File.ReadAllText(fullFilePath, Encoding.UTF8);
                rtbContent.Text = result;

                MessageBox.Show($"File downloaded successfully!\nSaved to: {fullFilePath}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException webEx)
            {
                rtbContent.Text = $"Network Error: {webEx.Message}";
                MessageBox.Show($"Network error: {webEx.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access denied. Please check your permissions for the specified path.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                rtbContent.Text = $"Error: {ex.Message}";
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
