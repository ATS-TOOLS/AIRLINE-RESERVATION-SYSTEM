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
    public partial class AdminInsert : Form
    {
        public AdminInsert()
        {
            InitializeComponent();
        }
        DataTable dbdataset;
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && textBox5.Text!="" && textBox6.Text!="" && textBox7.Text!="" && textBox8.Text!="" && textBox9.Text!="")
            {
            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();

            SqlCommand cmd3 = new SqlCommand("select count(*) from FlightInfo where flight_id= '" + this.textBox2.Text + "' ", conn);
            SqlDataReader rd = cmd3.ExecuteReader();
            rd.Read();

            int count = Convert.ToInt32(rd[0]);
            if (count == 0)
            {
                rd.Close();
                if (comboBox1.Text == comboBox2.Text)
                {
                    MessageBox.Show("Source and Destination place should not same");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("insert into FlightInfo(src,destn,Airline_name,flight_id,Arrival,Departure,Duration,econ_fare,b_fare,econ_seats,b_seats) values('" + this.comboBox1.Text + "','" + this.comboBox2.Text + "','" + this.comboBox3.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "')", conn);
                    cmd.ExecuteNonQuery();

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

                        MessageBox.Show("Data Inserted Succesfully..");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Flight Number Exist");
            }
            }
            else
            {
                MessageBox.Show("Plz Fill The All Infromatino !");
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

        private void AdminInsert_Load_1(object sender, EventArgs e)
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
            comboSource.Add("10","Ahmedabad");

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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("flight_id LIKE '%{0}%'", textBox10.Text);
            dataGridView1.DataSource = DV;
        }
    }
}

