using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxUserMessageDto>> GetAllInboxMessagesAsync(string receiverId)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("usermessages/inboxMessage?id=" + receiverId);
            List<ResultInboxUserMessageDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxUserMessageDto>>();

            return result;
        }
    }
}
