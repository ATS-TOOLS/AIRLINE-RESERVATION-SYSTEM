using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservtionSystem
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminInsert ai = new AdminInsert();
            ai.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AdminUpdate au = new AdminUpdate();
            au.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminDelete ad = new AdminDelete();
            ad.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Read ar = new Admin_Read();
            ar.ShowDialog();
        }
    }
}
