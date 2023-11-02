using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WorkManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly WorkManagementStableContext _context;
        public UserController(IAccountService accountService, WorkManagementStableContext context)
        {
            _accountService = accountService;
            _context = context;
        }

        public  IActionResult Profile()
        {
            ViewBag.ScriptLink = "~/js/User/profile.js";
            //get account info
            int? userId = HttpContext.Session.GetInt32("AccountKey");
            if(userId != null)
            {
                ViewBag.Account = _accountService.FindById(userId);
            }

            return View();
        }

        public IActionResult List()
        {
            ViewBag.ScriptLink = "~/js/User/list.js";
            ViewBag.Users = _context.Accounts.ToList();
            return View();
        }
    }
}
