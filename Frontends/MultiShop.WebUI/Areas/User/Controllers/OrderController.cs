using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.DtoLayer.OrderDtos.OrderingDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            UserDetailDto user = await _manager.UserService.GetUserDetailAsync();
            List<ResultOrderingDto> values = await _manager.OrderingService.GetOrderingByUserIdAsync(user.Id);

            return View(values);
        }
    }
}
