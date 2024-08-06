using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/ProductDetails");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);

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
                List<SelectListItem> ProductValues = (from x in values
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.Id
                                                      }).ToList();

                return new SelectList(ProductValues, "Value", "Text");
            }

            return new SelectList(new List<SelectListItem>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductDetail()
        {
            ViewBag.Products = await GetProductsSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductDetail([FromForm] CreateProductDetailDto createProductDetailDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:7070/api/ProductDetails/create", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
            }

            return View();
        }

        public async Task<IActionResult> DeleteProductDetail([FromRoute(Name = "id")] string id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7070/api/ProductDetails/delete/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string productId)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/ProductDetails/productId?id=" + productId);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                ViewBag.Products = await GetProductsSelectList();

                return View(values);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductDetail([FromForm] UpdateProductDetailDto updateProductDetailDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://localhost:7070/api/ProductDetails/update", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }
    }
}
