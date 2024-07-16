using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Services.DiscountOfferServices;

namespace MultiShop.Catalog.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DiscountOffersController : ControllerBase
    {
        private readonly IDiscountOfferService _discountOfferService;

        public DiscountOffersController(IDiscountOfferService discountOfferService)
        {
            _discountOfferService = discountOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountOfferList()
        {
            List<ResultDiscountOfferDto> values = await _discountOfferService.GetAllDiscountOfferAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountOfferById(string id)
        {
            GetByIdDiscountOfferDto value = await _discountOfferService.GetByIdDiscountOfferAsync(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
        {
            await _discountOfferService.CreateDiscountOfferAsync(createDiscountOfferDto);

            return Ok("İndirim teklifi başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteDiscountOffer(string id)
        {
            await _discountOfferService.DeleteDiscountOfferAsync(id);

            return Ok("İndirim teklifi başarıyla silindi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _discountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferDto);

            return Ok("İndirim teklifi başarıyla güncellendi.");
        }
    }
}
