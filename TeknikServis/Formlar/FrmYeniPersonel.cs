using DevExpress.XtraEditors;
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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            TBLPersonel tBLPersonel = new TBLPersonel();
            tBLPersonel.AD = txtPersonelAd.Text;
            tBLPersonel.SOYAD = txtSoyad.Text;
            tBLPersonel.TELEFON = txtTelefon.Text;
            tBLPersonel.MAIL = txtMail.Text;
            tBLPersonel.DEPARTMAN = Convert.ToByte(gridDepartman.EditValue);
            tBLPersonel.FOTOGRAF = txtImage.Text;
            db.TBLPersonel.Add(tBLPersonel);
            db.SaveChanges();
            MessageBox.Show("Personel başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void FrmYeniPersonel_Load(object sender, EventArgs e)
        {
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

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
