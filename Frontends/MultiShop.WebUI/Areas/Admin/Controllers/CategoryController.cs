using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public CategoryController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultCategoryDto> values = await _manager.CategoryService.GetAllCategoriesAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDto createCategoryDto)
        {
            await _manager.CategoryService.CreateCategoryAsync(createCategoryDto);

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteCategory([FromRoute(Name = "id")] string id)
        {
            await _manager.CategoryService.DeleteCategoryAsync(id);

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory([FromRoute(Name = "id")] string id)
        {
            GetByIdCategoryDto values = await _manager.CategoryService.GetCategoryByIdAsync(id);
            UpdateCategoryDto result = _mapper.Map<UpdateCategoryDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryDto updateCategoryDto)
        {
            await _manager.CategoryService.UpdateCategoryAsync(updateCategoryDto);

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
