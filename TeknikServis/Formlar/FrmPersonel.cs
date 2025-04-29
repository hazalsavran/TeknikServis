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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void Listele()
        {
            var values = (from x in db.TBLPersonel
                          select new
                          {
                              x.ID,
                              x.AD,
                              x.SOYAD,
                              DepartmanAd = x.TBLDepartman.AD,
                              x.TELEFON,
                              x.MAIL,                           
                              DepartmanID = x.DEPARTMAN // Include the ID
                             
                          }).ToList();
            gridControl1.DataSource = values;

            var departmanlar = db.TBLDepartman
                   .Select(d => new
                   {
                       d.ID,
                       d.AD
                   })
                   .ToList();
            gridDepartman.Properties.DataSource = departmanlar;
            gridDepartman.Properties.DisplayMember = "AD"; // Görüntülenecek alan
            gridDepartman.Properties.ValueMember = "ID";  // Seçilen değerin ID'si
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
           Listele();
          
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtPersonelAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtPersonelSoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            txtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            gridDepartman.EditValue = gridView1.GetFocusedRowCellValue("DepartmanID"); // Use the ID
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var personel = db.TBLPersonel.Find(id);
            db.TBLPersonel.Remove(personel);
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var personel = db.TBLPersonel.Find(id);
            personel.AD = txtPersonelAd.Text;
            personel.SOYAD = txtPersonelSoyad.Text;
            personel.TELEFON = txtTelefon.Text;
            personel.MAIL = txtMail.Text;
            personel.DEPARTMAN = gridDepartman.EditValue != null ? Convert.ToByte(gridDepartman.EditValue) : (byte?)null; // Use the selected department ID
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
