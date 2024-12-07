using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IServiceManager _manager;

    public CategoriesController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        List<ResultCategoryDto> values = await _manager.CategoryService.GetAllCategoriesAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        GetByIdCategoryDto value = await _manager.CategoryService.GetCategoryByIdAsync(id);
        
        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await _manager.CategoryService.CreateCategoryAsync(createCategoryDto);

        return Ok("Kategori başarıyla eklendi.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _manager.CategoryService.DeleteCategoryAsync(id);

        return Ok("Kategori başarıyla silindi.");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await _manager.CategoryService.UpdateCategoryAsync(updateCategoryDto);

        return Ok("Kategori başarıyla güncellendi.");
    }
}
