using Microsoft.AspNetCore.Mvc;

namespace MpumalangaHealth.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}