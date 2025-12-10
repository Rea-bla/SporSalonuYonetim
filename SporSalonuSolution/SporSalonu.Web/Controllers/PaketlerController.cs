// SporSalonu.Web/Controllers/PaketlerController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SporSalonu.Web.Controllers
{
    public class PaketlerController : Controller
    {
        // View'a gönderilecek paket modelinin tanımı (Bu kısım aynı kalmalı)
        public class Paket
        {
            public string Ad { get; set; }
            public string Fiyat { get; set; }
            public string Aciklama { get; set; } // Bu alanı kullanmasak bile modelde kalmalı
            public bool Ozel { get; set; } // Platin paketi vurgulamak için kullanılır
            public List<string> Ozellikler { get; set; }
        }

        public IActionResult Index()
        {
            // İstenen 4 paket tam olarak burada tanımlanmıştır:
            var paketler = new List<Paket>
            {
                new Paket
                {
                    Ad = "Standart Paket",
                    Fiyat = "₺1000",
                    Ozel = false,
                    Ozellikler = new List<string> {
                        "Tüm ekipmanlara erişim",
                        "Sadece hafta içi kullanım",
                        "Grup dersleri: Giriş seviye",
                        "Antrenör danışmanlığı yok (❌)"
                    }
                },

                new Paket
                {
                    Ad = "Gümüş Paket",
                    Fiyat = "₺1500",
                    Ozel = false,
                    Ozellikler = new List<string> {
                        "7/24 Salon Erişimi",
                        "Temel grup dersleri (Sınırsız)",
                        "Özel etkinliklere giriş indirimi",
                        "Sauna/Spa kullanımı dahil değil (❌)"
                    }
                },

                new Paket
                {
                    Ad = "Altın Paket",
                    Fiyat = "₺2000",
                    Ozel = false,
                    Ozellikler = new List<string> {
                        "Gümüş paket özelliklerinin hepsi",
                        "Tüm özel grup dersleri",
                        "Sauna ve Spa kullanımı (Haftada 2)",
                        "Beslenme rehberi (Dijital)"
                    }
                },

                new Paket
                {
                    Ad = "Platin Paket",
                    Fiyat = "₺3000",
                    Ozel = true, // Bu paket, Razor View'da ekstra vurgu alacaktır.
                    Ozellikler = new List<string> {
                        "Altın paket özelliklerinin hepsi",
                        "Kişisel Antrenörlük (Aylık 4 seans)",
                        "Kişiselleştirilmiş beslenme programı",
                        "VIP soyunma odası ve havlu servisi"
                    }
                }
            };

            ViewData["Title"] = "Üyelik Paketleri";
            return View(paketler);
        }
    }
}