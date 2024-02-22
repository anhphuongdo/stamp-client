using BIT_STAMP.Data;
using BIT_STAMP.Models;
using BIT_STAMP.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace BIT_STAMP.Controllers
{
    public class TalkshowController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public TalkshowController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public async Task<IActionResult> HomeRegisterTalkshow()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewData["School"] = new SelectList(_context.Schools, "SchoolId", "SchoolName");
                var atd = _context.Us.FirstOrDefault(u => u.Email.Equals(user.Email) && u.UsMssv != null);

                if(atd != null) { 
                    ViewBag.atd = atd;
                    ViewData["SelectedSchool"] = new SelectList(_context.Schools, "SchoolId", "SchoolName", atd.SchoolId);
                }

                var talkshow = _context.Talkshows.Count();
                ViewBag.talkshow = talkshow;

                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterInfor(string PhoneNumber, string UsMssv, int? SchoolId, string FullName)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (PhoneNumber != null && UsMssv != null && SchoolId != null && FullName != null)
            {
                var atd = _context.Us.FirstOrDefault(m => m.Email.Equals(user.Email));
                if (atd == null)
                {
                    var findMssv = _context.Us.Where(m => m.UsMssv.Trim().ToLower().Equals(UsMssv.Trim().ToLower())).Count();
                    if (findMssv > 0)
                    {
                        TempData["error"] = "Mã số sinh viên đã được đăng ký với tài khoản Email khác";
                        return LocalRedirect("~/Talkshow/HomeRegisterTalkshow");
                    }

                    Us newAttendee = new Us();
                    newAttendee.STT = _context.Us.OrderBy(m => m.STT).Last().STT + 1;
                    newAttendee.PhoneNumber = PhoneNumber;
                    newAttendee.UsMssv = UsMssv;
                    newAttendee.FullName = FullName;
                    newAttendee.SchoolId = (int)SchoolId;
                    newAttendee.Email = user.Email;

                    _context.Us.Add(newAttendee);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Thêm thông tin thành công";
                }
                else
                {
                    TempData["error"] = "Thông tin đã tồn tại";
                }

            }
            return LocalRedirect("~/Talkshow/HomeRegisterTalkshow");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeInfor(string PhoneNumber, string UsMssv, int? SchoolId, string FullName)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (PhoneNumber != null && UsMssv != null && SchoolId != null && FullName != null)
            {
                var atd = _context.Us.FirstOrDefault(m => m.Email.Equals(user.Email));
                if (atd == null)
                {
                    TempData["error"] = "Thông tin không tồn tại";
                }
                else
                {
                    var findMssv = _context.Us.Where(m => !m.Email.Equals(user.Email) && m.UsMssv.Trim().ToLower().Equals(UsMssv.Trim().ToLower())).Count();
                    if (findMssv > 0)
                    {
                        TempData["error"] = "Mã số sinh viên đã tồn tại";
                        return LocalRedirect("~/Talkshow/HomeRegisterTalkshow");
                    }

                    atd.STT = _context.Us.OrderBy(m => m.STT).Last().STT + 1;
                    atd.PhoneNumber = PhoneNumber;
                    atd.UsMssv = UsMssv;
                    atd.FullName = FullName;
                    atd.SchoolId = (int)SchoolId;

                    _context.Us.Update(atd);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Thay đổi thông tin thành công";
                }

            }
            return LocalRedirect("~/Talkshow/HomeRegisterTalkshow");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterTalkshow()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            var now = DateTime.Now;
            var end = new DateTime(2024, 1, 22, 17, 59, 59);

            if (now > end || _context.Talkshows.Count() >= 320)
            {
                TempData["error"] = "Form đăng ký tham gia đã đóng do quá hạn hoặc đủ số lượng tham gia.";
                return LocalRedirect("~/Talkshow/HomeRegisterTalkshow");
            }

            var atd = _context.Us.FirstOrDefault(u => u.Email.Equals(user.Email) && u.UsMssv != null);
            /*var atd = _context.Us.FirstOrDefault(m => m.Id.Equals(user.Id));*/
            if (atd == null)
            {
                TempData["error"] = "Bạn phải thêm thông tin cá nhân trước.";
            }
            else
            {
                var registerUser = _context.Talkshows.FirstOrDefault(m => m.UserId.Equals(atd.Id));
                if (registerUser != null)
                {
                    TempData["error"] = "Bạn đã đăng ký tham gia Talkshow thành công, không thể đăng ký thêm.";
                }
                else
                {
                    Talkshow register = new Talkshow();
                    register.UserId = atd.Id;

                    _context.Talkshows.Add(register);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Bạn đã đăng ký tham gia Talkshow thành công!";

                    /*await _emailSender.SendEmailAsync(
                        user.Email,
                        "[NO-REPLY] Đăng ký tham gia Talkshow S.T.A.M.P 2023",
                        $"Bạn đã đăng ký tham gia Talkshow S.T.A.M.P 2023 thành công. Nếu đây không phải hoạt động của bạn, vui lòng xóa email này.");*/
                }
            }          
            return LocalRedirect("~/Talkshow/HomeRegisterTalkshow");
        }
    }
}
