using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IClientCredentialsTokenService> _clientCredentialsTokenService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IAboutService> _aboutService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IFeatureSliderService> _featureSliderService;
        private readonly Lazy<IDiscountOfferService> _discountOfferService;

        public ServiceManager(IClientCredentialsTokenService clientCredentialsTokenService,
            ICategoryService categoryService, IProductService productService, IAboutService aboutService,
            IBrandService brandService, IFeatureSliderService featureSliderService, IDiscountOfferService discountOfferService)
        {
            _clientCredentialsTokenService = new Lazy<IClientCredentialsTokenService>(() => clientCredentialsTokenService);
            _categoryService = new Lazy<ICategoryService>(() => categoryService);
            _productService = new Lazy<IProductService>(() => productService);
            _aboutService = new Lazy<IAboutService>(() => aboutService);
            _brandService = new Lazy<IBrandService>(() => brandService);
            _featureSliderService = new Lazy<IFeatureSliderService>(() => featureSliderService);
            _discountOfferService = new Lazy<IDiscountOfferService>(() => discountOfferService);
        }

        public IClientCredentialsTokenService ClientCredentialsTokenService => _clientCredentialsTokenService.Value;
        public ICategoryService CategoryService => _categoryService.Value;

        public IProductService ProductService => _productService.Value;

        public IAboutService AboutService => _aboutService.Value;

        public IBrandService BrandService => _brandService.Value;

        public IFeatureSliderService FeatureSliderService => _featureSliderService.Value;

        public IDiscountOfferService DiscountOfferService => _discountOfferService.Value;
    }
}
