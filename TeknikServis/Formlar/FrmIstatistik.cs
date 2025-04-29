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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBLUrun.Count().ToString();
            labelControl3.Text = db.TBLKategori.Count().ToString();
            labelControl9.Text = db.TBLUrun.Sum(x => x.STOK).ToString();
            labelControl7.Text = db.TBLUrun.OrderByDescending(x => x.STOK).Select(x => x.AD).FirstOrDefault();
            labelControl21.Text = db.TBLUrun
                                               .OrderByDescending(x => x.STOK)
                                               .Select(x => x.AD)
                                               .ToList()
                                               .LastOrDefault();
            labelControl17.Text = db.TBLUrun.OrderByDescending(x => x.SATISFIYAT).Select(x => x.AD).ToList().LastOrDefault();
            labelControl13.Text = db.TBLUrun.OrderByDescending(x => x.SATISFIYAT).Select(x => x.AD).FirstOrDefault();

        }
    }
}
