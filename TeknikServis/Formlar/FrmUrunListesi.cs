using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void UrunListele()
        {
            var values = from u in db.TBLUrun
                         select new
                         {
                             u.ID,
                             u.AD,
                             u.MARKA,
                             u.ALISFIYAT,
                             u.SATISFIYAT,
                             u.STOK,
                             KATEGORI = u.TBLKategori.AD
                         };
            gridControl1.DataSource = values.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            UrunListele();
            txtKategori.Properties.DataSource = (from x in db.TBLKategori.ToList()
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
            txtKategori.Properties.DisplayMember = "AD";
            txtKategori.Properties.ValueMember = "ID";


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLUrun tBLUrun = new TBLUrun();
            tBLUrun.AD = txtUrunAd.Text;
            tBLUrun.MARKA = txtMarka.Text;
            tBLUrun.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            tBLUrun.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            tBLUrun.STOK = short.Parse(txtStok.Text);
            tBLUrun.KATEGORI = byte.Parse(txtKategori.EditValue.ToString());
            tBLUrun.DURUM = false;
            db.TBLUrun.Add(tBLUrun);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            UrunListele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            txtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            txtKategori.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = db.TBLUrun.Find(id);
            db.TBLUrun.Remove(values);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            var values2 = db.TBLUrun.ToList();
            gridControl1.DataSource = values2;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
           
            var tBLUrun = db.TBLUrun.Find(id);
            tBLUrun.AD = txtUrunAd.Text;
            tBLUrun.MARKA = txtMarka.Text;
            tBLUrun.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            tBLUrun.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            tBLUrun.STOK = short.Parse(txtStok.Text);
            tBLUrun.KATEGORI = byte.Parse(txtKategori.EditValue.ToString());
            db.TBLUrun.AddOrUpdate(tBLUrun);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values2 = db.TBLUrun.ToList();
            gridControl1.DataSource = values2;
        }
    }
}
