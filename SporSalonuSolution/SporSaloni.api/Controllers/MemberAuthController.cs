using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SporSalonu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberAuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MemberAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST: api/MemberAuth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT TCNo, Ad, Soyad, Telefon, KanGrubu, Cinsiyet, Boy, Kilo, 
                                    DogumTarihi, BitisTarihi, Odeme, SecilenUyelikID 
                                    FROM Uyeler 
                                    WHERE TCNo = @TCNo AND Sifre = @Sifre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TCNo", request.TCNo);
                        cmd.Parameters.AddWithValue("@Sifre", request.Sifre);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var member = new
                                {
                                    TCNo = reader["TCNo"].ToString(),
                                    Ad = reader["Ad"].ToString(),
                                    Soyad = reader["Soyad"].ToString(),
                                    Telefon = reader["Telefon"].ToString(),
                                    KanGrubu = reader["KanGrubu"].ToString(),
                                    Cinsiyet = reader["Cinsiyet"].ToString(),
                                    Boy = reader["Boy"] != DBNull.Value ? Convert.ToInt32(reader["Boy"]) : 0,
                                    Kilo = reader["Kilo"] != DBNull.Value ? Convert.ToDouble(reader["Kilo"]) : 0.0,
                                    DogumTarihi = reader["DogumTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["DogumTarihi"]) : DateTime.MinValue,
                                    BitisTarihi = reader["BitisTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["BitisTarihi"]) : (DateTime?)null,
                                    Odeme = reader["Odeme"].ToString(),
                                    SecilenUyelikID = reader["SecilenUyelikID"] != DBNull.Value ? Convert.ToInt32(reader["SecilenUyelikID"]) : 0
                                };

                                return Ok(new
                                {
                                    success = true,
                                    message = "Giriş başarılı",
                                    data = member
                                });
                            }
                            else
                            {
                                return Unauthorized(new
                                {
                                    success = false,
                                    message = "TC Kimlik No veya şifre hatalı"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Sunucu hatası: " + ex.Message
                });
            }
        }



        // Helper method to hash passwords
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    // Request model
    public class LoginRequest
    {
        public string TCNo { get; set; }
        public string Sifre { get; set; }
    }
}