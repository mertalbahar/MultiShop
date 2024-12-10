
namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCountAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("/api/Statistics/getUserCount");
            int result = await responseMessage.Content.ReadFromJsonAsync<int>();

            return result;
        }
    }
}
