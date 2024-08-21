using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Services.Abstracts
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
    }
}
