using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HomeDiscountOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeDiscountOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7070/api/DiscountOffers");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountOfferDto>>(jsonData);

                var random = new Random();
                var result = values.OrderBy(x => random.Next()).Take(2).ToList();

                return View(result);
            }

            return View();
        }
    }
}
