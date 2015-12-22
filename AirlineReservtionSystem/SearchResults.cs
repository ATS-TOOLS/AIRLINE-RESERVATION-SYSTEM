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
    public partial class SearchResults : Form
    {
        int flag=SearchFlights.flag;
        int f1 = SearchFlights.f;
        string v1 = SearchFlights.value;
        string v2 = SearchFlights.value1;
        int seats1 = SearchFlights.seats;
        public static int fare;
        public static string id,aname,dep,arr,dur;
      
        public SearchResults()
        {
            InitializeComponent();
        }

        private void SearchResults_Load(object sender, EventArgs e)
        {
            label2.Text = v1;
            label4.Text = v2;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from FlightInfo where src='"+v1+"' and destn='"+v2+"'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["flight_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Airline_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Departure"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Arrival"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["Duration"].ToString();
                if (f1 == 0)
                {
                    dataGridView1.Rows[n].Cells[5].Value = item["econ_fare"].ToString();
                }
                else
                {
                    dataGridView1.Rows[n].Cells[5].Value = item["b_fare"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FinalBooking fb = new FinalBooking();
            fb.ShowDialog();
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                id = textBox1.Text;
                aname = textBox2.Text;
                dep = textBox3.Text;
                arr = textBox4.Text;
                dur = textBox5.Text;
                fare =(Int32.Parse(textBox6.Text)*seats1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
