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
    public partial class EditGrades : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public EditGrades(TcpClient Client)
        {
            this.Client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            write("EDIT "+textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
