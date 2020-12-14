using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTCP
{
    public partial class ConnectScreen : Form
    {
        TcpClient Client;
        public ConnectScreen()
        {
            InitializeComponent();
        }
        private void conToServer()
        {
            try
            {
                Client = new TcpClient();

                Client.Connect("127.0.0.1", 2048);

                if (Client.Connected)
                {
                    this.Hide();
                    LoginScreen form2 = new LoginScreen(Client);
                    form2.ShowDialog();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Couldn't connect to the server. Please try again.");
            }
        }

private void btncon_Click(object sender, EventArgs e)
        {
            conToServer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
