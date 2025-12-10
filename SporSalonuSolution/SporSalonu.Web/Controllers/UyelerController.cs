using Microsoft.AspNetCore.Mvc;

namespace SporSalonu.Web.Controllers
{
    public class UyelerController : Controller
    {
        // GET: /Uyeler/UyeOl
        public IActionResult UyeOl()
        {
            return View();
        }
    }
}