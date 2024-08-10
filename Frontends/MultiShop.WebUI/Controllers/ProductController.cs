using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            createUserCommentDto.CreatedDate = DateTime.Now;

            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createUserCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:7075/api/UserComments/create", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
