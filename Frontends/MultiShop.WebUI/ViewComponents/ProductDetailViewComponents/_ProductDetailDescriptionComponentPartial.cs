using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _ProductDetailDescriptionComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            GetByIdProductDetailDto values = await _manager.ProductDetailService.GetProductDetailByProductIdAsync(id);

            return View(values);
        }
    }
}
