using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WorkManagement.Controllers
{
    public class ApplyController : Controller
    {
        private readonly WorkManagementStableContext _context;
        HttpContext httpContext;

        public ApplyController(WorkManagementStableContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int accountKey = 0;
            //data from local storage
            if(HttpContext.Session.GetString("AccountKey") != null)
            {
                accountKey = int.Parse(HttpContext.Session.GetInt32("AccountKey")!.ToString());
			}
            var listPostApplied = _context.AppliedAndCareds.Where(x => x.AccountKey == accountKey).Select(x => x.PostKey).ToList();
			ViewBag.ScriptLink = "~/js/Job/list.js";
			List<Post> posts;
			ViewBag.Posts = listPostApplied;
			ViewBag.Count = listPostApplied.Count;
			ViewBag.Locations = _context.Companies.Select(x => x.Location).Distinct().ToList();
			ViewBag.Type = _context.Posts.Select(x => x.JobField).Distinct().ToList();
			return View();
		}
    }
}
