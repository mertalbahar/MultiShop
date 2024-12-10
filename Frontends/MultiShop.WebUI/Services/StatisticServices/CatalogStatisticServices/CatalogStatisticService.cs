
namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getBrandCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<long>();

            return result;
        }

        public async Task<long> GetCategoryCount()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getCategoryCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<long>();

            return result;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getMaxPriceProductName");
            var result = await responseMessage.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetMinPriceProductName()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getMinPriceProductName");
            var result = await responseMessage.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getProductAvgPrice");
            var result = await responseMessage.Content.ReadFromJsonAsync<decimal>();

            return result;
        }

        public async Task<long> GetProductCount()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getProductCount");
            var result = await responseMessage.Content.ReadFromJsonAsync<long>();

            return result;
        }
    }
}
