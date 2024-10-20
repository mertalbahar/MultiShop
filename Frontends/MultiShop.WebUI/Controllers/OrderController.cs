using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.DtoLayer.OrderDtos.AddressDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            UserDetailDto user = await _manager.UserService.GetUserDetailAsync();
            createOrderAddressDto.UserId = user.Id;

            await _manager.OrderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Index", "Home");
        }
    }
}
