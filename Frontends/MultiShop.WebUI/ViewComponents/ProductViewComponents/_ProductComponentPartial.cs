using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _ProductComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync([FromRoute(Name = "id")] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                List<ResultProductDto> values = await _manager.ProductService.GetAllProductsAsync();
                return View(values);
            }
            else
            {
                List<ResultProductDto> values = await _manager.ProductService.GetProductsByCategoryIdAsync(id);
                return View(values);
            }
        }
    }
}
