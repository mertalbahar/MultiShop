using AutoMapper;
using MultiShop.Comment.Dtos.ContactDtos;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Repositories.Abstracts;
using MultiShop.Comment.Services.Abstracts;

namespace MultiShop.Comment.Services.Concretes
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ContactService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = _mapper.Map<Contact>(createContactDto);
            _manager.Contact.Create(contact);
            _manager.Save();
        }

        public void DeleteContact(int id)
        {
            GetByIdContactDto contact = GetContactById(id);
            Contact result = _mapper.Map<Contact>(contact);

            if (result is not null)
            {
                _manager.Contact.Delete(result);
                _manager.Save();
            }
        }

        public IEnumerable<ResultContactDto> GetAllContacts()
        {
            IQueryable<Contact> contact = _manager.Contact.FindAll();
            IEnumerable<ResultContactDto> result = _mapper.Map<IEnumerable<ResultContactDto>>(contact);

            return result;
        }

        public GetByIdContactDto GetContactById(int id)
        {
            Contact? contact = _manager.Contact.FindByCondition(x => x.Id.Equals(id));
            GetByIdContactDto result = _mapper.Map<GetByIdContactDto>(contact);

            return result;
        }

        public void UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = _mapper.Map<Contact>(updateContactDto);
            _manager.Contact.Update(contact);
            _manager.Save();
        }
    }
}
