using System;
using System.Windows.Forms;

using Server;
using ChatClient;
namespace Dashboard
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void button_Server_Click(object sender, EventArgs e)
        {
            var serverForm = new Server.Server(); 
            serverForm.Show();
        }
        private void button_Client_Click(object sender, EventArgs e)
        {
            var clientForm = new ChatClient.Client(); 
            clientForm.Show();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
