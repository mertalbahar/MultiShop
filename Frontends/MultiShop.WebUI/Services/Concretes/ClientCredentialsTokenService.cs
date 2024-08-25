using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concretes
{
    public class ClientCredentialsTokenService : IClientCredentialsTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialsTokenService(HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache,
            IOptions<ServiceApiSettings> serviceApiSettings, IOptions<ClientSettings> clientSettings)
        {
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _serviceApiSettings = serviceApiSettings.Value;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            ClientAccessToken token1 = await _clientAccessTokenCache.GetAsync("multishoptoken");

            if (token1 != null)
            {
                return token1.AccessToken;
            }

            DiscoveryDocumentResponse discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl
            });

            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            TokenResponse token2 = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);

            await _clientAccessTokenCache.SetAsync("multishoptoken", token2.AccessToken, token2.ExpiresIn);

            return token2.AccessToken;
        }
    }
}
