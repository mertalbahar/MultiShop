using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HomeCategoriesComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeCategoriesComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _manager.CategoryService.GetAllCategoriesAsync();

            var random = new Random();
            var result = values.OrderBy(x => random.Next()).Take(12).ToList();

            return View(result);
        }
    }
}
