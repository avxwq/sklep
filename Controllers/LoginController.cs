using Microsoft.AspNetCore.Mvc;

namespace sklep.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
