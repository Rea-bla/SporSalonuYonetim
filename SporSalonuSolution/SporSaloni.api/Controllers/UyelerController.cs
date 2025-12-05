using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SporSalonu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyelerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UyelerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // --- ÜYE EKLEME METODU ---
        [HttpPost("ekle")]
        public IActionResult UyeEkle([FromBody] UyeModel uye)
        {
            if (uye.TCNo.Length != 11)
            {
                return BadRequest(new { success = false, mesaj = "TC Kimlik Numarası 11 haneli olmalıdır!" });
            }

            try
            {
                int toplam = 0;
                for (int i = 0; i < 10; i++)
                {
                    toplam += int.Parse(uye.TCNo[i].ToString());
                }

                int kuralSayisi = toplam % 10;
                int onbirinciHane = int.Parse(uye.TCNo[10].ToString());

                if (kuralSayisi != onbirinciHane)
                {
                    return BadRequest(new { success = false, mesaj = "Geçersiz TC!" });
                }
            }
            catch
            {
                return BadRequest(new { success = false, mesaj = "TC Kimlik sadece rakamlardan oluşmalıdır!" });
            }

            // --- SQL KAYIT İŞLEMİ ---
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO Uyeler 
                                    (TCNo, Ad, Soyad, Telefon, KanGrubu, Cinsiyet, Boy, Kilo, DogumTarihi, BitisTarihi, Odeme, Sifre, SecilenUyelikID) 
                                    VALUES 
                                    (@tc, @ad, @soyad, @tel, @kan, @cin, @boy, @kilo, @dt, @bitis, @odeme, @sifre, @uyelikId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tc", uye.TCNo);
                        command.Parameters.AddWithValue("@ad", uye.Ad);
                        command.Parameters.AddWithValue("@soyad", uye.Soyad);
                        command.Parameters.AddWithValue("@tel", uye.Telefon ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@kan", uye.KanGrubu ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@cin", uye.Cinsiyet ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@boy", uye.Boy);
                        command.Parameters.AddWithValue("@odeme", uye.Odeme);
                        command.Parameters.AddWithValue("@kilo", uye.Kilo);
                        command.Parameters.AddWithValue("@dt", uye.DogumTarihi);
                        command.Parameters.AddWithValue("@sifre", uye.Sifre);


                        if (uye.BitisTarihi.HasValue)
                            command.Parameters.AddWithValue("@bitis", uye.BitisTarihi.Value);
                        else
                            command.Parameters.AddWithValue("@bitis", DBNull.Value);

                        command.Parameters.AddWithValue("@uyelikId", uye.SecilenUyelikID);

                        int sonuc = command.ExecuteNonQuery();

                        if (sonuc > 0)
                            return Ok(new { success = true, mesaj = "Üye Başarıyla Eklendi " });
                        else
                            return BadRequest(new { success = false, mesaj = "Kayıt yapılamadı." });
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("UNIQUE KEY") || ex.Message.Contains("PRIMARY KEY"))
                        return BadRequest(new { success = false, mesaj = "Bu TC Kimlik zaten sistemde kayıtlı!" });

                    return StatusCode(500, new { success = false, mesaj = "Sunucu Hatası: " + ex.Message });
                }
            }
        }

  
        [HttpDelete("sil/{tcNo}")]
        public IActionResult UyeSil(string tcNo)
        {
            // TC doğrulama
            if (string.IsNullOrEmpty(tcNo) || tcNo.Length != 11)
            {
                return BadRequest(new { success = false, mesaj = "Geçersiz TC Kimlik Numarası." });
            }

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            string query = "DELETE FROM Uyeler WHERE TCNo = @tcNo";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tcNo", tcNo);
                        int sonuc = command.ExecuteNonQuery();

                        if (sonuc > 0)
                            return Ok(new { success = true, mesaj = "Üye başarıyla silindi." });
                        else
                            return NotFound(new { success = false, mesaj = "Bu TC ile kayıtlı üye bulunamadı." });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, mesaj = "Hata: " + ex.Message });
            }
        }

    } 
} 