namespace MultiShop.WebUI.Services.Abstracts
{
    public interface IClientCredentialsTokenService
    {
        Task<string> GetToken();
    }
}
