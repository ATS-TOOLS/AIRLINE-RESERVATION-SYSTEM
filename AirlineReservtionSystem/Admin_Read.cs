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
    public partial class Admin_Read : Form
    {
        public Admin_Read()
        {
            InitializeComponent();
        }
        DataTable dbdataset;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Read_Load(object sender, EventArgs e)
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
    }
}
