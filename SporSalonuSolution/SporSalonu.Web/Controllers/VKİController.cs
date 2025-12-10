// Örnek: SporSalonu.Web/Controllers/VKiController.cs
using Microsoft.AspNetCore.Mvc;

namespace SporSalonu.Web.Controllers
{
    public class VKiController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "VKİ Hesaplama";
            return View(); // Views/VKi/Index.cshtml'i arayacak
        }
    }
}