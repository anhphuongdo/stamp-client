using BIT_STAMP.Data;
using BIT_STAMP.Models;
using BIT_STAMP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BIT_STAMP.Controllers
{
    public class RankingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public RankingController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Ranking(string? currentFilter, string? searchString, int page = 1)
        {
            var product = _context.Products.OrderByDescending(m => m.VoteAmount).ToList();
            
            var group = _context.GroupUsers;
            ViewBag.Group = group.ToList();

            int pageSize = 9;
            var ranking = (page - 1) * pageSize;
            ViewBag.Rankings = ranking;

            var members = _context.Relationships.Include(m => m.us);
            ViewBag.Members = members.ToList();
            if (searchString != null)
            {
                page = 1;
                List<int> rank = new List<int>();
                var listProduct = _context.Products.Where(m => m.ProductName.Trim().ToLower().Contains(searchString.Trim().ToLower())).OrderByDescending(m => m.VoteAmount).ToList();
                for (int i = 0; i < listProduct.Count; i++)
                {
                    for (int j = 0; j < product.Count; j++)
                    {
                        if (listProduct[i].ProductId == product[j].ProductId)
                        {
                            rank.Add(j+1);
                            break;
                        }
                    }                    
                }
                ViewBag.SearchRank = rank;
                ViewBag.SearchProduct = listProduct.ToList();
            }
            else
            {
                searchString = currentFilter;
                List<Product> products = new List<Product>();
                ViewBag.SearchProduct = products;
            }
            ViewData["CurrentFilter"] = searchString;

            var vote = _context.Votes.ToList();
            ViewBag.Vote = vote.ToList();
            
            var top20 = _context.Products.OrderByDescending(m => m.VoteAmount).Take(20).ToList();
            ViewBag.Top20 = top20.ToList();

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
                /*TempData["error"] = "Tác phẩm không tồn tại";*/
                return Ok();
            }
            var vote = _context.Votes.FirstOrDefault(m => m.ProductId == id && m.UserId.Equals(user.Id));
            if (vote != null)
            {
                /*TempData["error"] = "Bạn đã bình chọn cho tác phẩm này rồi";*/
                return Ok();
            }

            Vote newVote = new Vote();
            newVote.ProductId = (int)id;
            newVote.UserId = user.Id;
            _context.Votes.Add(newVote);
            await _context.SaveChangesAsync();

            product.VoteAmount += 1;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            /*TempData["success"] = "Bạn đã vote thành công cho tác phẩm: " + product.ProductName;*/

            return Ok();
        }

        public async Task<IActionResult> Details(int? id)
        {
            var product = _context.Products.FirstOrDefault(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            var group = _context.GroupUsers;
            ViewBag.Group = group.ToList();            

            return PartialView("RankingProductInforPartial", product);
        }
    }
}
