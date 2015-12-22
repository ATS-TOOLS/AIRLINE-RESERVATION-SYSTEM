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
    
    public partial class SearchFlights : Form
    {
        
        public static int f,flag, seats;
        
        public static string value, value1;
        string uname = temp.uname;
        
        public SearchFlights()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            dateTimePicker1.Visible = true;
            label5.Visible = false;
            dateTimePicker2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label5.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string key = ((KeyValuePair<string,string>)comboBox1.SelectedItem).Key;
            value = ((KeyValuePair<string,string>)comboBox1.SelectedItem).Value;
            string key1 = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Key;
            value1 = ((KeyValuePair<string, string>)comboBox2.SelectedItem).Value;
            seats = ((KeyValuePair<int, int>)comboBox3.SelectedItem).Value;
            if (key == key1)
            {
                MessageBox.Show("Departure & Arrival Cities Can't Be The Same.\nPlease Try Again!", "Error");
            }

            else
            {
                
                SearchResults sr = new SearchResults();
                sr.ShowDialog();

            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrevBooking pb = new PrevBooking();
            pb.Show();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            f = 1;

        }

        private void SearchFlights_Load(object sender, EventArgs e)
        {
            label7.Text = uname;
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
            Dictionary<int, int> comboSource1 = new Dictionary<int, int>();
            comboSource1.Add(1, 1);
            comboSource1.Add(2,2);
            comboSource1.Add(3,3);
            comboSource1.Add(4, 4);
            comboSource1.Add(5, 5);
            comboSource1.Add(6, 6);
            comboBox3.DataSource = new BindingSource(comboSource1, null);
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";
        }
    }
}
