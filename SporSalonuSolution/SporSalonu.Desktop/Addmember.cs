using SporSalonu.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SporSalonu.Desktop
{
    // Sınıf adındaki 'M' harfini küçülttük: Addmember
    public partial class Addmember : Form
    {
        // Seçilen bitiş tarihini hafızada tutmak için değişken
        DateTime? _secilenBitisTarihi = null;

        // Constructor adı da sınıf adıyla BİREBİR aynı olmalı
        public Addmember()
        {
            InitializeComponent();
        }

        // --- TARİH BUTONLARI ---

        private void Ay3_Click(object sender, EventArgs e)
        {
            _secilenBitisTarihi = DateTime.Now.AddMonths(3);
            BilgiVer("3 Aylık Üyelik Seçildi. Bitiş: " + _secilenBitisTarihi.Value.ToShortDateString());
        }

        private void Ay6_Click(object sender, EventArgs e)
        {
            _secilenBitisTarihi = DateTime.Now.AddMonths(6);
            BilgiVer("6 Aylık Üyelik Seçildi. Bitiş: " + _secilenBitisTarihi.Value.ToShortDateString());
        }

        private void Yillik_Click(object sender, EventArgs e)
        {
            _secilenBitisTarihi = DateTime.Now.AddYears(1);
            BilgiVer("1 Yıllık Üyelik Seçildi. Bitiş: " + _secilenBitisTarihi.Value.ToShortDateString());
        }

        // Label'a bilgi yazdıran yardımcı fonksiyon
        private void BilgiVer(string mesaj)
        {
            UyeLabel.Text = mesaj;
            UyeLabel.ForeColor = System.Drawing.Color.Green;
        }

        // --- KAYDET BUTONU ---

        private async void Kaydet_Click(object sender, EventArgs e)
        {
            // 1. ZORUNLU ALAN KONTROLLERİ
            if (string.IsNullOrWhiteSpace(Tc.Text) || string.IsNullOrWhiteSpace(Ad.Text))
            {
                MessageBox.Show("Lütfen TC ve Ad alanlarını doldurun!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Süre seçildi mi kontrolü
            if (_secilenBitisTarihi == null)
            {
                MessageBox.Show("Lütfen yukarıdaki butonlara basarak bir süre seçin (3 Ay, 6 Ay vb.)!", "Süre Yok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Butonu kilitle
            Kaydet.Enabled = false;
            Kaydet.Text = "İşleniyor...";

            try
            {
                ApiServices servis = new ApiServices();

                // 2. SAYISAL VERİLERİ ÇEVİR (Boşsa 0 yap)
                int boyDeger = string.IsNullOrEmpty(Boy.Text) ? 0 : Convert.ToInt32(Boy.Text);
                double kiloDeger = string.IsNullOrEmpty(Kilo.Text) ? 0 : Convert.ToDouble(Kilo.Text);
                string sifreDeger = Sifre.Text;
                string kanDeger = string.IsNullOrWhiteSpace(comboBox1.Text) ? null : comboBox1.Text;
                string cinsiyetDeger = string.IsNullOrWhiteSpace(Cinsiyet.Text) ? null : Cinsiyet.Text;
                string odemeDeger = string.IsNullOrWhiteSpace(Odeme.Text) ? null : Odeme.Text;

 
                int uyelikId = UyelikTip.SelectedIndex < 0 ? 1 : UyelikTip.SelectedIndex + 1;

                // 4. API'YE GÖNDER
                string sonuc = await servis.UyeEkle(
                    Tc.Text.Trim(),
                    Ad.Text.Trim(),
                    Soyad.Text.Trim(),
                    Telefon.Text.Trim(),
                    kanDeger,
                    cinsiyetDeger,
                    boyDeger,
                    kiloDeger,
                    sifreDeger,
                    TimePicker.Value,    // Doğum Tarihi
                    _secilenBitisTarihi, // Hesaplanan Bitiş Tarihi
                    odemeDeger,
                    uyelikId
                );

                // 5. SONUÇ
                if (sonuc == "OK")
                {
                    MessageBox.Show("Üye Başarıyla Eklendi İmparator!", "İşlem Tamam", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Tc.Clear();
                    Ad.Clear();
                    Soyad.Clear();
                    Telefon.Clear();
                    Boy.Clear();
                    Kilo.Clear();
                    Sifre.Clear();

                    // Seçimleri Sıfırla
                    comboBox1.SelectedIndex = -1; // Veya comboBox1
                    Cinsiyet.SelectedIndex = -1;
                    UyelikTip.SelectedIndex = 0; // Standart seçili kalsın

                    // Tarihleri Sıfırla
                    TimePicker.Value = DateTime.MaxValue;
                    _secilenBitisTarihi = null; // Hafızadaki tarihi de unut
                    UyeLabel.Text = "Tarih Seçilmedi";
                    UyeLabel.ForeColor = System.Drawing.Color.Black;

                    // İmleci tekrar ilk kutuya koy (Hız kazandırır)
                    Tc.Focus();
                }
                else
                {
                    MessageBox.Show(sonuc, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata meydana geldi: " + ex.Message);
            }
            finally
            {
                Kaydet.Enabled = true;
                Kaydet.Text = "Kaydet";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}