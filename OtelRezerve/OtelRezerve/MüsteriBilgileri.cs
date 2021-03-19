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
    public partial class MüsteriBilgileri : Form
    {
        public MüsteriBilgileri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-9IQ5NO3T\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");

        private void verilergoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNO"].ToString());
                ekle.SubItems.Add(oku["ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void BtnVeriler_Click(object sender, EventArgs e)
        {
            verilergoster();
        }

        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            MskTxtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtEmail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtTc.Text = listView1.SelectedItems[0].SubItems[6].Text;
            TxtOdano.Text = listView1.SelectedItems[0].SubItems[7].Text;
            TxtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
            Dtpgiris.Text = listView1.SelectedItems[0].SubItems[9].Text;
            Dtpcikis.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update MusteriEkle set Adi='" + TxtAdi.Text + "',Soyadi='" + TxtSoyadi.Text + "',Cinsiyet='" + comboBox1.Text + "',Telefon='" + MskTxtTelefon.Text + "',Mail='" + TxtEmail.Text + "',TC='" + TxtTc.Text + "',OdaNo='" + TxtOdano.Text + "',Ucret='" + TxtUcret.Text + "',GirisTarihi='" + Dtpgiris.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + Dtpcikis.Value.ToString("yyyy-MM-dd") + "' where Musteriid=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilergoster();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            SqlCommand komut = new SqlCommand("delete from MusteriEkle where Musteriid=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilergoster();
        }

  

        private void button1_Click_1(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            comboBox1.Text = "";
            MskTxtTelefon.Clear();
            TxtEmail.Text = "";
            TxtTc.Clear();
            TxtOdano.Clear();
            TxtUcret.Clear();
            Dtpgiris.Text = "";
            Dtpcikis.Text = "";

        }

       

        private void BtnAra_Click(object sender, EventArgs e)
        {
            Gelismisarama frm = new Gelismisarama();
            frm.Show();
        }
    }
}
