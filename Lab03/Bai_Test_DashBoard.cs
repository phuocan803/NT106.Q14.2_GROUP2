using System;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Bai_Test_DashBoard : Form
    {
        public Bai_Test_DashBoard()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Bai_Test clientForm = new Bai_Test();
            clientForm.Show();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Bai_Test_Server serverForm = new Bai_Test_Server();
            serverForm.Show();
        }
    }
}
