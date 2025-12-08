using Microsoft.AspNetCore.Mvc;

namespace SporSalonu.Web.Controllers
{
    
    public class IletisimController : Controller
    {
        // Kullanıcı /Iletisim adresine gittiğinde Views/Iletisim/Index.cshtml dosyasını arar
        public IActionResult Index()
        {
            
            return View();
        }
    }
}