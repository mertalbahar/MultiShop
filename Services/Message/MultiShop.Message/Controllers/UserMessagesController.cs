using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Business.Abstract;
using MultiShop.Message.Dto.Dtos;

namespace MultiShop.Message.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UserMessagesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> UserMessageList()
        {
            List<ResultUserMessageDto> values = await _manager.UserMessageService.GetAllUserMessageAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMessageById(int id)
        {
            GetByIdUserMessageDto value = await _manager.UserMessageService.GetByIdUserMessageAsync(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserMessage(CreateUserMessageDto createUserMessageDto)
        {
            await _manager.UserMessageService.CreateUserMessageAsync(createUserMessageDto);

            return Ok("Kullanıcı mesajı başarıyla oluşturuldu.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserMessage(UpdateUserMessageDto updateUserMessageDto)
        {
            await _manager.UserMessageService.UpdateUserMessageAsync(updateUserMessageDto);

            return Ok("Kullanıcı mesajı başarıyla güncellendi.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoveUserMessage(int id)
        {
            await _manager.UserMessageService.DeleteUserMessageAsync(id);

            return Ok("Kullanıcı mesajı başarıyla silindi.");
        }

        [HttpGet("sendboxMessage")]
        public async Task<IActionResult> UserMessageSendboxList(string id)
        {
            List<ResultSendboxUserMessageDto> values = await _manager.UserMessageService.GetSendboxUserMessageAsync(id);

            return Ok(values);
        }

        [HttpGet("inboxMessage")]
        public async Task<IActionResult> UserMessageInboxList(string id)
        {
            List<ResultInboxUserMessageDto> values = await _manager.UserMessageService.GetInboxUserMessageAsync(id);

            return Ok(values);
        }
    }
}
