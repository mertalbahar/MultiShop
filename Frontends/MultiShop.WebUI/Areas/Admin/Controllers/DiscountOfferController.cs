using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountOfferController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public DiscountOfferController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultDiscountOfferDto> values = await _manager.DiscountOfferService.GetAllDiscountOffersAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDiscountOffer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDiscountOffer([FromForm] CreateDiscountOfferDto createDiscountOfferDto)
        {
            await _manager.DiscountOfferService.CreateDiscountOfferAsync(createDiscountOfferDto);

            return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteDiscountOffer([FromRoute(Name = "id")] string id)
        {
            await _manager.DiscountOfferService.DeleteDiscountOfferAsync(id);

            return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscountOffer([FromRoute(Name = "id")] string id)
        {
            GetByIdDiscountOfferDto values = await _manager.DiscountOfferService.GetDiscountOfferByIdAsync(id);
            UpdateDiscountOfferDto result = _mapper.Map<UpdateDiscountOfferDto>(values);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDiscountOffer([FromForm] UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _manager.DiscountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferDto);

            return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
        }
    }
}
