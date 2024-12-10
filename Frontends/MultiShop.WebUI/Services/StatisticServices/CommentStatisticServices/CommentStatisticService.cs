
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCountAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getActiveCommentCount");
            int result = await responseMessage.Content.ReadFromJsonAsync<int>();

            return result;
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getPassiveCommentCount");
            int result = await responseMessage.Content.ReadFromJsonAsync<int>();

            return result;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getTotalCommentCount");
            int result = await responseMessage.Content.ReadFromJsonAsync<int>();

            return result;
        }
    }
}
