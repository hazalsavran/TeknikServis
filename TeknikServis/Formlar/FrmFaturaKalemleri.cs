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
    public partial class FrmFaturaKalemleri : Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }

    
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void btnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtFaturaId.Text);
            var degerler = (from x in db.TBLFaturaDetay
                            select new
                            {
                                x.FATURADETAYID,
                                x.URUN,
                                x.ADET,
                                x.FIYAT,
                                x.TUTAR,
                                x.FATURAID
                            }).Where(x => x.FATURAID == id).ToList();
            gridControl1.DataSource = degerler;

        }
    }
}
