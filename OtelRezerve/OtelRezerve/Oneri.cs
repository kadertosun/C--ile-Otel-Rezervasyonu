using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OtelRezerve
{
    public partial class Oneri : Form
    {
        public Oneri()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-9IQ5NO3T\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into Gorus(AD,Soyad,Odano,Aciklama)values('" + TxtAd.Text + "','" + TxtSoyad.Text + "','" + TxtOda.Text + "','" + TxtAciklama.Text + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Mesajınız alınmıştır teşekkür ederiz<3");

        }
    }
}
