using System.Text.RegularExpressions;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkManagement.Helper;

namespace WorkManagement.Controllers
{
    public class JobController : Controller
    {
        private readonly WorkManagementStableContext _context;
        public JobController(WorkManagementStableContext context)
        {
            _context = context;
        }

        [HttpGet("job/post/{postKey}")]
        public IActionResult Post(int postKey)
        {
			ViewBag.ScriptLink = "~/js/Post/post.js";

			if (postKey != 0) {
                var post = _context.Posts.Include(x => x.CompanyKeyNavigation).Where(x => x.PostKey == postKey).FirstOrDefault();
                ViewBag.Post = post;
                ViewBag.Exp = CommonFunction.SplitString(post.ExperienceType, ";");
                ViewBag.Req = CommonFunction.SplitString(post.RequiredCandicate, ";");
                ViewBag.Date = CommonFunction.ConvertDateTimeToString(post.ToTime);
            }
            return View();
        }

        public IActionResult List(string title, string location)
        {
            ViewBag.ScriptLink = "~/js/Job/list.js";
            List<Post> posts;
            if(!string.IsNullOrEmpty(location)) { 
                posts = _context.Posts.Include(x => x.CompanyKeyNavigation).Where(x => EF.Functions.Like(x.Title, $"%{title}%") && x.CompanyKeyNavigation.Location.Equals(location)).ToList();
            }else
            {
				posts = _context.Posts.Include(x => x.CompanyKeyNavigation).Where(x => EF.Functions.Like(x.Title, $"%{title}%")).ToList();
			}
            ViewBag.Posts = posts;
            ViewBag.Title = title;
            ViewBag.Location = location;
            ViewBag.Count = posts.Count;
            ViewBag.Locations = _context.Companies.Select(x => x.Location).Distinct().ToList();
			List<string> types = _context.Posts.Select(x => x.JobField).ToList();
			List<string> news = new List<string>();
			foreach (var type in types)
			{
				if (!news.Contains(type))
				{
					news.Add(type);
				}
			}
			ViewBag.Type = news;
			return View();
        }

        public IActionResult Add()
        {
            ViewBag.ScriptLink = "~/js/Job/add.js";
            List<string> types = _context.Posts.Select(x => x.JobField).ToList();
            List<string> news = new List<string>();
            foreach(var type in types)
            {
                if(!news.Contains(type))
                {
                    news.Add(type);
                }
            }
            ViewBag.Type = news;
            ViewBag.Company= _context.Companies.ToList();
            return View();
        }

    }
}
