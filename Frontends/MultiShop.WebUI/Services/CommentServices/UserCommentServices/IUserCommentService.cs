using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;

namespace MultiShop.WebUI.Services.CommentServices.UserCommentServices
{
    public interface IUserCommentService
    {
        Task<List<ResultUserCommentDto>> GetAllUserCommentsAsync();
        Task<GetByIdUserCommentDto> GetUserCommentByIdAsync(int id);
        Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto);
        Task DeleteUserCommentAsync(int id);
        Task<List<ResultUserCommentDto>> GetyUserCommentByProductIdAsync(string id);
    }
}
