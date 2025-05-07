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
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            TBLUrunTakip  tBLUrunTakip = new TBLUrunTakip();
            tBLUrunTakip.ACIKLAMA = richTextBox1.Text;
            tBLUrunTakip.URUNSERINO = txtSeriNo.Text;
            tBLUrunTakip.TARIH = DateTime.Parse(txtTarih.Text);
            db.TBLUrunTakip.Add(tBLUrunTakip);
            db.SaveChanges();
            MessageBox.Show("Arıza Detayları Kaydedildi");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
