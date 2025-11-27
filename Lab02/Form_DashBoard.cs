using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab02_Bai6;

namespace NT106_Lab02
{
    public partial class Form_DashBoard : Form
    {
        public Form_DashBoard()
        {
            InitializeComponent();
        }

        private void Form_DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void Button_Lab02_Bai01_Click(object sender, EventArgs e)
        {
            Lab02_Bai01 form = new Lab02_Bai01();
            form.Show();
        }

        private void Button_Lab01_Bai02_Click(object sender, EventArgs e)
        {
            Lab02_Bai02 form = new Lab02_Bai02();
            form.Show();
        }



        private void Button_Lab02_Bai03_Click(object sender, EventArgs e)
        {
            Lab02_Bai03 form = new Lab02_Bai03();
            form.Show();
        }

        private void Button_Lab02_Bai04_Click(object sender, EventArgs e)
        {
         Lab02_Bai04 form = new Lab02_Bai04();
         form.Show();
        }

        private void Button_Lab02_Bai05_Click(object sender, EventArgs e)
        {
            Lab02_Bai05 form = new Lab02_Bai05();
            form.Show();
        }

        private void Button_Lab02_Bai06_Click(object sender, EventArgs e)
        {
            Bai06 form = new Bai06();
            form.Show();
        }

        private void Button_Lab01_Bai07_Click(object sender, EventArgs e)
        {
            Lab02_Bai07 form = new Lab02_Bai07();
            form.Show();
        }
   
    }
}
