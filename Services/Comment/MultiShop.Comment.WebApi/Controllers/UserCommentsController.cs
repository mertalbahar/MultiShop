using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.WebApi.Dtos.UserCommentDtos;
using MultiShop.Comment.WebApi.Services.Abstracts;

namespace MultiShop.Comment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UserCommentsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult UserCommentList()
        {
            IEnumerable<ResultUserCommentDto> values = _manager.UserCommentService.GetAllUserComments();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserCommentById(int id)
        {
            GetByIdUserCommentDto value = _manager.UserCommentService.GetUserCommentById(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public IActionResult CreateUserComment(CreateUserCommentDto createUserCommentDto)
        {
            _manager.UserCommentService.CreateUserComment(createUserCommentDto);

            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUserComment(int id)
        {
            _manager.UserCommentService.DeleteUserComment(id);

            return Ok("Yorum başarıyla silindi.");
        }

        [HttpPut("update")]
        public IActionResult UpdateUserComment(UpdateUserCommentDto updateUserCommentDto)
        {
            _manager.UserCommentService.UpdateUserComment(updateUserCommentDto);

            return Ok("Yorum başarıyla güncellendi.");
        }

        [HttpGet("productId")]
        public IActionResult UserCommentListByProductId(string id)
        {
            IEnumerable<ResultUserCommentDto> values = _manager.UserCommentService.GetyUserCommentByProductId(id);

            return Ok(values);
        }
    }
}
