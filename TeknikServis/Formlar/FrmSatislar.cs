using System;
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
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            var values = from x in db.TBLUrunHareket
                         select new
                         {
                             x.HAREKETID,
                             x.TBLUrun.AD,
                             PERSONEL = x.TBLPersonel.AD + " " + x.TBLPersonel.SOYAD,                           
                             MUSTERİ = x.TBLCari.AD,
                             x.ADET,
                             x.FIYAT,
                             x.TARIH,
                             x.URUNSERINO,
                             CariBilgi = x.TBLCari.AD + " " + x.TBLCari.SOYAD
                         };
            gridControl1.DataSource = values.ToList();
        }
    }
}
