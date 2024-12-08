using MultiShop.Catalog.WebApi.Dtos.BrandDtos;

namespace MultiShop.Catalog.WebApi.Services.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandsAsync();
    Task<GetByIdBrandDto> GetBrandByIdAsync(string id);
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    Task DeleteBrandAsync(string id);
}
