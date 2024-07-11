using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/Products");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        private async Task<SelectList> GetCategoriesSelectList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/Categories");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                List<SelectListItem> categoryValues = (from x in values
                                                       select new SelectListItem
                                                       {
                                                           Text = x.Name,
                                                           Value = x.Id
                                                       }).ToList();

                return new SelectList(categoryValues, "Value", "Text");
            }

            return new SelectList(new List<SelectListItem>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = await GetCategoriesSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto createProductDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:7070/api/Products/create", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }

        public async Task<IActionResult> DeleteProduct([FromRoute(Name = "id")] string id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7070/api/Products/delete/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct([FromRoute(Name = "id")] string id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/Products/" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                ViewBag.Categories = await GetCategoriesSelectList();

                return View(values);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDto updateProductDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://localhost:7070/api/Products/update", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }
    }
}
