using Microsoft.AspNetCore.Mvc;

namespace WorkManagement.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.ScriptLink = "~/js/Auth/login.js";
            return View();
        }

        public IActionResult Register()
        {
            ViewBag.ScriptLink = "~/js/Auth/register.js";
            return View();
        }
    }
}
