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
    public partial class AdminDelete : Form
    {
        public AdminDelete()
        {
            InitializeComponent();
        }
        DataTable dbdataset;
       

        private void AdminDelete_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();

            SqlCommand cmd2 = new SqlCommand("select * from FlightInfo", conn);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd2;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;

            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }
        
        
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox11.Text = row.Cells["src"].Value.ToString();
                textBox12.Text = row.Cells["destn"].Value.ToString();
                textBox1.Text = row.Cells["Airline_name"].Value.ToString();
                textBox2.Text = row.Cells["flight_id"].Value.ToString();
                textBox4.Text = row.Cells["Departure"].Value.ToString();
                textBox3.Text = row.Cells["Arrival"].Value.ToString();
                textBox5.Text = row.Cells["Duration"].Value.ToString();
                textBox6.Text = row.Cells["econ_fare"].Value.ToString();
                textBox7.Text = row.Cells["b_fare"].Value.ToString();
                textBox8.Text = row.Cells["econ_seats"].Value.ToString();
                textBox9.Text = row.Cells["b_seats"].Value.ToString();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();



            SqlCommand cmd2 = new SqlCommand("select * from FlightInfo", conn);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd2;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;

            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("flight_id LIKE '%{0}%'", textBox10.Text);
            dataGridView1.DataSource = DV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
                conn.Open();

                SqlCommand cmd1 = new SqlCommand("delete from FlightInfo where flight_id='" + textBox2.Text + "'", conn);
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Data Deleted Succesfully..");
            }
            else
            {
                MessageBox.Show("Select the Flight From Above List");
            }
        }
    }
}
