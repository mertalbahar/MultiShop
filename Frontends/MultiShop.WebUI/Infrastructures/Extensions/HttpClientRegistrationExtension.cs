using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
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
            
            services.AddHttpClient<IProductService, ProductService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();
            
            services.AddHttpClient<IAboutService, AboutService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();
            
            services.AddHttpClient<IBrandService, BrandService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();
            
            services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();
            
            services.AddHttpClient<IDiscountOfferService, DiscountOfferService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialsTokenHandler>();

            return services;
        }
    }
}
