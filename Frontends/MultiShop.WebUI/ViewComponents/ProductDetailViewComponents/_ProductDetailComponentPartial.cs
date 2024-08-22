using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _ProductDetailComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            GetByIdProductDto values = await _manager.ProductService.GetProductByIdAsync(id);

            return View(values);
        }
    }
}
