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
    public partial class RemoveUser : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public RemoveUser(TcpClient Client)
        {
            this.Client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            write("REMOVE" + textBox4.Text);
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
    }
}
