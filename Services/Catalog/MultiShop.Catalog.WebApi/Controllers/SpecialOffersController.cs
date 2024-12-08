using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.WebApi.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.WebApi.Services;

namespace MultiShop.Catalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public SpecialOffersController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            List<ResultSpecialOfferDto> values = await _manager.SpecialOfferService.GetAllSpecialOffersAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            GetByIdSpecialOfferDto value = await _manager.SpecialOfferService.GetSpecialOfferByIdAsync(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _manager.SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

            return Ok("Özel teklif başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _manager.SpecialOfferService.DeleteSpecialOfferAsync(id);

            return Ok("Özel teklif başarıyla silindi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _manager.SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);

            return Ok("Özel teklif başarıyla güncellendi.");
        }
    }
}
