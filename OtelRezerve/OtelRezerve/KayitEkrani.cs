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
    public partial class KayitEkrani : Form
    {
        public KayitEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-9IQ5NO3T\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");
        public void Odadurumu()
        {
            int sayi = 101;
            foreach (Control btn in Controls)
            {
                if (btn is Button)
                {
                    if (btn.Name != "button1" && btn.Name != "button15" && btn.Name != "button14")
                    {
                        btn.BackColor = Color.Transparent;
                        btn.Text = "ODA-" + sayi.ToString();
                        sayi++;
                    }
                }
            }
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select *from Odabilgileri", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control oda in Controls)
                {
                    if (oda is Button)
                    {
                        if (read["Oda"].ToString() == oda.Text && read["Durum"].ToString() == "Bos")
                        {
                            oda.BackColor = Color.Green;

                        }
                        if (read["Oda"].ToString() == oda.Text && read["Durum"].ToString() == "Dolu")
                        {
                            oda.BackColor = Color.Tomato;
                        }
                    }
                }

            }
            baglantı.Close();
        }
        private void KayitEkrani_Load(object sender, EventArgs e)
        {
           
    
       }

        private void Dtpcikis_ValueChanged(object sender, EventArgs e)
        {
           
                int Ucret;
                DateTime KucukTarih = Convert.ToDateTime(Dtpgiris.Text);
                DateTime BuyukTarih = Convert.ToDateTime(Dtpcikis.Text);

                TimeSpan Sonuc;
                Sonuc = BuyukTarih - KucukTarih;
                label11.Text = Sonuc.TotalDays.ToString();
                Ucret = Convert.ToInt32(label11.Text) * 50;
                TxtUcret.Text = Ucret.ToString();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("insert into MusteriEkle(Adi,Soyadi,Cinsiyet,Telefon,Mail,TC,OdaNo,Ucret,GirisTarihi,CikisTarihi)values('" + TxtAdi.Text + "','" + TxtSoyadi.Text + "','" + comboBox1.Text + "','" + MskTxtTelefon.Mask + "','" + TxtTc.Text + "','" + TxtEmail.Text + "','" + TxtOdano.Text + "','" + TxtUcret.Text + "','" + Dtpgiris.Value.ToString("yyyy-MM-dd") + "','" + Dtpcikis.Value.ToString("yyyy-MM-dd") + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Müşteri Kaydı yapıldı");
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select *from Odabilgileri where Oda like'" + comboBox2.Text + "'", baglantı);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                Txtkat.Text = read["Kat"].ToString();
                TxtYatak.Text = read["YatakSayisi"].ToString();
                TxtBanyo.Text = read["BanyoSayisi"].ToString();
                TxtCephe.Text = read["Cephe"].ToString();
                TxtDurum.Text = read["Durum"].ToString();

            }
            baglantı.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update Odabilgileri set Kat=@Kat,YatakSayisi=@YatakSayisi,BanyoSayisi=@BanyoSayisi,Cephe=@Cephe,Durum=@Durum where Oda=@Oda", baglantı);
            komut.Parameters.AddWithValue("@Oda", comboBox2.Text);
            komut.Parameters.AddWithValue("@Kat", Txtkat.Text);
            komut.Parameters.AddWithValue("@YatakSayisi", TxtYatak.Text);
            komut.Parameters.AddWithValue("@BanyoSayisi", TxtBanyo.Text);
            komut.Parameters.AddWithValue("@Cephe", TxtCephe.Text);
            komut.Parameters.AddWithValue("@Durum", TxtDurum.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Güncellendi");

        }

        private void button17_Click(object sender, EventArgs e)
        {

            Txtkat.Clear();
            TxtYatak.Clear();
            TxtBanyo.Clear();
            TxtCephe.Clear();
            TxtDurum.Clear();
        }
        private void verilergoster()
        {
            listView1.Items.Clear();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select *from Odabilgileri", baglantı);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                
                ekle.SubItems.Add(oku["Oda"].ToString());
                ekle.SubItems.Add(oku["Durum"].ToString());
                

                listView1.Items.Add(ekle);
            }
            baglantı.Close();
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilergoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select *from Odabilgileri where Durum like'%" + textBox1.Text + "%'", baglantı);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                
                ekle.SubItems.Add(oku["Oda"].ToString());
                ekle.SubItems.Add(oku["Durum"].ToString());
        

                listView1.Items.Add(ekle);
            }
            baglantı.Close();
        }
    }


}
