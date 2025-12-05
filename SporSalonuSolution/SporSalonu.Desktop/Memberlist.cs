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

namespace SporSalonu.Desktop
{
    public partial class Memberlist : Form
    {
        public Memberlist()
        {
            InitializeComponent();
        }

        private void Memberlist_Load(object sender, EventArgs e)
        {
            UyeListesiGetir();

        }
       
        void UyeListesiGetir()
        {
            // 1. Bağlantı Adresi 
            SqlConnection baglanti = new SqlConnection("Data Source=127.0.0.1,1435;Initial Catalog=SporSalonuDB;User ID=sa;Password=Admin123!;TrustServerCertificate=True;");

            baglanti.Open();
            // 2. Veritabanı Sorgusu (Tüm üyeleri getir)

            SqlDataAdapter da = new SqlDataAdapter("SELECT Uyeler.*, UyelikTipleri.Ad AS PaketTuru " +
                "FROM Uyeler " +
                "INNER JOIN UyelikTipleri ON Uyeler.SecilenUyelikID = UyelikTipleri.UyelikTipiId",
                baglanti);

            // 3. Sanal Tablo Oluşturma
            DataTable dt = new DataTable();

            // 4. Verileri Sanal Tabloya Doldurma
            da.Fill(dt);

            // 5. Guna2DataGridView'e Aktarma
            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.Columns["SecilenUyelikID"].Visible = false;
            guna2DataGridView1.Columns["UyeID"].Visible = false;
            baglanti.Close();
        }
    }
}
