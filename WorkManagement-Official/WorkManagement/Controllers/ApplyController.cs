using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
            var listPostApplied = _context.AppliedAndCareds.Where(x => x.AccountKey == accountKey).ToList();
			var listPost = _context.Posts.Include(x=> x.CompanyKeyNavigation).ToList();
            var result = new List<Post>();
            foreach (var item in listPostApplied)
            {
             foreach(var post in listPost)
                {
                    if(post.PostKey == item.PostKey)
                    {
                        result.Add(post);
                    }
                }
                
            }
            ViewBag.ScriptLink = "~/js/Job/list.js";
			List<Post> posts;
			ViewBag.Posts = result;
			ViewBag.Count = result.Count;
			ViewBag.Locations = _context.Companies.Select(x => x.Location).Distinct().ToList();
			ViewBag.Type = _context.Posts.Select(x => x.JobField).Distinct().ToList();
			return View();
		}
    }
}
