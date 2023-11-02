using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WorkManagement.Controllers
{
	public class CompanyController : Controller
	{
		private readonly WorkManagementStableContext _context;
		public CompanyController( WorkManagementStableContext context)
		{
			_context = context;
		}

        [HttpGet("company/list")]
        public IActionResult List()
		{
            ViewBag.ScriptLink = "~/js/Company/list.js";
            ViewBag.Company = _context.Companies.ToList();
			return View();
		}
        [HttpGet("company/add")]
        public IActionResult Add()
        {
            ViewBag.ScriptLink = "~/js/Company/add.js";
            return View();
        }

        [HttpGet("company/{id}")]
        public IActionResult Update(int id)
        {
            var company = _context.Companies.Find(id);
            ViewBag.Company = company;
            ViewBag.ScriptLink = "~/js/Company/update.js";
            return View();
        }
    }
}
