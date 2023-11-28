using Microsoft.AspNetCore.Mvc;
using BIT_STAMP.Models;
using System.Diagnostics;

namespace BIT_STAMP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*public IActionResult HomeRanking()
        {
            return View();
        }*/

        public IActionResult HomeRegisterStamp()
        {
            return View();
        }
        /*public IActionResult HomeRegisterTalkshow()
        {
            return View();
        }
        public IActionResult HomeUser()
        {
            return View();
        }*/
        public IActionResult Index()
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