using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/DiscountOffers");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountOfferDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateDiscountOffer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:7070/api/DiscountOffers/create", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscountOffer([FromRoute(Name = "id")] string id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/DiscountOffers/" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountOfferDto>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDiscountOffer([FromForm] UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://localhost:7070/api/DiscountOffers/update", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }

            return View();
        }

        public async Task<IActionResult> DeleteDiscountOffer([FromRoute(Name = "id")] string id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:7070/api/DiscountOffers/delete/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }

            return RedirectToAction("Index");
        }
    }
}
