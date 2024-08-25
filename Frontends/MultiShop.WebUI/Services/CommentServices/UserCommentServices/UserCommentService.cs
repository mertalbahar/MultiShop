using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;

namespace MultiShop.WebUI.Services.CommentServices.UserCommentServices
{
    public class UserCommentService : IUserCommentService
    {
        private readonly HttpClient _httpClient;

        public UserCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateUserCommentDto>("usercomments/create", createUserCommentDto);
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            await _httpClient.DeleteAsync("usercomments/delete/" + id);
        }

        public async Task<List<ResultUserCommentDto>> GetAllUserCommentsAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("usercomments");
            List<ResultUserCommentDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserCommentDto>>();

            return result;
        }

        public async Task<GetByIdUserCommentDto> GetUserCommentByIdAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("usercomments/" + id);
            GetByIdUserCommentDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdUserCommentDto>();

            return result;
        }

        public async Task<List<ResultUserCommentDto>> GetyUserCommentByProductIdAsync(string productId)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("usercomments/productId?id=" + productId);
            List<ResultUserCommentDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserCommentDto>>();

            return result;
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateUserCommentDto>("usercomments/update", updateUserCommentDto);
        }
    }
}
