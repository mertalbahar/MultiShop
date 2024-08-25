using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromRoute(Name = "id")] string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult ProductDetail([FromRoute(Name = "id")] string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(CreateUserCommentDto createUserCommentDto)
        {
            await _manager.UserCommentService.CreateUserCommentAsync(createUserCommentDto);

            return RedirectToAction("Index", "Home");
        }
    }
}
