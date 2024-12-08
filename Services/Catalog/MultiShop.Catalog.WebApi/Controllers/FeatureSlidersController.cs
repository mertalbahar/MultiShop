using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.WebApi.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.WebApi.Services;

namespace MultiShop.Catalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public FeatureSlidersController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            List<ResultFeatureSliderDto> values = await _manager.FeatureSliderService.GetAllFeatureSlidersAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            GetByIdFeatureSliderDto value = await _manager.FeatureSliderService.GetFeatureSliderByIdAsync(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _manager.FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

            return Ok("Öne çıkan görsel başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _manager.FeatureSliderService.DeleteFeatureSliderAsync(id);

            return Ok("Öne çıkan görsel başarıyla silindi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _manager.FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);

            return Ok("Öne çıkan görsel başarıyla güncellendi.");
        }
    }
}
