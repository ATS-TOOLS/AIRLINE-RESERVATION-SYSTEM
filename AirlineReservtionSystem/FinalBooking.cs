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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AirlineReservtionSystem
{
    public partial class FinalBooking : Form
    {

        int f1 = SearchFlights.f;
        int flag = SearchFlights.flag;
        string v1 = SearchFlights.value;
        string v2 = SearchFlights.value1;
        int seats1 = SearchFlights.seats;
        string id = SearchResults.id;
        string name = SearchResults.aname;
        string dep = SearchResults.dep;
        string arr = SearchResults.arr;
        string dur = SearchResults.dur;
        int fare = SearchResults.fare;
        string uname = temp.uname;
        string src = SearchFlights.value;
        string destn = SearchFlights.value1;
        int seat = SearchFlights.seats;

        public FinalBooking()
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
                SqlCommand cmd1 = new SqlCommand("UPDATE FlightInfo SET econ_seats=econ_seats - " + seats1 + " WHERE flight_id='" + textBox1.Text + "'", conn);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("insert into book(username,flight_id,aname,src,destn,seats,fare) values('" + uname + "','" + id + "','" + name + "','" + src + "','" + destn + "',"+ seats1+ ",'"+ fare + "')", conn);
                cmd2.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE FlightInfo SET b_seats=b_seats - " + seats1 + " WHERE flight_id='" + textBox1.Text + "'", conn);
                cmd1.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("insert into book(username,flight_id,aname,src,destn,seats,fare) values('" + uname + "','" + id + "','" + name + "','" + src + "','" + destn + "'," + seats1 + ",'" + fare + "')", conn);
                cmd2.ExecuteNonQuery();
            }
            /* Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
             PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Booking.pdf", FileMode.Create));
             doc.Open();
             Paragraph p = new Paragraph("Booking Done");
             doc.Add(p);
             doc.Close();*/
            if (flag == 1)
            {
               
                MessageBox.Show("Booking Done For One Way", "Congrats");
                this.Close();
                RoundTrip rt = new RoundTrip();
                rt.ShowDialog();
                
                
            }
            else
            {
                
                MessageBox.Show("Booking Done!", "Congrats");
                this.Close();

            }
        }

        private void FinalBooking_Load(object sender, EventArgs e)
        {

            SearchResults sr = new SearchResults();
           
            textBox1.Text = id;
            textBox6.Text = name;
            textBox2.Text = dep;
            textBox3.Text = arr;
            textBox4.Text = dur;
            textBox5.Text =fare.ToString();
            textBox7.Text = seat.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
