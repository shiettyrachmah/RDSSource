using Microsoft.AspNetCore.Mvc;

namespace WebSiram.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
