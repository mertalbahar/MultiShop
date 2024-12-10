using MultiShop.Catalog.WebApi.Services.AboutServices;
using MultiShop.Catalog.WebApi.Services.BrandServices;
using MultiShop.Catalog.WebApi.Services.CategoryServices;
using MultiShop.Catalog.WebApi.Services.DiscountOfferServices;
using MultiShop.Catalog.WebApi.Services.FeatureSliderServices;
using MultiShop.Catalog.WebApi.Services.ProductDetailServices;
using MultiShop.Catalog.WebApi.Services.ProductImageServices;
using MultiShop.Catalog.WebApi.Services.ProductServices;
using MultiShop.Catalog.WebApi.Services.SpecialOfferServices;
using MultiShop.Catalog.WebApi.Services;
using MultiShop.Catalog.WebApi.Services.StatisticServices;

namespace MultiShop.Catalog.WebApi.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            services.AddScoped<ISpecialOfferService, SpecialOfferService>();
            services.AddScoped<IDiscountOfferService, DiscountOfferService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IStatisticService, StatisticService>();
        }
    }
}
