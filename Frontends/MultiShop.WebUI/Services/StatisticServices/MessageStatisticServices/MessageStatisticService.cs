
namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getTotalMessageCount");
            int result = await responseMessage.Content.ReadFromJsonAsync<int>();

            return result;
        }
    }
}
