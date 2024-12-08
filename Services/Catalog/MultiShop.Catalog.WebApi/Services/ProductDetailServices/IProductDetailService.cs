using MultiShop.Catalog.WebApi.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.WebApi.Services.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
    Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string id);
    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
    Task DeleteProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetProductDetailByProductIdAsync(string productId);
}
