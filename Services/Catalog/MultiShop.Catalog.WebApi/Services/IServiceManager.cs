using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.DiscountOfferServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Services
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
        ProductImageServices.IProductImageService ProductImageService { get; }
        ISpecialOfferService SpecialOfferService { get; }
    }
}
