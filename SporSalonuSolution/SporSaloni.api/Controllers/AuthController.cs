using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SporSalonu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("giris")]
        public IActionResult GirisYap([FromBody] LoginModel model)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi=@k AND Sifre=@s";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@k", model.KullaniciAdi);
                        command.Parameters.AddWithValue("@s", model.Sifre);

                        int sonuc = (int)command.ExecuteScalar();

                        if (sonuc > 0)
                            return Ok(new { success = true, mesaj = "Giriş Başarılı İmparator" });
                        else
                            return Unauthorized(new { success = false, mesaj = "Hatalı Kullanıcı Adı veya Şifre" });
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { success = false, mesaj = "Hata: " + ex.Message });
                }
            }
        }
    }

    public class LoginModel
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}