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
            //string result = getHTML(txtUrl.Text);
            //rtbContent.Text = result;

            using (WebClient myClient = new WebClient())
            {
                //string fileName = "downloaded_content.html";
                //webClient.DownloadFile(txtUrl.Text, fileName);


                Stream reponse = myClient.OpenRead(txtUrl.Text);

                myClient.DownloadFile(txtUrl.Text, txtPath.Text + "downloaded_content.html");

                string result = File.ReadAllText(txtPath.Text + "downloaded_content.html");

                rtbContent.Text = result;

                reponse.Close();
            }

        }

        //private string getHTML(string szUrl)
        //{
        //    // Create a request for the URL.
        //    WebRequest request = WebRequest.Create(szUrl);
        //    // Get the response.
        //    WebResponse response = request.GetResponse();
        //    // Get the stream containing content returned by the server.
        //    Stream dataStream = response.GetResponseStream();
        //    // Open the stream using a StreamReader for easy access.
        //    StreamReader reader = new StreamReader(dataStream);
        //    // Read the content.
        //    string responseFromServer = reader.ReadToEnd();
        //    // Close the response.
        //    response.Close();
        //    return responseFromServer;
        //}
    }
}
