using MultiShop.DtoLayer.CommentDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CommentServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactsAsync();
        Task<GetByIdContactDto> GetContactByIdAsync(int id);
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(int id);
    }
}
