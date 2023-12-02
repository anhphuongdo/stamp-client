using Microsoft.AspNetCore.Mvc;
using BIT_STAMP.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using BIT_STAMP.Data;

namespace BIT_STAMP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /*public IActionResult HomeRanking()
        {
            return View();
        }*/

        public IActionResult HomeRegisterStamp()
        {
            ViewData["School"] = new SelectList(_context.Schools, "SchoolId", "SchoolName");
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