using Microsoft.AspNetCore.Mvc;

namespace BIT_STAMP.Controllers
{
    public class TalkshowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
