using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("products/create", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products/delete/" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("products");
            List<ResultProductDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();

            return result;
        }

        public async Task<GetByIdProductDto> GetProductByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/" + id);
            GetByIdProductDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();

            return result;
        }

        public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/categoryId?id=" + categoryId);
            List<ResultProductDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();

            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("products/update", updateProductDto);
        }
    }
}
