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
    public partial class StudentScreen : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public StudentScreen(TcpClient Client)
        {
            this.Client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void StudentScreen_Load(object sender, EventArgs e)
        {
            string[] command = checkMessage(read());

            for(int i=0; i<command.Length;i++) table.DataSource = command[i];


        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            write("CHECK");
            string[] command = checkMessage(read());
            table.Columns.Add("ID", "1");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePassword c = new changePassword(Client);
            c.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            write("LOGOUT");
            this.Hide();
            LoginScreen login = new LoginScreen(Client);
            login.ShowDialog();
        }

       #region dataTransmission
        private string read()
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

        private string[] checkMessage(string s)
        {
            return s.Split(' ');
        }
        #endregion

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Client.Close();
            System.Windows.Forms.Application.ExitThread();
            System.Windows.Forms.Application.Exit();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
