using MultiShop.Catalog.WebApi.Dtos.AboutDtos;

namespace MultiShop.Catalog.WebApi.Services.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutsAsync();
    Task<GetByIdAboutDto> GetAboutByIdAsync(string id);
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string id);
}
