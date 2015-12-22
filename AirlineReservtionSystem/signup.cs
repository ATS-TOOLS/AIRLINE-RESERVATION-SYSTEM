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
    public partial class signup : Form
    {
     
        public signup()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from sign_up where uname='" + textBox1.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Username Already Exists!", "Error");
                }
                else
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        SqlCommand cmd1 = new SqlCommand("insert into sign_up(uname,password,emailid,mno,lvl) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "',0)", conn);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Account Created Successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Verify Your Password");
                    }

                }
            }
            else 
            {
                MessageBox.Show("Plz Fill The All Information !");
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
