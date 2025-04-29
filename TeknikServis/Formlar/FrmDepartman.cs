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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLDepartman
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.ACIKLAMA
                                       }).ToList();
        }

      

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var departman = db.TBLDepartman.Find(id);
            db.TBLDepartman.Remove(departman);
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var departman = db.TBLDepartman.Find(id);
            departman.AD = txtDepartmanAd.Text;
            departman.ACIKLAMA = txtAciklama.Text;
            db.SaveChanges();
            MessageBox.Show("Departman başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridControl1.DataSource = (from x in db.TBLDepartman
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.ACIKLAMA
                                       }).ToList();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLDepartman
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.ACIKLAMA
                                       }).ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtDepartmanAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }
    }
}
