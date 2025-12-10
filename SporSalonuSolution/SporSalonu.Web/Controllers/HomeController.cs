using Microsoft.AspNetCore.Mvc;

namespace SporSalonu.Web.Controllers
{
    public class HomeController : Controller
    {
        // Bu metot Views/Home/Index.cshtml'i arar
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}