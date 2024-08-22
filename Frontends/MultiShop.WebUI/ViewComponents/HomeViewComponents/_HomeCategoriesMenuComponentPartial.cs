using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _HomeCategoriesMenuComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeCategoriesMenuComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _manager.CategoryService.GetAllCategoriesAsync();

            return View(values);
        }
    }
}
