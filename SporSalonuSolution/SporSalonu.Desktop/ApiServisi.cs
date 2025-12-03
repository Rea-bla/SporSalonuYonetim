using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonu.Desktop
{
    public class ApiServisi
    {
       
        private readonly string _apiAdresi = "http://localhost:5096";

        public async Task<bool> GirisYap(string kAdi, string sifre)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
         
                    var veri = new { KullaniciAdi = kAdi, Sifre = sifre };
                    var json = JsonSerializer.Serialize(veri);
                    var icerik = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage cevap = await client.PostAsync(_apiAdresi + "/api/Auth/giris", icerik);

                   
                    return cevap.IsSuccessStatusCode; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sunucuya (API) ulaşılamadı!\n" + ex.Message);
                    return false;
                }

            }
        }

        public async Task<string> UyeEkle(string tc, string ad, string soyad, string tel, string kan, string cinsiyet, int boy, double kilo, DateTime dogumTarihi, DateTime? bitisTarihi, string odeme ,int uyelikId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var yeniUye = new
                    {
                        TCNo = tc,
                        Ad = ad,
                        Soyad = soyad,
                        Telefon = tel,
                        KanGrubu = kan,
                        Cinsiyet = cinsiyet,
                        Boy = boy,
                        Kilo = kilo,
                        DogumTarihi = dogumTarihi,
                        BitisTarihi = bitisTarihi,
                        Odeme = odeme,
                        SecilenUyelikID = uyelikId
                    };

                    var json = JsonSerializer.Serialize(yeniUye);
                    var icerik = new StringContent(json, Encoding.UTF8, "application/json");

                    // DİKKAT: Adres senin controller yapına göre /api/Uyeler/ekle (Resimdeki gibi)
                    HttpResponseMessage cevap = await client.PostAsync(_apiAdresi + "/api/Uyeler/ekle", icerik);

                    // API'den gelen mesajı oku
                    string cevapMetni = await cevap.Content.ReadAsStringAsync();

                    if (cevap.IsSuccessStatusCode)
                    {
                        return "OK";
                    }
                    else
                    {
                        // Hata varsa API'den gelen mesajı döndür (Örn: "TC Zaten Kayıtlı")
                        return "HATA: " + cevapMetni;
                    }
                }
                catch (Exception ex)
                {
                    // Bağlantı hatası olursa buraya düşer
                    return "Sunucuya (API) ulaşılamadı!\n" + ex.Message;
                }
            } // 'using' burada kapanıyor
        } // 'UyeEkle' metodu burada kapanıyor
    }
}