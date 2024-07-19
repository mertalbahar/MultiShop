using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services;

namespace MultiShop.Catalog.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _manager;

    public ProductsController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        List<ResultProductDto> values = await _manager.ProductService.GetAllProductAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        GetByIdProductDto value = await _manager.ProductService.GetByIdProductAsync(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await _manager.ProductService.CreateProductAsync(createProductDto);

        return Ok("Ürün başarıyla eklendi.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _manager.ProductService.DeleteProductAsync(id);

        return Ok("Ürün başarıyla silindi.");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _manager.ProductService.UpdateProductAsync(updateProductDto);

        return Ok("Ürün başarıyla güncellendi.");
    }
}
