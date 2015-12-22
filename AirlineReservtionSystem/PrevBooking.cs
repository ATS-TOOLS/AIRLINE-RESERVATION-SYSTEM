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
    public partial class PrevBooking : Form
    {
        int f1 = SearchFlights.f;
        int f2 = SearchFlights.flag;
        int v1,seats1;
        string fid,seats;
        string uname=temp.uname;
      
        public PrevBooking()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                fid= row.Cells[1].Value.ToString();
                seats = row.Cells[5].Value.ToString();
                seats1 = Int32.Parse(seats);

                v1 = Int32.Parse(textBox1.Text);
                
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrevBooking_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Book where username='" + uname + "'" , conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["flight_id"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["aname"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["src"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["destn"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["fare"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["seats"].ToString();
                
       
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();
            if (f1 == 0)
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE FlightInfo SET econ_seats=econ_seats + " + seats1 + " WHERE flight_id='" + fid + "'", conn);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE from Book where id= " + v1 , conn);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Kya bhai ticket cancel kar di..");
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE FlightInfo SET b_seats=b_seats + " + seats1 + " WHERE flight_id='" +fid +"'", conn);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE from FlightInfo where id= " + v1 + "'", conn);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Ticket Canceled");
            }
        }
    }
}
