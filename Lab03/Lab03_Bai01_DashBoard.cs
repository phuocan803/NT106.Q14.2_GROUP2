using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Lab03_Bai01_DashBoard : Form
    {
        public Lab03_Bai01_DashBoard()
        {
            InitializeComponent();
        }

        private void btnUDPServer_Click(object sender, EventArgs e)
        {
            Lab03_Bai01_UDP_Server serverForm = new Lab03_Bai01_UDP_Server();
            serverForm.Show();
        }

        private void btnUDPClient_Click(object sender, EventArgs e)
        {
            Lab03_Bai01_UDP_Client clientForm = new Lab03_Bai01_UDP_Client();
            clientForm.Show();
        }
    }
}
