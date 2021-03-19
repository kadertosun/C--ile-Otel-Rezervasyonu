using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezerve
{
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (TxtKadi.Text == "admin" && TxtSifre.Text == "12345")
            {
                AdminEkrani frm = new AdminEkrani();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Kullanici adı veya Şifer Hatalı");
            }
        }
    }
}
