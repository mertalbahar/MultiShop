using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public FeatureSliderController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultFeatureSliderDto> values = await _manager.FeatureSliderService.GetAllFeatureSlidersAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFeatureSlider([FromForm] CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _manager.FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteFeatureSlider([FromRoute(Name = "id")] string id)
        {
            await _manager.FeatureSliderService.DeleteFeatureSliderAsync(id);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider([FromRoute(Name = "id")] string id)
        {
            GetByIdFeatureSliderDto values = await _manager.FeatureSliderService.GetFeatureSliderByIdAsync(id);
            UpdateFeatureSliderDto result = _mapper.Map<UpdateFeatureSliderDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateFeatureSlider([FromForm] UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _manager.FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);

            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
