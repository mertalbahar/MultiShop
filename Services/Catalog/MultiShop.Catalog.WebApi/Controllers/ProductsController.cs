﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.WebApi.Dtos.ProductDtos;
using MultiShop.Catalog.WebApi.Services;

namespace MultiShop.Catalog.WebApi.Controllers;

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
        List<ResultProductDto> values = await _manager.ProductService.GetAllProductsAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        GetByIdProductDto value = await _manager.ProductService.GetProductByIdAsync(id);

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

    [HttpGet("categoryId")]
    public async Task<IActionResult> ProductListByCategoryId(string id)
    {
        List<ResultProductDto> values = await _manager.ProductService.GetProductsByCategoryIdAsync(id);

        return Ok(values);
    }
}
