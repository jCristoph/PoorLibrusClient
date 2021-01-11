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
            table.ReadOnly = true;
            table.ColumnCount = 9;
            table.Columns[0].Name = "przedmiot";
            table.Columns[1].Name = "ocena 1";
            table.Columns[2].Name = "ocena 2";
            table.Columns[3].Name = "ocena 3";
            table.Columns[4].Name = "ocena 4";
            table.Columns[5].Name = "ocena 5";
            table.Columns[6].Name = "ocena 6";
            table.Columns[7].Name = "ocena 7";
            string[] command = checkMessage(read());
            var index = this.table.Rows.Add();
            int j = 0;

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i].Length > 3)
                {
                    index = this.table.Rows.Add();
                    j = 0;
                }

                this.table.Rows[index].Cells[j].Value = command[i];
                j++;
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            write("CHECK");
            string[] command = checkMessage(read());

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
