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
    public partial class Form_DashBoard : Form
    {
        public Form_DashBoard()
        {
            InitializeComponent();
        }

        private void Lab03_Bai01_Click(object sender, EventArgs e)
        {
            Lab03_Bai01_DashBoard form = new Lab03_Bai01_DashBoard();
            form.Show();
        }

        private void Lab03_Bai02_Click(object sender, EventArgs e)
        {
            Lab03_Bai02 form = new Lab03_Bai02();
            form.Show();
        }

        private void Lab03_Bai03_Click(object sender, EventArgs e)
        {
            Lab03_Bai03_DashBoard form = new Lab03_Bai03_DashBoard();
            form.Show();
        }

        private void Bai_Test_Click(object sender, EventArgs e)
        {
            Bai_Test_DashBoard form = new Bai_Test_DashBoard();
            form.Show();
        }
    }
}
