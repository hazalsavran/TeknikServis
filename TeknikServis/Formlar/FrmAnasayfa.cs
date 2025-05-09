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
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLUrun
                                       select new
                                       {
                                           x.AD,
                                           x.STOK
                                       }).Where(x=> x.STOK < 30).ToList();

            gridControl2.DataSource = (from x in db.TBLCari
                                       select new
                                       {
                                           x.AD,
                                           x.SOYAD,
                                           x.TELEFON,
                                           x.IL
                                       }).ToList();

            gridControl4.DataSource = db.urunKategori().ToList();

            DateTime bugun = DateTime.Today;
            var degerler = (from x in db.TBLNotlarim.OrderBy(y=>y.ID)
                            //where(x.TARIH == bugun)

                            select new
                            {
                                x.BASLIK,
                                x.ICERIK                           
                            });
            gridControl3.DataSource = degerler.ToList();
        }
    }
}
