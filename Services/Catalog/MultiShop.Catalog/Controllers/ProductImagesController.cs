using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageService _productImageService;

    public ProductImagesController(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        List<ResultProductImageDto> values = await _productImageService.GetAllProductImageAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        GetByIdProductImageDto value = await _productImageService.GetByIdProductImageAsync(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _productImageService.CreateProductImageAsync(createProductImageDto);

        return Ok("Ürün resmi başarıyla eklendi.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _productImageService.DeleteProductImageAsync(id);

        return Ok("Ürün resmi başarıyla silindi.");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _productImageService.UpdateProductImageAsync(updateProductImageDto);

        return Ok("Ürün resmi başarıyla güncellendi.");
    }
}