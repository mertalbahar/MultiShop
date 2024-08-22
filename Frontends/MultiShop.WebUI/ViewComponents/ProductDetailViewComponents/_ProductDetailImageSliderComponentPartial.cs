using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _ProductDetailImageSliderComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            GetByIdProductImageDto values = await _manager.ProductImageService.GetProductImageByProductIdAsync(id);

            return View(values);
        }
    }
}
