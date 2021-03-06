﻿using System;
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
    public partial class AdminScreen : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public AdminScreen(TcpClient Client)
        {
            this.Client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        #region dataTransmission
        
        private string read(int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            try
            {
                int message_size = stream.Read(buffer, 0, bufferSize);
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

        private void button2_Click(object sender, EventArgs e)
        {
            write("LOGOUT");
            this.Hide();
            LoginScreen login = new LoginScreen(Client);
            login.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            write("LOGOUT");
            System.Windows.Forms.Application.ExitThread();
            System.Windows.Forms.Application.Exit();
            this.Close();
            Client.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            write("NEW_PASS");
            changePassword c = new changePassword(Client);
            c.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditGrades edit = new EditGrades(Client);
            edit.ShowDialog();
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            write("USERS");
            int bufferSize = Convert.ToInt32(read(1024)) * 256;
            write("USERLIST");
            string[] command = checkMessage(read(bufferSize));
            table.ColumnCount = 27;
            table.Columns[0].Name = "Login";
            table.Columns[1].Name = "Password";
            table.Columns[2].Name = "Index";
            table.Columns[3].Name = "Name";
            table.Columns[4].Name = "Second Name";
            table.Columns[5].Name = "Subject";
            table.Columns[6].Name = "User Type";
            for(int c = 7;c<27;c++)
            {
                table.Columns[c].Name = "grade";
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

        private void button4_Click(object sender, EventArgs e)
        {
            AddUser addu = new AddUser(Client);
            addu.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveUser remu = new RemoveUser(Client);
            remu.ShowDialog();
        }

        private void AdminScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
