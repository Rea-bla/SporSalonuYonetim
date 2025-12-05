using Microsoft.AspNetCore.Mvc;

public class AnasayfaController : Controller
    {
        // Bu, varsayılan olarak çalışacak olan Action metodudur (sizin sayfanız).
        public IActionResult Index()
        {
            // 'Views/Anasayfa/Index.cshtml' dosyasını göstermesini söylüyoruz.
            return View();
        }
    }

