using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunListesi frm = new Formlar.FrmUrunListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniUrun frm = new Formlar.FrmYeniUrun();
            frm.Show();
        }

        private void btnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmKategori frm = new Formlar.FrmKategori();
            frm.MdiParent = this;
            frm.Show();
        }

        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniKategori frm = new Formlar.FrmYeniKategori();

            frm.Show();
        }

        private void btnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmIstatistik frm = new Formlar.FrmIstatistik();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmCariListesi frm = new Formlar.FrmCariListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmCariler frm = new Formlar.FrmCariler();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniCari frm = new Formlar.FrmYeniCari();

            frm.Show();
        }

        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartman frm = new Formlar.FrmDepartman();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniDepartman frm = new Formlar.FrmYeniDepartman();
          
            frm.Show();
        }

        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersonel frm = new Formlar.FrmPersonel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnYeniPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniPersonel frm = new Formlar.FrmYeniPersonel();

            frm.Show();
        }

        private void btnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void btnYeniNot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword.exe");
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel.exe");
        }

        private void btnDöviz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmKurlar frm = new Formlar.FrmKurlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaListesi frm = new Formlar.FrmArizaListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnYeniUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunSatis frm = new Formlar.FrmUrunSatis();
          
            frm.Show();
        }

        private void btnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmSatislar frm = new Formlar.FrmSatislar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunKaydi frm = new Formlar.FrmArizaliUrunKaydi();

            frm.Show();
        }

        private void btnArizaDetaylar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaDetaylar frm = new Formlar.FrmArizaDetaylar();

            frm.Show();
        }

        private void btnArizaDetayListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaDetayListesi frm = new Formlar.FrmArizaDetayListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRCode frm = new Formlar.FrmQRCode();

            frm.Show();
        }

        private void btnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaListesi frm = new Formlar.FrmFaturaListesi();
            frm.MdiParent = this;
            frm.Show();
        }


        private void btnYeniFatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniFatura frm = new Formlar.FrmYeniFatura();

            frm.Show();
        }

        private void btnFaturaKalemListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaKalemleri frm = new Formlar.FrmFaturaKalemleri();
            frm.MdiParent = this;
            frm.Show();
        }
        Formlar.FrmAnasayfa frm;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (frm ==null || frm.IsDisposed)
            {
                frm = new Formlar.FrmAnasayfa();
                frm.MdiParent = this;
                frm.Show();
            }
           
           
        }

        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm == null || frm.IsDisposed)
            {
                frm = new Formlar.FrmAnasayfa();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
