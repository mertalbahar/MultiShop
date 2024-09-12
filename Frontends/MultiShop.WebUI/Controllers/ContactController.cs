using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.ContactDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IServiceManager _manager;

        public ContactController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.CreatedDate = DateTime.Now;

            await _manager.ContactService.CreateContactAsync(createContactDto);

            return RedirectToAction("Index", "Home");
        }
    }
}
