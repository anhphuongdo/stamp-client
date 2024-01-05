using BIT_STAMP.Data;
using BIT_STAMP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BIT_STAMP.Controllers
{
    public class ExhibitionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ExhibitionController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Exhibition()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var product = _context.Products.OrderByDescending(m => m.VoteAmount).ToList();
                var registerUser = _context.OfflineVotings.FirstOrDefault(m => m.UserId.Equals(user.Id));
                ViewBag.RegisterUser = registerUser;

                var atd = _context.Us.FirstOrDefault(u => u.Email.Equals(user.Email) && u.UsMssv != null);
                ViewBag.atd = atd;

                return View(product);
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Exhibition(IFormFile likefanpageImg, IFormFile upstoryImg, IFormCollection col)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            var atd = _context.Us.FirstOrDefault(m => m.Id.Equals(user.Id));
            if (atd == null)
            {
                TempData["error"] = "Bạn phải thêm thông tin cá nhân trước";
                return LocalRedirect("~/Talkshow/HomeRegisterTalkshow");
            }

            var registerUser = _context.OfflineVotings.FirstOrDefault(m => m.UserId.Equals(user.Id));
            if (registerUser != null)
            {
                TempData["error"] = "Bạn chỉ được bình chọn 01 lần";
                return View();
            }

            if (col.Count > 3 && likefanpageImg != null && upstoryImg != null)
            {
                OfflineVoting p = new OfflineVoting();

                /*using (var memoryStream = new MemoryStream())
                {
                    likefanpageImg.CopyTo(memoryStream);
                    p.FanpageImg = memoryStream.ToArray();
                }
                using (var memoryStream = new MemoryStream())
                {
                    upstoryImg.CopyTo(memoryStream);
                    p.StoryImg = memoryStream.ToArray();
                }*/

                int count = 0;
                foreach(var item in col)
                {
                    if(count < col.Count - 1)
                    {
                        string key = item.Key;
                        string value = item.Value;
                        count++;
                    }         
                }
            }
            else
            {
                TempData["error"] = "Bạn cần chọn ít nhất 01 tác phẩm.";
            }
            return View();
        }
    }
}
