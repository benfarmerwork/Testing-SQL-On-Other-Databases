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
    public partial class contactfrm : Form
    {
        public contactfrm()
        {
            InitializeComponent();
        }

        private void contactfrm_Load(object sender, EventArgs e)
        {
            lbldescription.Text = Convert.ToString("If you need any help for your small project, like homework, exercises, or anything related with C#. Please contact me on Email or on Facebook.");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            phonebookfrm frm = new phonebookfrm();
            frm.Show();
        }

        private void contactfrm_Load_1(object sender, EventArgs e)
        {
            lbldescription.Text = Convert.ToString("If you need any help for your small project, like homework, exercises, or anything related with C#. Please contact me on Email or on Facebook.");
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string webAddress = "http://www.facebook.com/mzwenhlanhla.dlamini";

                System.Diagnostics.Process.Start(webAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
