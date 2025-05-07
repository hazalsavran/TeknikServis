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
    public partial class FrmArizaDetayListesi : Form
    {
        public FrmArizaDetayListesi()
        {
            InitializeComponent();
        }

        private void FrmArizaDetayListesi_Load(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            var degerler = from x in db.TBLUrunTakip
                           select new
                           {
                               x.TAKIPID,
                               x.URUNSERINO,
                               x.ACIKLAMA,
                               x.TARIH,                            
                             
                           };
            gridControl1.DataSource = degerler.ToList();
            gridView1.Columns["TAKIPID"].Visible = false;
        }
    }
}
