using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.WebApi.Dtos.AboutDtos;
using MultiShop.Catalog.WebApi.Services;

namespace MultiShop.Catalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AboutsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            List<ResultAboutDto> values = await _manager.AboutService.GetAllAboutsAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            GetByIdAboutDto value = await _manager.AboutService.GetAboutByIdAsync(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _manager.AboutService.CreateAboutAsync(createAboutDto);

            return Ok("Hakkımızda başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _manager.AboutService.DeleteAboutAsync(id);

            return Ok("Hakkımızda başarıyla silindi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _manager.AboutService.UpdateAboutAsync(updateAboutDto);

            return Ok("Hakkımızda başarıyla güncellendi.");
        }
    }
}
