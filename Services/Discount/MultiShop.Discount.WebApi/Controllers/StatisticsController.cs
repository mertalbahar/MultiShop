using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.WebApi.Services;

namespace MultiShop.Discount.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("getDiscountCouponCount")]
        public async Task<IActionResult> GetDiscountCouponCount()
        {
            int values = await _statisticService.GetDiscountCouponCount();

            return Ok(values);
        }
    }
}
