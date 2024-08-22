using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HomeFeaturedProductsComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeFeaturedProductsComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _manager.ProductService.GetAllProductsAsync();

            var random = new Random();
            var result = values.OrderBy(x => random.Next()).Take(8).ToList();

            return View(result);
        }
    }
}
