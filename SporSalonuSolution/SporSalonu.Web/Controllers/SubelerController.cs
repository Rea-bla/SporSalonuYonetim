using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SporSalonu.Web.Controllers
{
    public class SubelerController : Controller
    {
        // Şube verilerini temsil eden basit bir sınıf
        public class Sube
        {
            public string? Name { get; set; }
            public string? City { get; set; }
            public string? Address { get; set; }
            public string? Phone { get; set; }
            public string? Hours { get; set; }
        }

        public IActionResult Index()
        {
            // JavaScript kodundaki verileri C# modeline taşıyoruz
            var subeler = new List<Sube>
            {
                new Sube { Name = "Turhal Şubesi", City = "Turhal", Address = "Gür Mahallesi, Turhal, Tokat", Phone = "0553 937 17 60", Hours = "06:00 - 23:00" },
                new Sube { Name = "Malatya Şubesi", City = "Malatya", Address = " İnönü Caddesi, Malatya", Phone = "0546 631 6676", Hours = "06:00 - 23:00" },
                new Sube { Name = "Sivas Şubesi", City = "Sivas", Address = "Atatürk Bulvarı, Sivas", Phone = "0541 100 58 05", Hours = "06:00 - 23:00" },
                new Sube { Name = "Sinop Şubesi", City = "Sinop", Address = "Bozkurt Caddesi, Sinop", Phone = "0546 234 68 42", Hours = "06:00 - 23:00" },
                new Sube { Name = "İstanbul Şubesi", City = "İstanbul", Address = "Bağcılar, İstanbul", Phone = "0546 234 68 42 , 0541 100 58 05", Hours = "06:00 - 23:00" }
            };

            // Veriyi View'e gönderiyoruz
            return View(subeler);
        }
    }
}