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
    public partial class AddUser : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public AddUser(TcpClient Client)
        {
            this.Client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt1.TextLength > 0 && txt2.TextLength > 0 && txt3.TextLength > 0 && txt4.TextLength > 0 && txt5.TextLength > 0 && txt6.TextLength > 0)
            {
                write("ADDUSER " + txt1.Text + " " + txt2.Text + " " + txt3.Text + " " + txt4.Text + " " + txt5.Text + " " + txt6.Text);
                MessageBox.Show("New user has been created");
            }
            else MessageBox.Show("Wrong data, try again");
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

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
