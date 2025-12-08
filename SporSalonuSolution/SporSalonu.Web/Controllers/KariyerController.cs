using Microsoft.AspNetCore.Mvc;

namespace SporSalonu.Web.Controllers
{
    public class KariyerController : Controller
    {
        // Bu Action, "Views/Kariyer/Index.cshtml" dosyasını arar
        public IActionResult Index()
        {
            return View();
        }
    }
}