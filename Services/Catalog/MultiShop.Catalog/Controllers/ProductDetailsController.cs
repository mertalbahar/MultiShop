﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;

    public ProductDetailsController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var values = await _productDetailService.GetAllProductDetailAsync();

        return Ok(values);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var value = await _productDetailService.GetByIdProductDetailAsync(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailDto);

        return Ok("Ürün detayı başarıyla eklendi.");
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);

        return Ok("Ürün detayı başarıyla silindi.");
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);

        return Ok("Ürün detayı başarıyla güncellendi.");
    }
}