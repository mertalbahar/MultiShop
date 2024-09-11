using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _ShoppingCartComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            BasketTotalDto values = await _manager.BasketService.GetBasket();
            List<BasketItemDto> result = values.BasketItems;

            return View(result);
        }
    }
}
