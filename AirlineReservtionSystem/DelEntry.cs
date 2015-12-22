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
    public partial class DelEntry : Form
    {
        public DelEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("select count(*) from FlightInfo where flight_id='" + textBox1.Text + "'", conn);
            SqlDataReader rd = cmd2.ExecuteReader();
            rd.Read();
            int count = Convert.ToInt32(rd[0]);
            rd.Close();
            if (count == 0)
            {
                MessageBox.Show("No Flight Found");
            }
            
            else
            {
      
                SqlCommand cmd1 = new SqlCommand("delete from FlightInfo where flight_id='" + textBox1.Text + "'", conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Done");
            }
        }
    }
}
