using MultiShop.Catalog.WebApi.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.WebApi.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
    Task<GetByIdProductImageDto> GetProductImageByIdAsync(string id);
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task DeleteProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetProductImageByProductIdAsync(string productId);
}
