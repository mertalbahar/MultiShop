using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public SpecialOfferController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultSpecialOfferDto> values = await _manager.SpecialOfferService.GetAllSpecialOffersAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSpecialOffer([FromForm] CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _manager.SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteSpecialOffer([FromRoute(Name = "id")] string id)
        {
            await _manager.SpecialOfferService.DeleteSpecialOfferAsync(id);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer([FromRoute(Name = "id")] string id)
        {
            GetByIdSpecialOfferDto values = await _manager.SpecialOfferService.GetSpecialOfferByIdAsync(id);
            UpdateSpecialOfferDto result = _mapper.Map<UpdateSpecialOfferDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSpecialOffer([FromForm] UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _manager.SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);

            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
