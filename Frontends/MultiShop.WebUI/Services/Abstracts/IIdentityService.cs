using MultiShop.DtoLayer.IdentityDtos;

namespace MultiShop.WebUI.Services.Abstracts
{
    public interface IIdentityService
    {
        Task<bool> GetRefreshToken();
        Task<bool> SignIn(UserLoginDto userLoginDto);
    }
}
