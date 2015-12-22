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
    public partial class AdminUpdate : Form
    {
        public AdminUpdate()
        {
            InitializeComponent();
        }
        DataTable dbdataset;
    
   
        private void AdminUpdate_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("1", "Bangalore");
            comboSource.Add("2", "Mumbai");
            comboSource.Add("3", "Kolkata");
            comboSource.Add("4", "New Delhi");
            comboSource.Add("5", "Goa");
            comboSource.Add("6", "Chennai");
            comboSource.Add("7", "Nagpur");
            comboSource.Add("8", "Pune");
            comboSource.Add("9", "Amritsar");
            comboSource.Add("10", "Ahmedabad");

            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox2.DataSource = new BindingSource(comboSource, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";

            Dictionary<string, string> comboair = new Dictionary<string, string>();

            comboair.Add("1", "GoAir");
            comboair.Add("2", "AirAsia");
            comboair.Add("3", "Indigo");
            comboair.Add("4", "SpiceJet");
            comboair.Add("5", "AirIndia");
            comboair.Add("6", "JetAirways");
            comboair.Add("7", "Vistara");


            comboBox3.DataSource = new BindingSource(comboair, null);
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";
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
        

       

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("flight_id LIKE '%{0}%'", textBox10.Text);
            dataGridView1.DataSource = DV;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                comboBox1.Text = row.Cells["src"].Value.ToString();
                comboBox2.Text = row.Cells["destn"].Value.ToString();
                comboBox3.Text = row.Cells["Airline_name"].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                if (comboBox1.Text != comboBox2.Text)
                {
                    SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
                    conn.Open();

                    SqlCommand cmd1 = new SqlCommand("update FlightInfo set src='" + comboBox1.Text + "',destn='" + comboBox2.Text + "',Airline_name='" + comboBox3.Text + "',flight_id='" + textBox2.Text + "',Departure='" + textBox4.Text + "',Arrival='" + textBox3.Text + "',Duration='" + textBox5.Text + "',econ_fare='" + textBox6.Text + "',b_fare='" + textBox7.Text + "',econ_seats='" + textBox8.Text + "',b_seats='" + textBox9.Text + "' where flight_id='" + textBox2.Text + "'", conn);
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Updated Successfully!!","Congrats");
                }
                else
                {
                    MessageBox.Show("Departure & Arrival Cities Can't Be The Same.\nPlease Try Again!", "Error");
                }
            }
            else
            {
                MessageBox.Show("Plz Select The Flight From Above List","Error");
            }
        }
    }
}
