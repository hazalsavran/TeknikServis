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
    public partial class FmFaturaKalem : Form
    {
        public FmFaturaKalem()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FmFaturaKalem_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLFaturaDetay
                                       select new
                                       {
                                           x.FATURADETAYID,
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR,
                                           x.FATURAID
                                       }).ToList();
            
          

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtFaturaDetayId.Text = gridView1.GetFocusedRowCellValue("FATURADETAYID").ToString();
            txtUrun.Text = gridView1.GetFocusedRowCellValue("URUN").ToString();
            txtAdet.Text = gridView1.GetFocusedRowCellValue("ADET").ToString();
            txtFiyat.Text = gridView1.GetFocusedRowCellValue("FIYAT").ToString();
            txtTutar.Text = gridView1.GetFocusedRowCellValue("TUTAR").ToString();
            txtFaturaID.Text = gridView1.GetFocusedRowCellValue("FATURAID").ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtFaturaDetayId.Text);
            var x = db.TBLFaturaDetay.Find(id);
            db.TBLFaturaDetay.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalemi Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtFaturaDetayId.Text);
            var x = db.TBLFaturaDetay.Find(id);
            x.URUN = txtUrun.Text;
            x.ADET = short.Parse(txtAdet.Text);
            x.FIYAT = decimal.Parse(txtFiyat.Text);
            x.TUTAR = decimal.Parse(txtTutar.Text);
            x.FATURAID = int.Parse(txtFaturaID.Text);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalemi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = (from y in db.TBLFaturaDetay
                          select new
                          {
                              y.FATURADETAYID,
                              y.URUN,
                              y.ADET,
                              y.FIYAT,
                              y.TUTAR,
                              y.FATURAID
                          }).ToList();
            gridControl1.DataSource = values;


        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLFaturaDetay
                                       select new
                                       {
                                           x.FATURADETAYID,
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR,
                                           x.FATURAID
                                       }).ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TBLFaturaDetay t = new TBLFaturaDetay();
            t.URUN = txtUrun.Text;
            t.ADET = short.Parse(txtAdet.Text);
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.TUTAR = decimal.Parse(txtTutar.Text);
            t.FATURAID = int.Parse(txtFaturaID.Text);
            db.TBLFaturaDetay.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Kalemi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = (from y in db.TBLFaturaDetay
                          select new
                          {
                              y.FATURADETAYID,
                              y.URUN,
                              y.ADET,
                              y.FIYAT,
                              y.TUTAR,
                              y.FATURAID
                          }).ToList();
            gridControl1.DataSource = values;

        }
    }
}
