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
    public partial class FrmYeniFatura : Form
    {
        public FrmYeniFatura()
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
            TBLFaturaBilgi tBLFaturaBilgi = new TBLFaturaBilgi();
            tBLFaturaBilgi.SERI = txtSeriNo.Text;
            tBLFaturaBilgi.SIRANO = txtSıraNo.Text;
            tBLFaturaBilgi.TARIH = DateTime.Parse(txtTarih.Text);
            tBLFaturaBilgi.VERGIDAIRE = txtVergiDaire.Text;
            tBLFaturaBilgi.CARI = int.Parse(txtCari.EditValue.ToString());
            tBLFaturaBilgi.PERSONEL = short.Parse(txtPersonel.EditValue.ToString()); 
            db.TBLFaturaBilgi.Add(tBLFaturaBilgi);
            db.SaveChanges();
            MessageBox.Show("Fatura başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmYeniFatura_Load(object sender, EventArgs e)
        {
           
            txtCari.Properties.DataSource = (from x in db.TBLCari.ToList()
                                             select new
                                             {
                                                 x.ID,
                                                 x.AD,
                                                 x.SOYAD
                                             }).ToList();
            txtCari.Properties.DisplayMember = "AD";
            txtCari.Properties.ValueMember = "ID";
            txtPersonel.Properties.DataSource = (from x in db.TBLPersonel.ToList()
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                     x.SOYAD
                                                 }).ToList();
            txtPersonel.Properties.DisplayMember = "AD";
            txtPersonel.Properties.ValueMember = "ID";

        }
    }
}
