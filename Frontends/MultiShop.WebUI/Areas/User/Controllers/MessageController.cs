using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.DtoLayer.MessageDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IServiceManager _manager;

        public MessageController(IServiceManager manager)
        {
            _manager = manager;
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

            return View(values);
        }
    }
}
