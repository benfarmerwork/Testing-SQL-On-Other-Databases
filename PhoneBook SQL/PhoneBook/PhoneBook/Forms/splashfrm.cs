using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class splashfrm : Form
    {
        public splashfrm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Loginfrm  frm = new Loginfrm();
            progressBar1.Visible = true;

            this.progressBar1.Value = this.progressBar1.Value + 2;
            if (this.progressBar1.Value == 10)
            {
                label3.Text = "Connect to Database...";
            }
            else if (this.progressBar1.Value == 20)
            {
                label3.Text = "Openning Database...";
            }
            else if (this.progressBar1.Value == 40)
            {
                label3.Text = "Collect files...";
            }
            else if (this.progressBar1.Value == 60)
            {
                label3.Text = "Loading files...";
            }
            else if (this.progressBar1.Value == 80)
            {
                label3.Text = "Done Loading files..";
            }
            else if (this.progressBar1.Value == 90)
            {
                label3.Text = "Openning";
            }
            else if (this.progressBar1.Value == 100)
            {
                frm.Show();
                timer1.Enabled = false;
                this.Hide();
            }
        }

        private void splashfrm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Width = this.Width;
        }
    }
}
