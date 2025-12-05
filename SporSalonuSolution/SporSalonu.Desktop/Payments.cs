using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SporSalonu.Desktop;

namespace SporSalonu.Desktop
{
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        private async void BtnOdeme_Click(object sender, EventArgs e)
        {
            string girilenTc = TcNo.Text.Trim();

            // 2. Basit kontrol
            if (girilenTc.Length != 11)
            {
                MessageBox.Show("Lütfen 11 haneli geçerli bir TC giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string apiUrl = $"http://localhost:5096/api/uyeler/odeme-yap/{girilenTc}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // PUT isteği gönderiyoruz
                    HttpResponseMessage response = await client.PutAsync(apiUrl, null);

                    // 4. Sonucu Kontrol Et
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ödeme durumu başarıyla 'Ödendi' olarak güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // İstersen işlem bitince kutuyu temizleyebilirsin:
                        // TcNo.Text = ""; 
                    }
                    else
                    {
                        // API'den gelen hata mesajını oku
                        string hataMesaji = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("İşlem başarısız oldu.\nDetay: " + hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sunucuya bağlanılamadı: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TipButon_Click(object sender, EventArgs e)
        {

           
        }
    }
}
