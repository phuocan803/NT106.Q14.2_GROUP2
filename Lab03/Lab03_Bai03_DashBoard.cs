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
    public partial class Lab03_Bai03_DashBoard : Form
    {
        public Lab03_Bai03_DashBoard()
        {
            InitializeComponent();
        }

        private void btnOpenTCPServer_Click(object sender, EventArgs e)
        {
            Lab03_Bai03_TCP_Server serverForm = new Lab03_Bai03_TCP_Server();
            serverForm.Show();
        }

        private void btnOpenTCPClient_Click(object sender, EventArgs e)
        {
            Lab03_Bai03_TCP_Client clientForm = new Lab03_Bai03_TCP_Client();
            clientForm.Show();
        }
    }
}
