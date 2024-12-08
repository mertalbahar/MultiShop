using MultiShop.Catalog.WebApi.Dtos.CategoryDtos;

namespace MultiShop.Catalog.WebApi.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id);
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(string id);
}
