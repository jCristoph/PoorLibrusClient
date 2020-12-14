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
    public partial class LoginScreen : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public LoginScreen(TcpClient Client)
        {
            this.Client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            write("Login " + textBox1.Text + " " + textBox2.Text);


            string[] command = checkMessage(read());
                switch (command[0])
                {
                    case "s":
                        this.Hide();
                        StudentScreen student = new StudentScreen(Client);
                        student.ShowDialog();
                        break;
                    case "t":
                        this.Hide();
                        TeacherScreen teacher = new TeacherScreen(Client);
                        teacher.ShowDialog();
                        break;
                    case "a":
                        this.Hide();
                        AdminScreen admin = new AdminScreen(Client);
                        admin.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("Wrong login or password. Try again");
                        break;

            }
        }
        public string read()
        {
            byte[] buffer = new byte[1024];
            try
            {
                int message_size = stream.Read(buffer, 0, 1024);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            string s = System.Text.Encoding.UTF8.GetString(buffer);
            s = s.Replace("\0", "");
            return s;
        }

        public void write(string toWrite)
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

        public string[] checkMessage(string s)
        {
            return s.Split(' ');
        }
    }
}
