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
    }
}