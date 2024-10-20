using MultiShop.DtoLayer.IdentityDtos;

namespace MultiShop.WebUI.Services.IdentityServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailDto> GetUserDetailAsync()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailDto>("/api/Users/getuserdetail");
        }
    }
}
