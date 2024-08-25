using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public BrandController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultBrandDto> values = await _manager.BrandService.GetAllBrandsAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBrand([FromForm] CreateBrandDto createBrandDto)
        {
            await _manager.BrandService.CreateBrandAsync(createBrandDto);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteBrand([FromRoute(Name = "id")] string id)
        {
            await _manager.BrandService.DeleteBrandAsync(id);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand([FromRoute(Name = "id")] string id)
        {
            GetByIdBrandDto values = await _manager.BrandService.GetBrandByIdAsync(id);
            UpdateBrandDto result = _mapper.Map<UpdateBrandDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBrand([FromForm] UpdateBrandDto updateBrandDto)
        {
            await _manager.BrandService.UpdateBrandAsync(updateBrandDto);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
