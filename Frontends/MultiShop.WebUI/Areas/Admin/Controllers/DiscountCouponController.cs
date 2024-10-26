using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountCouponController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public DiscountCouponController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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

        [HttpGet]
        public async Task<IActionResult> UpdateDiscountCoupon(int id)
        {
            GetByIdDiscountCouponDto values = await _manager.DiscountService.GetByIdDiscountCouponAsync(id);
            UpdateDiscountCouponDto result = _mapper.Map<UpdateDiscountCouponDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDiscountCoupon([FromForm] UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _manager.DiscountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);

            return RedirectToAction("Index", "DiscountCoupon", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteDiscountCoupon([FromRoute(Name = "id")] int id)
        {
            await _manager.DiscountService.DeleteDiscountCouponAsync(id);

            return RedirectToAction("Index", "DiscountCoupon", new { area = "Admin" });
        }
    }
}
