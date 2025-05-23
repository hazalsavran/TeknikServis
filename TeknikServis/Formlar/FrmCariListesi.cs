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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLCari
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.SOYAD,
                                           x.TELEFON,
                                           x.MAIL,
                                           x.ADRES,
                                           x.VERGIDAIRESI,
                                           x.VERGINO
                                       }).ToList();

        }
    }
}
