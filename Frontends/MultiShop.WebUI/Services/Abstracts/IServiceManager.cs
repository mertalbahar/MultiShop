using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.CommentServices.ContactServices;
using MultiShop.WebUI.Services.CommentServices.UserCommentServices;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.IdentityServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUI.Services.Abstracts
{
    public interface IServiceManager
    {
        // Catalog Microservice
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
        IAboutService AboutService { get; }
        IBrandService BrandService { get; }
        IFeatureSliderService FeatureSliderService { get; }
        IDiscountOfferService DiscountOfferService { get; }
        ISpecialOfferService SpecialOfferService { get; }
        IProductDetailService ProductDetailService { get; }
        IProductImageService ProductImageService { get; }

        // Comment Microservice
        IUserCommentService UserCommentService { get; }
        IContactService ContactService { get; }

        // Identity Microservice
        IUserService UserService { get; }

        // Basket Microservice
        IBasketService BasketService { get; }

        // Discount Microservice
        IDiscountService DiscountService { get; }

        // Order Microservice
        IOrderAddressService OrderAddressService { get; }
        IOrderingService OrderingService { get; }
    }
}
