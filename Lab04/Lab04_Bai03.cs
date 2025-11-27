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
        private string filePath = "D:\\Bai03.html";
        private string saveDirectory = "D:\\";
        public Lab04_Bai03()
        {
            InitializeComponent();
            InitializeAsync();
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
            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                webView2.CoreWebView2.Navigate(txtUrl.Text);
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnDownFiles_Click(object sender, EventArgs e)
        {
            using (WebClient myClient = new WebClient())
            {
                Stream reponse = myClient.OpenRead(txtUrl.Text);
                myClient.DownloadFile(txtUrl.Text, filePath);
            }
        }

        private void btnDownResources_Click(object sender, EventArgs e)
        {
            var web = new HtmlAgilityPack.HtmlWeb();
            var doc = web.Load(txtUrl.Text);

            var client = new WebClient();
            Stream read = client.OpenRead(txtUrl.Text);

            foreach (HtmlNode imgNode in doc.DocumentNode.SelectNodes("//img"))
            {

                var imgUrl = imgNode.Attributes["src"].Value;

                if (!string.IsNullOrEmpty(imgUrl))
                {
                    if (!Uri.IsWellFormedUriString(imgUrl, UriKind.Absolute))
                    {
                        Uri baseUri = new Uri(txtUrl.Text);
                        imgUrl = new Uri(baseUri, imgUrl).AbsoluteUri;
                    }

                    string fileName = Path.GetFileName(imgUrl);
                    string savePath = Path.Combine(saveDirectory, fileName);
                    client.DownloadFile(imgUrl, savePath);
                }
            }
        }
    }
}
