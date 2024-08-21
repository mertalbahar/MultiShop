using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.Concretes;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Infrastructures.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
            services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ClientCredentialsTokenHandler>();

            return services;
        }
    }
}
