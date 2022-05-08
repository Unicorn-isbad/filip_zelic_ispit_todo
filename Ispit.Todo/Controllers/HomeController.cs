using Ispit.Todo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ispit.Todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SignInManager<IdentityUser> _user;


        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> user)
        {
            _logger = logger;
            _user = user;
        }

        public IActionResult Index()
        {
            if (_user.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Task");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}