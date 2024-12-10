using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Business.Abstract;

namespace MultiShop.Message.WebApi.Controllers
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

        [HttpGet("getTotalMessageCountAsync")]
        public async Task<IActionResult> GetTotalMessageCountAsync()
        {
            int value = await _manager.StatisticService.GetTotalMessageCountAsync();

            return Ok(value);
        }
    }
}
