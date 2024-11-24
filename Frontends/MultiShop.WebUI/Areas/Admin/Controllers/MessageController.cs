using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.DtoLayer.MessageDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public MessageController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Inbox()
        {
            UserDetailDto user = await _manager.UserService.GetUserDetailAsync();
            List<ResultInboxUserMessageDto> values = await _manager.MessageService.GetAllInboxMessagesAsync(user.Id);

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> InboxMessageDetail([FromRoute(Name = "id")] int id)
        {
            GetByIdUserMessageDto values = await _manager.MessageService.GetByIdUserMessageAsync(id);
            UpdateUserMessageDto result = _mapper.Map<UpdateUserMessageDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InboxMessageDetail([FromForm] UpdateUserMessageDto updateUserMessageDto)
        {
            await _manager.MessageService.UpdateUserMessageAsync(updateUserMessageDto);

            return RedirectToAction("Inbox", "Message", new { area = "Admin" });
        }

        public async Task<IActionResult> Sendbox()
        {
            UserDetailDto user = await _manager.UserService.GetUserDetailAsync();
            List<ResultSendboxUserMessageDto> values = await _manager.MessageService.GetAllSendboxMessagesAsync(user.Id);

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> SendboxMessageDetail([FromRoute(Name = "id")] int id)
        {
            GetByIdUserMessageDto values = await _manager.MessageService.GetByIdUserMessageAsync(id);

            return View(values);
        }
    }
}
