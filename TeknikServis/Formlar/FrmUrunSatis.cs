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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            TBLUrunHareket tBLUrunHareket = new TBLUrunHareket();
            tBLUrunHareket.ADET = short.Parse(txtAdet.Text);
            tBLUrunHareket.FIYAT = decimal.Parse(txtsatisFiyati.Text);
            tBLUrunHareket.TARIH = DateTime.Parse(dateEdit1.Text);
            tBLUrunHareket.URUN = int.Parse(txtId.Text);
            tBLUrunHareket.URUNSERINO = txtSeriNo.Text;
            tBLUrunHareket.MUSTERI = int.Parse(txtMusteri.Text);
            tBLUrunHareket.PERSONEL = short.Parse(txtPersonel.Text);
            db.TBLUrunHareket.Add(tBLUrunHareket);
            var urun = db.TBLUrun.Find(tBLUrunHareket.URUN);
            urun.STOK -= tBLUrunHareket.ADET;
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
