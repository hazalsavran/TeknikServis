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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
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
            TBLUrunKabul tBLUrunKabul = new TBLUrunKabul();           
            tBLUrunKabul.GELISTARIHI = DateTime.Parse(dateEdit1.Text);
            tBLUrunKabul.URUNSERINO = txtSeriNo.Text;
          
            tBLUrunKabul.CARI = int.Parse(txtId.Text);
            tBLUrunKabul.PERSONEL = short.Parse(txtPersonel.Text);
            db.TBLUrunKabul.Add(tBLUrunKabul);
           
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Kaydı Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var urun = db.TBLUrunHareket.FirstOrDefault(u => u.URUNSERINO == txtSeriNo.Text);
            if (urun!=null)
            {
                txtId.Text = urun.MUSTERI.ToString();
                txtPersonel.Text = urun.PERSONEL.ToString();
            }
            else
            {
                MessageBox.Show("Ürün Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }
    }
}
