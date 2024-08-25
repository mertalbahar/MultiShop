using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IServiceManager _manager;

    public ProductImagesController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        List<ResultProductImageDto> values = await _manager.ProductImageService.GetAllProductImagesAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        GetByIdProductImageDto value = await _manager.ProductImageService.GetProductImageByIdAsync(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _manager.ProductImageService.CreateProductImageAsync(createProductImageDto);

        return Ok("Ürün resmi başarıyla eklendi.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _manager.ProductImageService.DeleteProductImageAsync(id);

        return Ok("Ürün resmi başarıyla silindi.");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _manager.ProductImageService.UpdateProductImageAsync(updateProductImageDto);

        return Ok("Ürün resmi başarıyla güncellendi.");
    }

    [HttpGet("productId")]
    public async Task<IActionResult> GetProductImagesByProductId(string id)
    {
        GetByIdProductImageDto values = await _manager.ProductImageService.GetProductImageByProductIdAsync(id);

        return Ok(values);
    }
}