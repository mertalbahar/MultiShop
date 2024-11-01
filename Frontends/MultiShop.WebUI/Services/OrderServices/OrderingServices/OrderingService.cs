using MultiShop.DtoLayer.OrderDtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingDto>> GetOrderingByUserIdAsync(string userId)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("orderings/userId?id=" + userId);
            List<ResultOrderingDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();

            return result;
        }
    }
}
