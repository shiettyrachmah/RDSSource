using Microsoft.AspNetCore.Mvc;

namespace WebSiram.Controllers
{
    public class UserGroupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
