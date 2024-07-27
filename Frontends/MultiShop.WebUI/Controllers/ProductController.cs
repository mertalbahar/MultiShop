using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index([FromRoute(Name = "id")] string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
