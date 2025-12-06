using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_Bai07.SignUp;

namespace Lab04_Bai07.SignIn
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void linkLabel_Sign_Up_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var signup = new Lab04_Bai07.SignUp.SignUp();
            signup.Show();
            this.Close();
        }
}
}
