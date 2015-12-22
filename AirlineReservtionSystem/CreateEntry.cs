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
    public partial class CreateEntry : Form
    {
        public CreateEntry()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();

            string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
            string key1 = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;
            string value1 = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Value;
            string key2 = ((KeyValuePair<string, string>)comboBox3.SelectedItem).Key;
            string value2 = ((KeyValuePair<string, string>)comboBox3.SelectedItem).Value;
            SqlCommand cmd2 = new SqlCommand("select count(*) from FlightInfo where flight_id='" + textBox1.Text + "'", conn);
            SqlDataReader rd = cmd2.ExecuteReader();
            rd.Read();
            int count = Convert.ToInt32(rd[0]);
            if (count == 0)
            {
                rd.Close();
                if (key == key1)
                {
                    
                    MessageBox.Show("Departure & Arrival Cities Can't Be The Same.\nPlease Try Again!", "Error");
                    
                }
                else
                {
                                     
                    SqlCommand cmd1 = new SqlCommand("insert into FlightInfo(flight_id,Airline_name,src,destn,Departure,Arrival,Duration,econ_fare,econ_seats,b_fare,b_seats) values('" + textBox1.Text + "','" + value2 + "','" + value + "','" + value1 + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox5.Text + "'," + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + ")", conn);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Done");
                }
            }

            else
            {
                MessageBox.Show("Flight Already Exists");
            }
        }




        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateEntry_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("1", "Mumbai");
            comboSource.Add("2", "New Delhi");
            comboSource.Add("3", "Ahmedabad");
            comboSource.Add("4", "Bangalore");
            comboSource.Add("5", "Nagpur");
            comboSource.Add("6", "Chennai");
            comboSource.Add("7", "Goa");
            comboSource.Add("8", "Amritsar");
            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox2.DataSource = new BindingSource(comboSource, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";
            Dictionary<string, string> comboSource1 = new Dictionary<string, string>();
            comboSource1.Add("1", "GoAir");
            comboSource1.Add("2", "Indigo");
            comboSource1.Add("3", "SpiceJet");
            comboSource1.Add("4", "AirIndia");
            comboSource1.Add("5", "JetAirways");
            comboSource1.Add("6", "Air Asia");
            comboBox3.DataSource = new BindingSource(comboSource1, null);
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
    
    

