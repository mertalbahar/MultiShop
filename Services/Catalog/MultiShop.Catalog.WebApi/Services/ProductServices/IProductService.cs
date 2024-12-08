using MultiShop.Catalog.WebApi.Dtos.ProductDtos;

namespace MultiShop.Catalog.WebApi.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task<GetByIdProductDto> GetProductByIdAsync(string id);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductAsync(string id);
    Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId);
}
