using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("api/[controller]")]
public class UyelikTipleriController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public UyelikTipleriController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM UyelikTipleri WHERE Ad IS NOT NULL";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var uyelikler = new List<object>();
                        while (reader.Read())
                        {
                            uyelikler.Add(new
                            {
                                uyelikTipId = reader.GetInt32(0),
                                ad = reader.GetString(1),
                                fiyat = reader.GetDecimal(2) // GetDouble yerine GetDecimal
                            });
                        }
                        return Ok(uyelikler);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Hata: " + ex.Message, detail = ex.ToString() });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM UyelikTipleri WHERE UyelikTipId = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var uyelik = new
                            {
                                uyelikTipId = reader.GetInt32(0),
                                ad = reader.GetString(1),
                                fiyat = reader.GetDecimal(2) // GetDouble yerine GetDecimal
                            };
                            return Ok(uyelik);
                        }
                        return NotFound(new { message = "Üyelik tipi bulunamadı" });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Hata: " + ex.Message, detail = ex.ToString() });
        }
    }
}