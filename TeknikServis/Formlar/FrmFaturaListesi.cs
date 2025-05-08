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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void FaturaListele()
        {
            gridControl1.DataSource = (from x in db.TBLFaturaBilgi
                                       select new
                                       {
                                           x.ID,
                                           x.SERI,
                                           x.SIRANO,
                                           x.TARIH,
                                           x.VERGIDAIRE,
                                           CARI = x.TBLCari.AD + " " + x.TBLCari.SOYAD,
                                           PERSONEL = x.TBLPersonel.AD + " " + x.TBLPersonel.SOYAD,


                                       }).ToList();

        }
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
           FaturaListele();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = db.TBLFaturaBilgi.Find(id);
            db.TBLFaturaBilgi.Remove(values);
            db.SaveChanges();
            MessageBox.Show("Fatura Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            var values2 = db.TBLFaturaBilgi.ToList();
            gridControl1.DataSource = values2;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtSeriNo.Text = gridView1.GetFocusedRowCellValue("SERI").ToString();
            txtSiraNo.Text = gridView1.GetFocusedRowCellValue("SIRANO").ToString();
            txtTarih.Text = gridView1.GetFocusedRowCellValue("TARIH").ToString();
            txtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRE").ToString();
            txtCari.Text = gridView1.GetFocusedRowCellValue("CARI").ToString();
            txtPersonel.Text = gridView1.GetFocusedRowCellValue("PERSONEL").ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = db.TBLFaturaBilgi.Find(id);
            values.SERI = txtSeriNo.Text;
            values.SIRANO = txtSiraNo.Text;
            values.TARIH = DateTime.Parse(txtTarih.Text);
            values.VERGIDAIRE = txtVergiDairesi.Text;
            values.CARI = int.Parse(txtCari.Text);
            values.PERSONEL = short.Parse(txtPersonel.Text);
            db.TBLFaturaBilgi.AddOrUpdate(values);
            db.SaveChanges();
            MessageBox.Show("Fatura Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values2 = db.TBLFaturaBilgi.ToList();
            gridControl1.DataSource = values2;



        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            FaturaListele();
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
