using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.WebApi.Dtos.BrandDtos;
using MultiShop.Catalog.WebApi.Services;

namespace MultiShop.Catalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BrandsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            List<ResultBrandDto> values = await _manager.BrandService.GetAllBrandsAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            GetByIdBrandDto value = await _manager.BrandService.GetBrandByIdAsync(id);

            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _manager.BrandService.CreateBrandAsync(createBrandDto);

            return Ok("Marka başarıyla eklendi.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _manager.BrandService.DeleteBrandAsync(id);

            return Ok("Marka başarıyla silindi.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _manager.BrandService.UpdateBrandAsync(updateBrandDto);

            return Ok("Marka başarıyla güncellendi.");
        }
    }
}
