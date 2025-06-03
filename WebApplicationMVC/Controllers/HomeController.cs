using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> branches = new List<string>(); 
            branches.Add("main");
            branches.Add("develop");
            branches.Add("feature");
            branches.Add("feature");
            List<string> descripts = new List<string>();
            descripts.Add("this is the fisrt descript");
            descripts.Add("this is the second descript");

            descripts.Add("this is the third descript");
            ViewData["desc"] = descripts;
            return View("index",branches);
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
