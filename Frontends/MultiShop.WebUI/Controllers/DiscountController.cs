using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IServiceManager _manager;

        public DiscountController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public PartialViewResult ApplyCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(string code)
        {
            var values = await _manager.DiscountService.GetByCodeDiscountCouponAsync(code);
            var discountRate = values.Rate;

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = discountRate });
        }
    }
}
