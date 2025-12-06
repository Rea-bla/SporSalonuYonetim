using Guna.UI2.WinForms;
using SporSalonu.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonu.Desktop
{
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=127.0.0.1,1435;Initial Catalog=SporSalonuDB;User ID=sa;Password=Admin123!;TrustServerCertificate=True;");


        void UyelikTipleriniGetir()
        {
            try
            {
                baglanti.Open();
                // Sadece ihtiyacımız olan ID ve Ad sütunlarını çekiyoruz
                SqlCommand komut = new SqlCommand("SELECT UyelikTipiId, Ad FROM UyelikTipleri", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                UyelikTip.DataSource = null;

                UyelikTip.DataSource = dt;
                UyelikTip.DisplayMember = "Ad";           // Kullanıcı "Standart, Gold" görecek
                UyelikTip.ValueMember = "UyelikTipiId";   // Arka planda "1, 2" tutulacak

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                baglanti.Close();
            }
        }
        private void UyelikPaketleriniGetir()
        {
            // Bağlantı cümlen (Diğeriyle aynı)
            string connectionString = "Data Source=127.0.0.1,1435;Initial Catalog=SporSalonuDB;User ID=sa;Password=Admin123!;TrustServerCertificate=True;";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();

                    // UyelikTipleri tablosundan sadece Ad (Üyelik Tipi) ve Fiyat sütunlarını çekiyoruz
                    string sorgu = "SELECT Ad, Fiyat FROM UyelikTipleri";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    // Buraya DİKKAT: Veriyi aktarmak istediğin ikinci DataGridView'in ismini yazmalısın.
                    // Örnek olarak 'guna2DataGridView2' yazdım.
                    guna2DataGridView2.DataSource = dt;

                    // Başlıkları daha şık göstermek için (İsteğe bağlı):
                    guna2DataGridView2.Columns["Ad"].HeaderText = "Üyelik Tipi";
                    guna2DataGridView2.Columns["Fiyat"].HeaderText = "Ücret (TL)";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Paketler yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            UyelikPaketleriniGetir();
            UyelikTipleriniGetir();
        }

        private void TipButon_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                // SQL Update Sorgusu
                // Parametre kullanarak SQL Injection açıklarını önlüyoruz.
                string sorgu = "UPDATE UyelikTipleri SET Fiyat = @p1 WHERE UyelikTipiId = @p2";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                // Fiyatı decimal (para birimi) formatına çeviriyoruz
                komut.Parameters.AddWithValue("@p1", decimal.Parse(TipTxt.Text));

                // Hangi üyeliğin güncelleneceğini seçili ID'den alıyoruz
                komut.Parameters.AddWithValue("@p2", UyelikTip.SelectedValue);

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Fiyat başarıyla güncellendi!");
                UyelikPaketleriniGetir();
                // İstersen işlem sonrası textbox'ı temizleyebilirsin
                TipTxt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
    }
}
