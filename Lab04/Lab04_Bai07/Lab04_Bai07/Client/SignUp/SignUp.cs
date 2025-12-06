using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_Bai07.SignIn;

namespace Lab04_Bai07.SignUp
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void linkLabel_Sign_In_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var signin = new Lab04_Bai07.SignIn.SignIn();
            signin.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
