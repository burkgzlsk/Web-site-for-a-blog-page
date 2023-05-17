using BBloGer.Bussines;
using BBloGer.Core;
using BBloGer.Models;
using BBloGer.Models.Entiteis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Proxies.Internal;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace BBloGer.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly UserService _userService;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			_userService = new UserService();
		}

		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceResult<User> result = _userService.Login(model);

                if (!result.IsError)
                {
                    HttpContext.Session.SetInt32(Constants.UserId,result.Data.Id);
                    HttpContext.Session.SetString(Constants.Username, result.Data.UserName);
                    HttpContext.Session.SetString(Constants.UserEmail, result.Data.Email);
                    HttpContext.Session.SetString(Constants.UserRole, result.Data.IsAdmin? "admin" : "member");
                    return RedirectToAction(nameof(Login));
                }
                    
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        

        public IActionResult ProfileShow()
        {
            return View();
        }

		public IActionResult ProfileEdit()
		{
			return View();
		}
		public IActionResult DeleteProfile()
		{
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}