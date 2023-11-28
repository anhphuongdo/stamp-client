using Microsoft.AspNetCore.Mvc;

namespace BIT_STAMP.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult AddProduct() 
        {
            return View();
        }
        public IActionResult EditProduct()
        {
            return View();
        }
        public IActionResult DeleteProduct()
        {
            return View();
        }
    }
}
