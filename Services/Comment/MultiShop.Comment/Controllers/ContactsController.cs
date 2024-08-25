using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Dtos.ContactDtos;
using MultiShop.Comment.Services.Abstracts;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ContactsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            IEnumerable<ResultContactDto> values = _manager.ContactService.GetAllContacts();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            GetByIdContactDto value = _manager.ContactService.GetContactById(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _manager.ContactService.CreateContact(createContactDto);

            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            _manager.ContactService.DeleteContact(id);

            return Ok("Yorum başarıyla silindi.");
        }

        [HttpPut("update")]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _manager.ContactService.UpdateContact(updateContactDto);

            return Ok("Yorum başarıyla güncellendi.");
        }
    }
}
