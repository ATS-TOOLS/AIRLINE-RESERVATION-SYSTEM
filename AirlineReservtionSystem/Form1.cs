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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin_login a = new Admin_login();
            a.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temp t = new temp();
            t.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            signup s = new signup();
            s.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
