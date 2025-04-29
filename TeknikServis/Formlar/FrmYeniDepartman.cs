using DevExpress.XtraGrid;
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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLDepartman tBL = new TBLDepartman();
            if (txtDepartmanAd.Text.Length<= 50 && txtDepartmanAd.Text != "" && txtDepartmanAciklama.Text.Length>=1)
            {
                tBL.AD = txtDepartmanAd.Text;
                tBL.ACIKLAMA = txtDepartmanAciklama.Text;
                db.TBLDepartman.Add(tBL);

                db.SaveChanges();
                MessageBox.Show("Yeni departman başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          

        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
