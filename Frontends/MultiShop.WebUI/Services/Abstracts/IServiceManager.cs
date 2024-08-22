using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Services.Abstracts
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
        IAboutService AboutService { get; }
    }
}
