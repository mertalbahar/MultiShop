using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync("productdetails/create", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetails/delete/" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails");
            List<ResultProductDetailDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();

            return result;
        }

        public async Task<GetByIdProductDetailDto> GetProductDetailByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails/" + id);
            GetByIdProductDetailDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();

            return result;
        }

        public async Task<GetByIdProductDetailDto> GetProductDetailByProductIdAsync(string productId)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails/productId?id=" + productId);
            GetByIdProductDetailDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDetailDto>();

            return result;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync("productdetails/update", updateProductDetailDto);
        }
    }
}
