using MultiShop.WebUI.Services.Abstracts;
using System.Net.Http.Headers;
using System.Net;

namespace MultiShop.WebUI.Handlers
{
    public class ClientCredentialsTokenHandler :DelegatingHandler
    {
        private readonly IClientCredentialsTokenService _clientCredentialTokenService;

        public ClientCredentialsTokenHandler(IClientCredentialsTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                // Error Message
            }

            return response;
        }
    }
}
