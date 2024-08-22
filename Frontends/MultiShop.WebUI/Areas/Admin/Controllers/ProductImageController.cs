using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public ProductImageController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultProductImageDto> values = await _manager.ProductImageService.GetAllProductImagesAsync();

            return View(values);
        }

        private async Task<SelectList> GetProductsSelectList()
        {
            List<ResultProductDto> values = await _manager.ProductService.GetAllProductsAsync();

            List<SelectListItem> ProductValues = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id
                                                  }).ToList();

            return new SelectList(ProductValues, "Value", "Text");
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {
            ViewBag.Products = await GetProductsSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductImage([FromForm] CreateProductImageDto createProductImageDto)
        {
            await _manager.ProductImageService.CreateProductImageAsync(createProductImageDto);

            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteProductImage([FromRoute(Name = "id")] string id)
        {
            await _manager.ProductImageService.DeleteProductImageAsync(id);

            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string productId)
        {
            GetByIdProductImageDto values = await _manager.ProductImageService.GetProductImageByProductIdAsync(productId);
            UpdateProductImageDto result = _mapper.Map<UpdateProductImageDto>(values);

            ViewBag.Products = await GetProductsSelectList();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductImage([FromForm] UpdateProductImageDto updateProductImageDto)
        {
            await _manager.ProductImageService.UpdateProductImageAsync(updateProductImageDto);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
