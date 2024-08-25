using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.Abstracts;
using AutoMapper;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public ProductDetailController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultProductDetailDto> values = await _manager.ProductDetailService.GetAllProductDetailsAsync();

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
        public async Task<IActionResult> CreateProductDetail()
        {
            ViewBag.Products = await GetProductsSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductDetail([FromForm] CreateProductDetailDto createProductDetailDto)
        {
            await _manager.ProductDetailService.CreateProductDetailAsync(createProductDetailDto);

            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteProductDetail([FromRoute(Name = "id")] string id)
        {
            await _manager.ProductDetailService.DeleteProductDetailAsync(id);

            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string productId)
        {
            GetByIdProductDetailDto values = await _manager.ProductDetailService.GetProductDetailByProductIdAsync(productId);
            UpdateProductDetailDto result = _mapper.Map<UpdateProductDetailDto>(values);

            ViewBag.Products = await GetProductsSelectList();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProductDetail([FromForm] UpdateProductDetailDto updateProductDetailDto)
        {
            await _manager.ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
