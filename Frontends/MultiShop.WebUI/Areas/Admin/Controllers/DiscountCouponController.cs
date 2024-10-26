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

        [HttpGet]
        public IActionResult CreateDiscountCoupon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDiscountCoupon([FromForm] CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _manager.DiscountService.CreateDiscountCouponAsync(createDiscountCouponDto);

            return RedirectToAction("Index", "DiscountCoupon", new { area = "Admin" });
        }
    }
}
