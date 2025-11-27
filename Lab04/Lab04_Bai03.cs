using HtmlAgilityPack;
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
using Microsoft.Web.WebView2.Core;

namespace Lab04
{
    public partial class Lab04_Bai03 : Form
    {
        private string saveDirectory;
        
        public Lab04_Bai03()
        {
            InitializeComponent();
            InitializeAsync();
            
            saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Lab04_Downloads");
            
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
        }

        // copy trên docs .microsoft.com
        private async void InitializeAsync()
        {
            try
            {
                await webView2.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrl.Text))
                {
                    MessageBox.Show("Please enter a URL.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string url = txtUrl.Text.Trim();
                
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                    txtUrl.Text = url;
                }

                if (webView2 != null && webView2.CoreWebView2 != null)
                {
                    webView2.CoreWebView2.Navigate(url);
                }
                else
                {
                    MessageBox.Show("WebView2 is not initialized yet. Please wait a moment and try again.", 
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading page: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView2 != null && webView2.CoreWebView2 != null)
                {
                    webView2.CoreWebView2.Reload();
                }
                else
                {
                    MessageBox.Show("No page to reload. Please load a page first.", "Warning", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reloading page: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrl.Text))
                {
                    MessageBox.Show("Please enter a URL.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string url = txtUrl.Text.Trim();
                
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }

                string fileName = "downloaded_page.html";
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

                string filePath = Path.Combine(saveDirectory, fileName);

                using (WebClient myClient = new WebClient())
                {
                    myClient.DownloadFile(url, filePath);
                }

                MessageBox.Show($"File downloaded successfully!\nSaved to: {filePath}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException webEx)
            {
                MessageBox.Show($"Network error: {webEx.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownResources_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrl.Text))
                {
                    MessageBox.Show("Please enter a URL.", "Validation Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string url = txtUrl.Text.Trim();
                
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }

                string resourcesDirectory = Path.Combine(saveDirectory, "resources");
                if (!Directory.Exists(resourcesDirectory))
                {
                    Directory.CreateDirectory(resourcesDirectory);
                }

                var web = new HtmlAgilityPack.HtmlWeb();
                var doc = web.Load(url);

                var imgNodes = doc.DocumentNode.SelectNodes("//img");
                
                if (imgNodes == null || imgNodes.Count == 0)
                {
                    MessageBox.Show("No images found on this page.", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int successCount = 0;
                int failCount = 0;

                using (var client = new WebClient())
                {
                    foreach (HtmlNode imgNode in imgNodes)
                    {
                        try
                        {
                            var srcAttribute = imgNode.Attributes["src"];
                            if (srcAttribute == null || string.IsNullOrEmpty(srcAttribute.Value))
                            {
                                failCount++;
                                continue;
                            }

                            var imgUrl = srcAttribute.Value;

                            if (!Uri.IsWellFormedUriString(imgUrl, UriKind.Absolute))
                            {
                                Uri baseUri = new Uri(url);
                                imgUrl = new Uri(baseUri, imgUrl).AbsoluteUri;
                            }

                            string fileName = Path.GetFileName(new Uri(imgUrl).LocalPath);
                            
                            if (string.IsNullOrEmpty(fileName) || !Path.HasExtension(fileName))
                            {
                                fileName = "image_" + Guid.NewGuid().ToString().Substring(0, 8) + ".jpg";
                            }

                            foreach (char c in Path.GetInvalidFileNameChars())
                            {
                                fileName = fileName.Replace(c, '_');
                            }

                            string savePath = Path.Combine(resourcesDirectory, fileName);
                            
                            client.DownloadFile(imgUrl, savePath);
                            successCount++;
                        }
                        catch
                        {
                            failCount++;
                        }
                    }
                }

                MessageBox.Show($"Download completed!\n" +
                               $"Successfully downloaded: {successCount} images\n" +
                               $"Failed: {failCount} images\n" +
                               $"Saved to: {resourcesDirectory}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading resources: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
