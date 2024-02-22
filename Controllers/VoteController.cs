using BIT_STAMP.Data;
using BIT_STAMP.Models;
using BIT_STAMP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BIT_STAMP.Controllers
{
    public class VoteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public VoteController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Voting(string? searchString, int page = 1)
        {
            var product = _context.Products.OrderByDescending(m => m.VoteAmount).ToList();
            if(searchString != null)
            {
                var listProduct = _context.Products.Where(m => m.ProductName.Trim().ToLower().Contains(searchString.Trim().ToLower())).ToList();
                ViewBag.SearchProduct = listProduct.ToList();
            }
            else
            {
                List<Product> products = new List<Product>();
                ViewBag.SearchProduct = products;
            }

            var group = _context.GroupUsers;
            ViewBag.Group = group.ToList();

            var vote = _context.Votes.ToList();
            ViewBag.Vote = vote.ToList();

            var top20 = _context.Products.OrderByDescending(m => m.VoteAmount).Take(20).ToList();
            ViewBag.Top20 = top20.ToList();

            int pageSize = 9;
            int totalCount = product.Count;
            int skip = (page - 1) * pageSize;
            var pagedItems = product.Skip(skip).Take(pageSize).ToList();

            PageViewModel<Product> mymodel = new PageViewModel<Product>
            {
                Items = pagedItems,
                TotalCount = totalCount,
                PageSize = pageSize,
                PageIndex = page
            };
            return View(mymodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Voting(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (id == null || id == 0 || _context.Products == null)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                TempData["error"] = "Tác phẩm không tồn tại";
                return NotFound();
            }
            var vote = _context.Votes.FirstOrDefault(m => m.ProductId == id && m.UserId.Equals(user.Id));
            if (vote != null)
            {
                TempData["error"] = "Bạn đã bình chọn cho tác phẩm này rồi";
                return NotFound();
            }

            Vote newVote = new Vote();
            newVote.ProductId = (int)id;
            newVote.UserId = user.Id;
            _context.Votes.Add(newVote);
            _context.SaveChanges();

            product.VoteAmount += 1;
            _context.Products.Update(product);
            _context.SaveChanges();

            TempData["success"] = "Bạn đã vote thành công cho tác phẩm: " + product.ProductName;

            return Ok();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = _context.Products.FirstOrDefault(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            var group = _context.GroupUsers;
            ViewBag.Group = group.ToList();

            var vote = _context.Votes.ToList();
            ViewBag.Vote = vote.ToList();

            return PartialView("VotingProductInforPartial", product);

        }
    }
}
