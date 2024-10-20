using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartSummaryComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _ShoppingCartSummaryComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            BasketTotalDto values = await _manager.BasketService.GetBasket();
            var taxPrice = values.TotalPrice * 18 / 100;
            ViewBag.TaxPrice = taxPrice;
            var cartTotal = values.TotalPrice + taxPrice;

            if (ViewBag.DiscountRate != null)
            {
                var discountRate = ViewBag.DiscountRate;
                var discountPrice = cartTotal * discountRate / 100;
                ViewBag.DiscountPrice = discountPrice;
                cartTotal -= discountPrice;
            }
            ViewBag.cartTotal = cartTotal;

            return View(values);
        }
    }
}
