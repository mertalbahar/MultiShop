using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountCouponController : Controller
    {
        private readonly IServiceManager _manager;

        public DiscountCouponController(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultDiscountCouponDto> values = await _manager.DiscountService.GetAllDiscountCouponAsync();

            return View(values);
        }
    }
}
