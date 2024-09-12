using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IServiceManager _manager;

        public ShoppingCartController(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBasketItem([FromRoute(Name = "id")] string productId)
        {
            GetByIdProductDto values = await _manager.ProductService.GetProductByIdAsync(productId);
            var items = new BasketItemDto
            {
                ProductId = values.Id,
                ProductName = values.Name,
                Price = values.Price,
                ProductImageUrl = values.ImageUrl,
                Quantity = 1,
            };

            await _manager.BasketService.AddBasketItem(items);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem([FromRoute(Name = "id")] string productId)
        {
            await _manager.BasketService.RemoveBasketItem(productId);

            return RedirectToAction("Index");
        }
    }
}
