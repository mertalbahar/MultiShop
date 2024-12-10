using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.WebApi.Services;

namespace MultiShop.Catalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public StatisticsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("getBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _manager.StatisticService.GetBrandCount();

            return Ok(value);
        }

        [HttpGet("getCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var value = await _manager.StatisticService.GetCategoryCount();

            return Ok(value);
        }

        [HttpGet("getProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var value = await _manager.StatisticService.GetProductCount();

            return Ok(value);
        }

        [HttpGet("getProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var value = await _manager.StatisticService.GetProductAvgPrice();

            return Ok(value);
        }

        [HttpGet("getMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var value = await _manager.StatisticService.GetMaxPriceProductName();

            return Ok(value);
        }

        [HttpGet("getMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var value = await _manager.StatisticService.GetMinPriceProductName();

            return Ok(value);
        }
    }
}
