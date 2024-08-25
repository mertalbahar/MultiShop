using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    private readonly IServiceManager _manager;

    public ProductDetailsController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        List<ResultProductDetailDto> values = await _manager.ProductDetailService.GetAllProductDetailsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        GetByIdProductDetailDto value = await _manager.ProductDetailService.GetProductDetailByIdAsync(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _manager.ProductDetailService.CreateProductDetailAsync(createProductDetailDto);

        return Ok("Ürün detayı başarıyla eklendi.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _manager.ProductDetailService.DeleteProductDetailAsync(id);

        return Ok("Ürün detayı başarıyla silindi.");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _manager.ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);

        return Ok("Ürün detayı başarıyla güncellendi.");
    }

    [HttpGet("productId")]
    public async Task<IActionResult> GetProductImagesByProductId(string id)
    {
        GetByIdProductDetailDto values = await _manager.ProductDetailService.GetProductDetailByProductIdAsync(id);

        return Ok(values);
    }
}