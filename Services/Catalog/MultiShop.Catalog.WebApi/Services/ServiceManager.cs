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
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IAboutService _aboutService;
        private readonly IBrandService _brandService;
        private readonly IDiscountOfferService _discountOfferService;
        private readonly IFeatureSliderService _featureSliderService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;
        private readonly ISpecialOfferService _specialOfferService;
        private readonly IStatisticService _statisticService;

        public ServiceManager(ICategoryService categoryService, IProductService productService, IAboutService aboutService,
            IBrandService brandService, IDiscountOfferService discountOfferService, IFeatureSliderService featureSliderService,
            IProductDetailService productDetailService, IProductImageService productImageService, ISpecialOfferService specialOfferService,
            IStatisticService statisticService)
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
            _statisticService = statisticService;
        }

        public ICategoryService CategoryService => _categoryService;

        public IProductService ProductService => _productService;

        public IAboutService AboutService => _aboutService;

        public IBrandService BrandService => _brandService;

        public IDiscountOfferService DiscountOfferService => _discountOfferService;

        public IFeatureSliderService FeatureSliderService => _featureSliderService;

        public IProductDetailService ProductDetailService => _productDetailService;

        public IProductImageService ProductImageService => _productImageService;

        public ISpecialOfferService SpecialOfferService => _specialOfferService;

        public IStatisticService StatisticService => _statisticService;
    }
}
