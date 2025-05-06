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
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var values = from x in db.TBLUrunKabul
                         select new
                         {
                             x.ISLEMID,
                            
                             PersonelAdi = x.TBLPersonel.AD, 
                             CariBilgi = x.TBLCari.AD + " " + x.TBLCari.SOYAD, 
                             x.GELISTARIHI,
                             x.CIKISTARIHI,
                             x.URUNSERINO
                         };

            gridControl1.DataSource = values.ToList();
        }
    }
}
