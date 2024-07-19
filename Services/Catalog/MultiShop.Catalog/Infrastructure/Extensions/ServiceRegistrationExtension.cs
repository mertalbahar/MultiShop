using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.DiscountOfferServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;
using MultiShop.Catalog.Services;

namespace MultiShop.Catalog.Infrastructure.Extensions
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
        }
    }
}
