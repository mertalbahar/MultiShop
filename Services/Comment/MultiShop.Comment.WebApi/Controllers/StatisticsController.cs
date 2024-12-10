using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.WebApi.Services.Abstracts;

namespace MultiShop.Comment.WebApi.Controllers
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

        [HttpGet("getActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int value = _manager.StatisticService.GetActiveCommentCount();

            return Ok(value);
        }
        
        [HttpGet("getPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            int value = _manager.StatisticService.GetPassiveCommentCount();

            return Ok(value);
        }

        [HttpGet("getTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            int value = _manager.StatisticService.GetTotalCommentCount();

            return Ok(value);
        }
    }
}
