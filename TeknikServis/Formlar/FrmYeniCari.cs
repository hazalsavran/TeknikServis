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
    public partial class FrmYeniCari : Form
    {
        public FrmYeniCari()
        {
            InitializeComponent();
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLCari tBL = new TBLCari();
            tBL.AD = txtAd.Text;
            tBL.SOYAD = txtSoyad.Text;
            tBL.TELEFON = txtTelefon.Text;
            tBL.IL = txtIl.Text;
            tBL.ILCE = txtIlce.Text;
            tBL.MAIL = txtMail.Text;
            tBL.ADRES = TxtAdress.Text;
            tBL.VERGIDAIRESI = txtVergiDairesi.Text;
            tBL.VERGINO = txtVergiNo.Text;
            db.TBLCari.Add(tBL);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
