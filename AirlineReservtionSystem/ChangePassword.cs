using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AirlineReservtionSystem
{
    
    public partial class ChangePassword : Form
    {
        string pass = temp.pass;
        string uname = temp.uname;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();

            if (textBox4.Text == pass)
            {
                if(textBox2.Text == textBox3.Text)
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE sign_up SET password='" + textBox3.Text + "' WHERE uname='" + textBox1.Text + "'", conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Password Changed");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Verify Your New Password!");
                }
            }
            else
            {
                MessageBox.Show("Please Verify Your Current Password!");
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            textBox1.Text = uname;
        }
    }
}
