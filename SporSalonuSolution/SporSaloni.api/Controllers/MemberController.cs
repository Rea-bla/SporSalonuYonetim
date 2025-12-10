using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SporSalonu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MemberController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Member/{tcno}
        [HttpGet("{tcno}")]
        public IActionResult GetMemberInfo(string tcno)
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
                                    WHERE TCNo = @TCNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TCNo", tcno);

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
                                    SecilenUyelikID = reader["SecilenUyelikID"] != DBNull.Value ? Convert.ToInt32(reader["SecilenUyelikID"]) : 0,
                                    IsActive = reader["BitisTarihi"] != DBNull.Value && Convert.ToDateTime(reader["BitisTarihi"]) >= DateTime.Now
                                };

                                return Ok(new
                                {
                                    success = true,
                                    data = member
                                });
                            }
                            else
                            {
                                return NotFound(new
                                {
                                    success = false,
                                    message = "Üye bulunamadı"
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

        // PUT: api/Member/update
        [HttpPut("update")]
        public IActionResult UpdateMemberInfo([FromBody] UpdateMemberRequest request)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Uyeler 
                                   SET Telefon = @Telefon, 
                                       KanGrubu = @KanGrubu, 
                                       Boy = @Boy, 
                                       Kilo = @Kilo
                                   WHERE TCNo = @TCNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TCNo", request.TCNo);
                        cmd.Parameters.AddWithValue("@Telefon", request.Telefon ?? "");
                        cmd.Parameters.AddWithValue("@KanGrubu", request.KanGrubu ?? "");
                        cmd.Parameters.AddWithValue("@Boy", request.Boy);
                        cmd.Parameters.AddWithValue("@Kilo", request.Kilo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok(new
                            {
                                success = true,
                                message = "Bilgileriniz başarıyla güncellendi"
                            });
                        }
                        else
                        {
                            return NotFound(new
                            {
                                success = false,
                                message = "Üye bulunamadı"
                            });
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

        // POST: api/Member/verify-entry
        [HttpPost("verify-entry")]
        public IActionResult VerifyEntry([FromBody] VerifyEntryRequest request)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT Ad, Soyad, BitisTarihi 
                                    FROM Uyeler 
                                    WHERE TCNo = @TCNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TCNo", request.TCNo);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string ad = reader["Ad"].ToString();
                                string soyad = reader["Soyad"].ToString();
                                DateTime? bitisTarihi = reader["BitisTarihi"] != DBNull.Value ?
                                                       Convert.ToDateTime(reader["BitisTarihi"]) : (DateTime?)null;

                                bool isActive = bitisTarihi.HasValue && bitisTarihi.Value >= DateTime.Now;

                                return Ok(new
                                {
                                    success = true,
                                    isActive = isActive,
                                    memberName = $"{ad} {soyad}",
                                    expiryDate = bitisTarihi,
                                    message = isActive ? "Giriş izni verildi" : "Üyelik süresi dolmuş"
                                });
                            }
                            else
                            {
                                return NotFound(new
                                {
                                    success = false,
                                    message = "Üye bulunamadı"
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

        // PUT: api/Member/change-password
        [HttpPut("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verify old password
                    string checkQuery = "SELECT COUNT(*) FROM Uyeler WHERE TCNo = @TCNo AND Sifre = @OldSifre";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@TCNo", request.TCNo);
                        checkCmd.Parameters.AddWithValue("@OldSifre", request.OldSifre);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            return BadRequest(new
                            {
                                success = false,
                                message = "Mevcut şifre yanlış"
                            });
                        }
                    }

                    // Update password
                    string updateQuery = "UPDATE Uyeler SET Sifre = @NewSifre WHERE TCNo = @TCNo";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TCNo", request.TCNo);
                        cmd.Parameters.AddWithValue("@NewSifre", request.NewSifre);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return Ok(new
                            {
                                success = true,
                                message = "Şifreniz başarıyla değiştirildi"
                            });
                        }
                    }
                }

                return StatusCode(500, new
                {
                    success = false,
                    message = "Şifre değiştirme işlemi başarısız"
                });
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
    }

    public class UpdateMemberRequest
    {
        public string TCNo { get; set; }
        public string Telefon { get; set; }
        public string KanGrubu { get; set; }
        public int Boy { get; set; } // yusuftan selamlar efenim
        public double Kilo { get; set; }
    }

    public class VerifyEntryRequest
    {
        public string TCNo { get; set; }
    }

    public class ChangePasswordRequest
    {
        public string TCNo { get; set; }
        public string OldSifre { get; set; }
        public string NewSifre { get; set; }
    }
}