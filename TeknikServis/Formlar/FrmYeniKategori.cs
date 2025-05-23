﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            TBLKategori tBLKategori = new TBLKategori();
            tBLKategori.AD = txtKategoriAd.Text;
            db.TBLKategori.Add(tBLKategori);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
