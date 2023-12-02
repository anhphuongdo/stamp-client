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
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            var atd = _context.Us.FirstOrDefault(u => u.Id.Equals(user.Id));
            ViewBag.atd = atd;

            ViewData["School"] = new SelectList(_context.Schools, "SchoolId", "SchoolName");
            return View();
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
                var atd = _context.Us.FirstOrDefault(m => m.Id.Equals(user.Id));
                if (atd == null)
                {
                    var findMssv = _context.Us.Where(m => m.UsMssv.Trim().ToLower().Equals((UsMssv + "*atd").Trim().ToLower())).Count();
                    if (findMssv > 0)
                    {
                        TempData["error"] = "Mã số sinh viên đã tồn tại";
                        return LocalRedirect("HomeRegisterTalkshow");
                    }

                    Us newAttendee = new Us();
                    newAttendee.STT = _context.Us.OrderBy(m => m.STT).Last().STT + 1;
                    newAttendee.PhoneNumber = PhoneNumber;
                    newAttendee.UsMssv = UsMssv + "*atd";
                    newAttendee.FullName = FullName;
                    newAttendee.SchoolId = (int)SchoolId;
                    newAttendee.Email = user.Email;

                    _context.Us.Add(newAttendee);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Thêm thông tin thành công";
                }
                else
                {
                    var findMssv = _context.Us.Where(m => !m.Id.Equals(user.Id) && m.UsMssv.Trim().ToLower().Equals((UsMssv + "*atd").Trim().ToLower())).Count();
                    if (findMssv > 0)
                    {
                        TempData["error"] = "Mã số sinh viên đã tồn tại";
                        return LocalRedirect("HomeRegisterTalkshow");
                    }

                    atd.STT = _context.Us.OrderBy(m => m.STT).Last().STT + 1;
                    atd.PhoneNumber = PhoneNumber;
                    atd.UsMssv = UsMssv + "*atd";
                    atd.FullName = FullName;
                    atd.SchoolId = (int)SchoolId;

                    _context.Us.Update(atd);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Thay đổi thông tin thành công";
                }

            }
            return LocalRedirect("HomeRegisterTalkshow");
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
            var atd = _context.Us.FirstOrDefault(m => m.Id.Equals(user.Id));
            if (atd == null)
            {
                TempData["error"] = "Bạn phải thêm thông tin cá nhân trước";
                return LocalRedirect("HomeRegisterTalkshow");
            }
            Talkshow register = new Talkshow();
            register.UserId = user.Id;

            _context.Talkshows.Add(register);
            await _context.SaveChangesAsync();
            TempData["success"] = "Bạn đã đăng ký tham gia Talkshow thành công";

            await _emailSender.SendEmailAsync(
                user.Email,
                "[NO-REPLY] Đăng ký tham gia Talkshow S.T.A.M.P 2023",
                $"Bạn đã đăng ký tham gia Talkshow S.T.A.M.P 2023 thành công. Nếu đây không phải hoạt động của bạn, vui lòng xóa email này.");

            return LocalRedirect("HomeRegisterTalkshow");
        }
    }
}
