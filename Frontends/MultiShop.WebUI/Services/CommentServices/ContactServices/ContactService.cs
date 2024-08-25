using MultiShop.DtoLayer.CommentDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CommentServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts/create", createContactDto);
        }

        public async Task DeleteContactAsync(int id)
        {
            await _httpClient.DeleteAsync("contacts/delete/" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("contacts");
            List<ResultContactDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();

            return result;
        }

        public async Task<GetByIdContactDto> GetContactByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("contacts/" + id);
            GetByIdContactDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();

            return result;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts/update", updateContactDto);
        }
    }
}
