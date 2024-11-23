using MultiShop.DtoLayer.IdentityDtos;

namespace MultiShop.WebUI.Services.IdentityServices
{
    public interface IUserService
    {
        Task<UserDetailDto> GetUserDetailAsync();
        Task<List<ResultUserDto>> GetUserListAsync();
    }
}
