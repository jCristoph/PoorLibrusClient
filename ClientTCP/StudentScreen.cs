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
            table.ReadOnly = true;
            table.ColumnCount = command.Length;
            table.Columns[0].Name = "Subject";
            for (int i = 1; i < command.Length; i++) 
            {
                table.Columns[i].Name = "Grade";
            }

            var index = this.table.Rows.Add();
            int j = 0;

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i]=="~")
                {
                    index = this.table.Rows.Add();
                    j = 0;
                }
                else
                {
                    this.table.Rows[index].Cells[j].Value = command[i];
                    j++;
                }
                
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            write("CHECK");
            string[] command = checkMessage(read());
            table.ReadOnly = true;
            table.ColumnCount = command.Length;
            table.Columns[0].Name = "Subject";
            for (int i = 1; i < command.Length; i++)
            {
                table.Columns[i].Name = "Grade";
            }

            var index = this.table.Rows.Add();
            int j = 0;

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == "~")
                {
                    index = this.table.Rows.Add();
                    j = 0;
                }
                else
                {
                    this.table.Rows[index].Cells[j].Value = command[i];
                    j++;
                }

            }
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
            write("LOGOUT");
            System.Windows.Forms.Application.ExitThread();
            System.Windows.Forms.Application.Exit();
            this.Close();
            Client.Close();
        }

        private void table_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
