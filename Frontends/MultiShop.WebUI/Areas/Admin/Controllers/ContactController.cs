using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.ContactDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public ContactController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultContactDto> values = await _manager.ContactService.GetAllContactsAsync();

            return View(values);
        }

        public async Task<IActionResult> DeleteContact([FromRoute(Name = "id")] int id)
        {
            await _manager.ContactService.DeleteContactAsync(id);

            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact([FromRoute(Name = "id")] int id)
        {
            GetByIdContactDto values = await _manager.ContactService.GetContactByIdAsync(id);
            UpdateContactDto result = _mapper.Map<UpdateContactDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateContact([FromForm] UpdateContactDto updateContactDto)
        {
            await _manager.ContactService.UpdateContactAsync(updateContactDto);

            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }
    }
}
