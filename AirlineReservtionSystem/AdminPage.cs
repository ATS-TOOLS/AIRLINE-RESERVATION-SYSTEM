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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateEntry ce = new CreateEntry();
            ce.ShowDialog();
         }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DelEntry de = new DelEntry();
            de.ShowDialog();
        }
    }
}
