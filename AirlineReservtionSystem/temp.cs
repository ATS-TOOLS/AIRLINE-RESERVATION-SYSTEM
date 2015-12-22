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
    public partial class temp : Form
    {
        public static string uname,pass;
        public temp()
        {
            InitializeComponent();
        }

         private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
      
        /*    if (textBox1.Text == "admin")
            {
                if (textBox2.Text == "admin")
                {
                    AdminPage ap = new AdminPage();
                    ap.ShowDialog();
                }
                else
                {
                    
                    MessageBox.Show("Invalid Username or Password");
                }

            }
            
            
            else
            {
                uname = textBox1.Text;
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from sign_up where uname='" + textBox1.Text + "' and password='" + textBox2.Text + "' and lvl=0", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    
                    SearchFlights sf = new SearchFlights();
                    sf.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }*/
         }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();
            pass = textBox2.Text;
            uname = textBox1.Text;
            SqlDataAdapter cmd1 = new SqlDataAdapter("select count(*) from sign_up where uname='" + textBox1.Text + "' and password='" + textBox2.Text + "' and lvl=0", conn);
            //cmd1.BeginExecuteReader();
            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Close();
                SearchFlights f = new SearchFlights();
                f.Show();
            }
            else
            {
                MessageBox.Show("Invalid username and password !");
            }
        }

        private void temp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
