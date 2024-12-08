using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Services;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountOffersController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public DiscountOffersController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountOfferList()
        {
            List<ResultDiscountOfferDto> values = await _manager.DiscountOfferService.GetAllDiscountOffersAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountOfferById(string id)
        {
            GetByIdDiscountOfferDto value = await _manager.DiscountOfferService.GetDiscountOfferByIdAsync(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
        {
            await _manager.DiscountOfferService.CreateDiscountOfferAsync(createDiscountOfferDto);

            return Ok("İndirim teklifi başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDiscountOffer(string id)
        {
            await _manager.DiscountOfferService.DeleteDiscountOfferAsync(id);

            return Ok("İndirim teklifi başarıyla silindi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _manager.DiscountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferDto);

            return Ok("İndirim teklifi başarıyla güncellendi.");
        }
    }
}
