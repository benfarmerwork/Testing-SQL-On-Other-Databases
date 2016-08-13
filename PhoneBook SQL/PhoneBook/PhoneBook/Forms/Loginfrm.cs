using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Loginfrm : Form
    {
        MySqlConnection connect = new MySqlConnection("SERVER=localhost; USERID=root; PASSWORD=; DATABASE=phonebook;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();

        public Loginfrm()
        {
            InitializeComponent();
        }

        //exit application
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //loging button
        private void button1_Click(object sender, EventArgs e)
        {
            if (usernametxt.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernametxt.Focus();
                return;
            }
            if (passwordtxt.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordtxt.Focus();
                return;
            }
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "SELECT*FROM user WHERE username='" + usernametxt.Text + "' and password='" + passwordtxt.Text + "'";
                da.SelectCommand = cmd;
                MySqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Login Succeed!", "Succeed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    phonebookfrm frm = new phonebookfrm();
                    frm.User.Text = usernametxt.Text;
                    frm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }

                connect.Close();
            }
                catch (Exception ex)
                 {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
        }

        //clear
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {

            usernametxt.Clear();
            passwordtxt.Clear();
        
        }
    }
}
