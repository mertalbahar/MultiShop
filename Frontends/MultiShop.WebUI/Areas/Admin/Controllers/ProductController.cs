using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public ProductController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultProductDto> values = await _manager.ProductService.GetAllProductsAsync();

            return View(values);
        }

        private async Task<SelectList> GetCategoriesSelectList()
        {
            List<ResultCategoryDto> values = await _manager.CategoryService.GetAllCategoriesAsync();

            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id
                                                   }).ToList();

            return new SelectList(categoryValues, "Value", "Text");
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.Categories = await GetCategoriesSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto createProductDto)
        {
            await _manager.ProductService.CreateProductAsync(createProductDto);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteProduct([FromRoute(Name = "id")] string id)
        {
            await _manager.ProductService.DeleteProductAsync(id);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct([FromRoute(Name = "id")] string id)
        {
            GetByIdProductDto values = await _manager.ProductService.GetProductByIdAsync(id);
            UpdateProductDto result = _mapper.Map<UpdateProductDto>(values);
            ViewBag.Categories = await GetCategoriesSelectList();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductDto updateProductDto)
        {
            await _manager.ProductService.UpdateProductAsync(updateProductDto);

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
