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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Şu anki zamanı al
            DateTime simdi = DateTime.Now;

            // Saati Güncelle (Saat:Dakika şeklinde)
            lblSaat.Text = simdi.ToString("HH:mm");

            // Tarihi Güncelle (Gün Ay Yıl GünAdı)
            // Örnek Çıktı: 29 Kasım 2025 Cumartesi
            lblTarih.Text = simdi.ToString("dd MMMM yyyy dddd");

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            OdemeBilgileriniGetir();
            UyelikPaketleriniGetir();
            ToplamUyeSayisiniYazdir();
            DateTime simdi = DateTime.Now;

            lblSaat.Text = simdi.ToString("HH:mm");


            lblTarih.Text = simdi.ToString("dd MMMM yyyy dddd");

            lblIsim.Text = UserSession.AdSoyad;

            // HAFIZADAKİ RESMİ KUTUYA KOY
            if (UserSession.ProfilResmi != null)
            {
                // "guna2CirclePictureBox1" yerine senin resim kutunun adı neyse onu yaz
                guna2CirclePictureBox1.Image = UserSession.ProfilResmi;
            }

        }

        private void OdemeBilgileriniGetir()
        {
            // 1. Veritabanı bağlantı cümlen (Kendi sunucu bilgine göre düzenle)
            string connectionString = "Data Source=127.0.0.1,1435;Initial Catalog=SporSalonuDB;User ID=sa;Password=Admin123!;TrustServerCertificate=True;";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();

                    // 2. İsteğine uygun SQL Sorgusu
                    // NOT: Eğer sadece ödemesi 'NULL' olanları (ödemeyenleri) getirmek istersen:
                    // "SELECT Ad, Soyad, Telefon, Odeme FROM Uyeler WHERE Odeme IS NULL" yazmalısın.
                    string sorgu = "SELECT Ad, Soyad, Telefon, Odeme FROM Uyeler";

                    SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                    DataTable dt = new DataTable();

                    // 3. Verileri tabloya doldur
                    da.Fill(dt);

                    // 4. Guna2DataGridView'e verileri bağla
                    guna2DataGridView1.DataSource = dt;

                    // (İsteğe bağlı) Sütun başlıklarını düzenlemek istersen:
                    guna2DataGridView1.Columns["Ad"].HeaderText = "İsim";
                    guna2DataGridView1.Columns["Soyad"].HeaderText = "Soyisim";
                    guna2DataGridView1.Columns["Telefon"].HeaderText = "Telefon No";
                    guna2DataGridView1.Columns["Odeme"].HeaderText = "Ödeme Durumu";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
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
        private void ToplamUyeSayisiniYazdir()
        {
            string connectionString = "Data Source=127.0.0.1,1435;Initial Catalog=SporSalonuDB;User ID=sa;Password=Admin123!;TrustServerCertificate=True;";

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();

                    // SQL'de satırları sayan komut: COUNT(*)
                    string sorgu = "SELECT COUNT(*) FROM Uyeler";

                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

                    // ExecuteScalar: Sorgudan dönen ilk sütunun ilk satırını (yani sayıyı) alır.
                    // Dönen değer 'object' olduğu için önce int'e, sonra string'e çeviriyoruz.
                    int uyeSayisi = Convert.ToInt32(komut.ExecuteScalar());

                    // Label'a yazdırma işlemi
                    // Label ismin neyse 'lblUyeSayisi' yerine onu yazmalısın.
                    lblUyeSayisi.Text = "Toplam Üye: " + uyeSayisi.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sayı alınırken hata: " + ex.Message);
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
