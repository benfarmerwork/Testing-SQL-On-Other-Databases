using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class phonebookfrm : Form
    {
        MySqlConnection connect = new MySqlConnection("SERVER=localhost; USERID=root; PASSWORD=; DATABASE=phonebook;");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();

        int i;
        public phonebookfrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO phonebook(FirstName,LastName,Gender,Number)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "')";
            i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show(textBox1.Text+" has been save in the system ");
                clear();
            }
            connect.Close();
            showdata();

        }
        void showdata()
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT*FROM phonebook";
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            dg1.DataSource = dt;
            connect.Close();

        }
        void clear()
        {

            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = 0;
            textBox3.Clear();
            textBox1.Focus();

        }

        private void phonebookfrm_Load(object sender, EventArgs e)
        {
            dg1.RowTemplate.Height = 20;
            showdata();
             Timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATE phonebook SET FirstName='" + textBox1.Text + "',LastName='" + textBox2.Text + "',Gender='" + comboBox1.Text + "',Number='" + textBox3.Text + "'WHERE id=" + dg1.SelectedRows[0].Cells[0].Value;
            i = cmd.ExecuteNonQuery();
            if (i > 0)
            {

                MessageBox.Show(dg1.SelectedRows[0].Cells[1].Value+" has been updated successfully ");
                clear();
            }
            connect.Close();
            showdata();
        }

        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dg1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dg1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dg1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dg1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT*FROM phonebook WHERE FirstName like'%" + textBox1.Text + "%'";
            da.SelectCommand = cmd;
            dt.Clear();
            da.Fill(dt);
            dg1.DataSource = dt;
            connect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to delete " + dg1.SelectedRows[0].Cells[1].Value + " from the system?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes)
            {
                try
                {
                    connect.Open();
                    cmd.Connection = connect;
                    cmd.CommandText = "DELETE FROM phonebook WHERE id=" + dg1.SelectedRows[0].Cells[0].Value;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {

                        MessageBox.Show("You have deleted " + i + dg1.SelectedRows[0].Cells[1].Value + MessageBoxIcon.Information);
                        clear();
                    }
                    connect.Close();
                    showdata();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show(dg1.SelectedRows[0].Cells[1].Value+" is not deleted from the system ");

            }
        }


        private void  Timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = "Time : "+DateTime.Now.ToString("HH:mm:ss");
            Date.Text = "Date : " + DateTime.Now.ToString("dd/MM/yy");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            aboutfrm frm = new aboutfrm();
            frm.Show();
        }  

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            contactfrm frm = new contactfrm();
            frm.Show();
        }
    }
}

