﻿using System;
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
    public partial class AdminEkrani : Form
    {
        public AdminEkrani()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitEkrani frm = new KayitEkrani();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Musterimesajlari frm = new Musterimesajlari();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MüsteriBilgileri frm = new MüsteriBilgileri();
            frm.Show();
        }
    }
}
