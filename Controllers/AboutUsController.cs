using Microsoft.AspNetCore.Mvc;

namespace BIT_STAMP.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
