using MultiShop.Catalog.WebApi.Services.AboutServices;
using MultiShop.Catalog.WebApi.Services.BrandServices;
using MultiShop.Catalog.WebApi.Services.CategoryServices;
using MultiShop.Catalog.WebApi.Services.DiscountOfferServices;
using MultiShop.Catalog.WebApi.Services.FeatureSliderServices;
using MultiShop.Catalog.WebApi.Services.ProductDetailServices;
using MultiShop.Catalog.WebApi.Services.ProductImageServices;
using MultiShop.Catalog.WebApi.Services.ProductServices;
using MultiShop.Catalog.WebApi.Services.SpecialOfferServices;
using MultiShop.Catalog.WebApi.Services.StatisticServices;

namespace MultiShop.Catalog.WebApi.Services
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
        IAboutService AboutService { get; }
        IBrandService BrandService { get; }
        IDiscountOfferService DiscountOfferService { get; }
        IFeatureSliderService FeatureSliderService { get; }
        IProductDetailService ProductDetailService { get; }
        IProductImageService ProductImageService { get; }
        ISpecialOfferService SpecialOfferService { get; }
        IStatisticService StatisticService { get; }
    }
}
