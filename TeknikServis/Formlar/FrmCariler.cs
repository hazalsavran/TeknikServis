using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmCariler : Form
    {
        public FrmCariler()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        SqlConnection SqlConnection = new SqlConnection(@"Data Source=HAZALSAVRAN\SQLEXPRESS;Initial Catalog=DbTeknikServis;Integrated Security=True;");
        private void FrmCariler_Load(object sender, EventArgs e)
        {


            gridControl1.DataSource = (from x in db.TBLCari
                                       select new
                                       {
                                           x.ID,
                                           x.AD,
                                           x.SOYAD,
                                           x.TELEFON,
                                           x.IL,
                                           x.ILCE,
                                           x.MAIL,
                                           x.ADRES,
                                           x.VERGIDAIRESI,
                                           x.VERGINO
                                       }).OrderBy(x=>x.IL)
                                         .GroupBy(y=>y.IL)
                                         .Select(g => new
                                       {
                                           IL = g.Key,
                                           Toplam = g.Count()
                                       }).ToList();

            SqlConnection.Open();
            SqlCommand komut = new SqlCommand("Select IL, Count(*) from TBLCari group by Il", SqlConnection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(), Convert.ToDouble(dr[1]));
            }
            SqlConnection.Close();


        }
    }
}
