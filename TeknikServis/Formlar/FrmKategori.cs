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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            var values = from x in db.TBLKategori
                         select new
                         {
                             x.ID,
                             x.AD,
                            
                         };
            gridControl1.DataSource = values.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLKategori tBLKategori = new TBLKategori();
            tBLKategori.AD = txtKategoriAd.Text;
            db.TBLKategori.Add(tBLKategori);
            db.SaveChanges();
            MessageBox.Show("Kategori başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtKategoriAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = db.TBLKategori.Find(id);
            values.AD = txtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var values = from x in db.TBLKategori
                         select new
                         {
                             x.ID,
                             x.AD,

                         };
            gridControl1.DataSource = values.ToList();
        }
    }
}
