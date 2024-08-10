using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7075/api/UserComments");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        private async Task<SelectList> GetProductsSelectList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/Products");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                List<SelectListItem> productValues = (from x in values
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.Id
                                                       }).ToList();

                return new SelectList(productValues, "Value", "Text");
            }

            return new SelectList(new List<SelectListItem>());
        }

        public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] string id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7075/api/UserComments/delete/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "UserComment", new { area = "Admin" });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserComment([FromRoute(Name = "id")] string id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7075/api/UserComments/" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserCommentDto>(jsonData);
                ViewBag.Products = await GetProductsSelectList();

                return View(values);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserComment([FromForm] UpdateUserCommentDto updateUserCommentDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateUserCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://localhost:7075/api/UserComments/update", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "UserComment", new { area = "Admin" });
            }

            return View();
        }
    }
}
