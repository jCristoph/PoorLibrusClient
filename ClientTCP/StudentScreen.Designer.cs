﻿
namespace ClientTCP
{
    partial class StudentScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_chngPsswd = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.RichTextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(539, 390);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(125, 45);
            this.btn_logout.TabIndex = 9;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_chngPsswd
            // 
            this.btn_chngPsswd.Location = new System.Drawing.Point(408, 390);
            this.btn_chngPsswd.Name = "btn_chngPsswd";
            this.btn_chngPsswd.Size = new System.Drawing.Size(125, 45);
            this.btn_chngPsswd.TabIndex = 8;
            this.btn_chngPsswd.Text = "Change Password";
            this.btn_chngPsswd.UseVisualStyleBackColor = true;
            this.btn_chngPsswd.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(137, 58);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(496, 254);
            this.txt1.TabIndex = 7;
            this.txt1.Text = "";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(137, 318);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(96, 41);
            this.btn_refresh.TabIndex = 10;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.button3_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(670, 390);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(125, 45);
            this.exit.TabIndex = 11;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // StudentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_chngPsswd);
            this.Controls.Add(this.txt1);
            this.Name = "StudentScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StudentScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_chngPsswd;
        private System.Windows.Forms.RichTextBox txt1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button exit;
    }
}