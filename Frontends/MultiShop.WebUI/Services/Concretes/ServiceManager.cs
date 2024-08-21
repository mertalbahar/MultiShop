using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IClientCredentialsTokenService> _clientCredentialsTokenService;
        private readonly Lazy<ICategoryService> _categoryService;

        public ServiceManager(IClientCredentialsTokenService clientCredentialsTokenService, ICategoryService categoryService)
        {
            _clientCredentialsTokenService = new Lazy<IClientCredentialsTokenService>(() => clientCredentialsTokenService);
            _categoryService = new Lazy<ICategoryService>(() => categoryService);
        }

        public IClientCredentialsTokenService ClientCredentialsTokenService => _clientCredentialsTokenService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
    }
}
