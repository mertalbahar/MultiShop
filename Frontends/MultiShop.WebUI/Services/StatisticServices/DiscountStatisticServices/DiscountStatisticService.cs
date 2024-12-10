
namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public class DiscountStatisticService : IDiscountStatisticService
    {
        private readonly HttpClient _httpClient;

        public DiscountStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCountAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getDiscountCouponCount");
            int result = await responseMessage.Content.ReadFromJsonAsync<int>();

            return result;
        }
    }
}
