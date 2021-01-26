using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTCP
{
    public partial class changePassword : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public changePassword(TcpClient Client)
        {
            this.Client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void changePassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 3 && textBox1.TextLength < 12) write("NEW_PASS " + textBox1.Text);
            else MessageBox.Show("Please, check if your password is at least 4 characters long");
            this.Hide();
        }
        private void write(string toWrite)
        {
            byte[] buffer = ASCIIEncoding.UTF8.GetBytes(toWrite);
            try
            {
                stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception e)
            {

            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
