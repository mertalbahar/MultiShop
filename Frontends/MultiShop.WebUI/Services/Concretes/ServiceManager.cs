using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IClientCredentialsTokenService> _clientCredentialsTokenService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IClientCredentialsTokenService clientCredentialsTokenService,
            ICategoryService categoryService, IProductService productService)
        {
            _clientCredentialsTokenService = new Lazy<IClientCredentialsTokenService>(() => clientCredentialsTokenService);
            _categoryService = new Lazy<ICategoryService>(() => categoryService);
            _productService = new Lazy<IProductService>(() => productService);
        }

        public IClientCredentialsTokenService ClientCredentialsTokenService => _clientCredentialsTokenService.Value;
        public ICategoryService CategoryService => _categoryService.Value;

        public IProductService ProductService => _productService.Value;
    }
}
