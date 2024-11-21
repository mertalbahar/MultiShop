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

        public async Task<GetByIdUserMessageDto> GetByIdUserMessageAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("usermessages/" + id);
            GetByIdUserMessageDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdUserMessageDto>();

            return result;
        }

        public async Task UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateUserMessageDto>("usermessages/update", updateUserMessageDto);
        }
    }
}
