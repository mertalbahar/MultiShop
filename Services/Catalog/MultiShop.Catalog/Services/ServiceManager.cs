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
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IAboutService _aboutService;
        private readonly IBrandService _brandService;
        private readonly IDiscountOfferService _discountOfferService;
        private readonly IFeatureSliderService _featureSliderService;
        private readonly IProductDetailService _productDetailService;
        private readonly ProductImageServices.IProductImageService _productImageService;
        private readonly ISpecialOfferService _specialOfferService;

        public ServiceManager(ICategoryService categoryService, IProductService productService, IAboutService aboutService,
            IBrandService brandService, IDiscountOfferService discountOfferService, IFeatureSliderService featureSliderService,
            IProductDetailService productDetailService, ProductImageServices.IProductImageService productImageService, ISpecialOfferService specialOfferService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _aboutService = aboutService;
            _brandService = brandService;
            _discountOfferService = discountOfferService;
            _featureSliderService = featureSliderService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
            _specialOfferService = specialOfferService;
        }

        public ICategoryService CategoryService => _categoryService;

        public IProductService ProductService => _productService;

        public IAboutService AboutService => _aboutService;

        public IBrandService BrandService => _brandService;

        public IDiscountOfferService DiscountOfferService => _discountOfferService;

        public IFeatureSliderService FeatureSliderService => _featureSliderService;

        public IProductDetailService ProductDetailService => _productDetailService;

        public ProductImageServices.IProductImageService ProductImageService => _productImageService;

        public ISpecialOfferService SpecialOfferService => _specialOfferService;
    }
}
