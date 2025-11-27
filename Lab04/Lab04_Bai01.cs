using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Lab04_Bai01 : Form
    {
        public Lab04_Bai01()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
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

                string url = txtUrl.Text.Trim();
                
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                    txtUrl.Text = url;
                }

                rtbContent.Text = "Loading...\n";
                
                string result = getHTML(url);
                rtbContent.Text = result;

                MessageBox.Show("Content loaded successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (WebException webEx)
            {
                rtbContent.Text = $"Network Error: {webEx.Message}";
                MessageBox.Show($"Network error: {webEx.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                rtbContent.Text = $"Error: {ex.Message}";
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getHTML(string szUrl)
        {
            WebRequest request = null;
            WebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;

            try
            {
                request = WebRequest.Create(szUrl);
                request.Timeout = 30000; 
                
                response = request.GetResponse();
                
                dataStream = response.GetResponseStream();
                
                reader = new StreamReader(dataStream);
                
                string responseFromServer = reader.ReadToEnd();
                
                return responseFromServer;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (dataStream != null)
                    dataStream.Close();
                if (response != null)
                    response.Close();
            }
        }
    }
}
