
namespace ClientTCP
{
    partial class ConnectScreen
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
            this.btncon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncon
            // 
            this.btncon.Location = new System.Drawing.Point(308, 226);
            this.btncon.Name = "btncon";
            this.btncon.Size = new System.Drawing.Size(178, 90);
            this.btncon.TabIndex = 0;
            this.btncon.Text = "Connect";
            this.btncon.UseVisualStyleBackColor = true;
            this.btncon.Click += new System.EventHandler(this.btncon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(734, 73);
            this.label2.TabIndex = 2;
            this.label2.Text = "Welcome to Libre Client";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(661, 55);
            this.label3.TabIndex = 3;
            this.label3.Text = "Please connect to the server";
            // 
            // ConnectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 386);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btncon);
            this.Name = "ConnectScreen";
            this.Text = "Libre Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

