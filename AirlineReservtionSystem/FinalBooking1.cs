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
    public partial class FinalBooking1 : Form
    {
        int f1 = SearchFlights.f;
        int flag = SearchFlights.flag;
        string v1 = SearchFlights.value;
        string v2 = SearchFlights.value1;
        int seats1 = SearchFlights.seats;
        string id = RoundTrip.id1;
        string name = RoundTrip.aname;
        string dep = RoundTrip.dep;
        string arr = RoundTrip.arr;
        string dur = RoundTrip.dur;
        int fare = RoundTrip.fare;
        string uname = temp.uname;
        string src = SearchFlights.value;
        string destn =SearchFlights.value1;

        public FinalBooking1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server= AAKASH-PC\\SQLEXPRESS; initial catalog= ars ; integrated security= true");
            conn.Open();
            
            // MessageBox.Show(textBox1.Text);
            if (f1 == 0)
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE FlightInfo SET econ_seats=econ_seats - " + seats1 + " WHERE flight_id='" + id + "'", conn);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("insert into book(username,flight_id,aname,src,destn,seats,fare) values('" + uname + "','" + id + "','" + name + "','" + destn + "','" + src + "'," + seats1 + ",'" + fare + "')", conn);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE FlightInfo SET b_seats=b_seats - " + seats1 + " WHERE flight_id='" + textBox1.Text + "'", conn);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("insert into book(username,flight_id,aname,src,destn,seats,fare) values('" + uname + "','" + id + "','" + name + "','" + destn + "','" + src + "'," + seats1 + ",'" + fare + "')", conn);
                cmd2.ExecuteNonQuery();
            }
            /* Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
             PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Booking.pdf", FileMode.Create));
             doc.Open();
             Paragraph p = new Paragraph("Booking Done");
             doc.Add(p);
             doc.Close();*/
            
            MessageBox.Show("Done");
            this.Close();
           
        }

        private void FinalBooking1_Load(object sender, EventArgs e)
        {
            textBox1.Text = id;
            textBox6.Text = name;
            textBox2.Text = dep;
            textBox3.Text = arr;
            textBox4.Text = dur;
            textBox5.Text = fare.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
