﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers;



[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        List<ResultCategoryDto> values = await _categoryService.GetAllCategoryAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        GetByIdCategoryDto value = await _categoryService.GetByIdCategoryAsync(id);
        
        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await _categoryService.CreateCategoryAsync(createCategoryDto);

        return Ok("Kategori başarıyla eklendi.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return Ok("Kategori başarıyla silindi.");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await _categoryService.UpdateCategoryAsync(updateCategoryDto);

        return Ok("Kategori başarıyla güncellendi.");
    }
}
