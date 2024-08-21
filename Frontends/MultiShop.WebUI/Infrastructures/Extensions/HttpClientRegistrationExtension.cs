using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.Concretes;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Infrastructures.Extensions
{
    public static class HttpClientRegistrationExtension
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient();
            services.AddHttpClient<IClientCredentialsTokenService, ClientCredentialsTokenService>();

            services.AddHttpClient<ICategoryService, CategoryService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            return services;
        }
    }
}
