using MultiShop.Comment.Dtos.ContactDtos;

namespace MultiShop.Comment.Services.Abstracts
{
    public interface IContactService
    {
        IEnumerable<ResultContactDto> GetAllContacts();
        GetByIdContactDto GetContactById(int id);
        void CreateContact(CreateContactDto createContactDto);
        void UpdateContact(UpdateContactDto updateContactDto);
        void DeleteContact(int id);
    }
}
