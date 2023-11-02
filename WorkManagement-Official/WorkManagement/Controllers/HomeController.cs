using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WorkManagement.Controllers
{
    public class HomeController : Controller
    {
		private readonly WorkManagementStableContext _context;
		public HomeController(WorkManagementStableContext context)
		{
			_context = context;
		}
		public IActionResult Index1()
        {
            return Redirect("/swagger/index.html");
        }

        public IActionResult Index()
        {
            ViewBag.ScriptLink = "~/js/Home/home.js";
			ViewBag.Locations = _context.Companies.Select(x => x.Location).Distinct().ToList();
			return View();
        }

		public IActionResult About()
		{
			return View();
		}
	}
}
