using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync("productimages/create", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimages/delete/" + id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("productimages");
            List<ResultProductImageDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();

            return result;
        }

        public async Task<GetByIdProductImageDto> GetProductImageByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("productimages/" + id);
            GetByIdProductImageDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();

            return result;
        }

        public async Task<GetByIdProductImageDto> GetProductImageByProductIdAsync(string productId)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("productimages/productId?id=" + productId);
            GetByIdProductImageDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();

            return result;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync("productimages/update", updateProductImageDto);
        }
    }
}
