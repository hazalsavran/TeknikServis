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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            var values = db.TBLUrun.ToList();
            gridControl1.DataSource = values;
        }
    }
}
