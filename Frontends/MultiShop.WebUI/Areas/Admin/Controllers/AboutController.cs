using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public AboutController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultAboutDto> values = await _manager.AboutService.GetAllAboutsAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAbout([FromForm] CreateAboutDto createAboutDto)
        {
            await _manager.AboutService.CreateAboutAsync(createAboutDto);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteAbout([FromRoute(Name = "id")] string id)
        {
            await _manager.AboutService.DeleteAboutAsync(id);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout([FromRoute(Name = "id")] string id)
        {
            GetByIdAboutDto values = await _manager.AboutService.GetAboutByIdAsync(id);
            UpdateAboutDto result = _mapper.Map<UpdateAboutDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAbout([FromForm] UpdateAboutDto updateAboutDto)
        {
            await _manager.AboutService.UpdateAboutAsync(updateAboutDto);

            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
