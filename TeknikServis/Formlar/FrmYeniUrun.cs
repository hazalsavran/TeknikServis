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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            TBLUrun tBLUrun = new TBLUrun();
            tBLUrun.AD = txtUrunAd.Text;
            tBLUrun.MARKA = txtMarka.Text;
            tBLUrun.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            tBLUrun.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            tBLUrun.STOK = short.Parse(txtStok.Text);
            tBLUrun.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBLUrun.Add(tBLUrun);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKategori
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.ValueMember = "ID";
        }
    }
}
