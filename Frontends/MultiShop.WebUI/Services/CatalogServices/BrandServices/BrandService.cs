using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("brands/create", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("brands/delete/" + id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("brands");
            List<ResultBrandDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();

            return result;
        }

        public async Task<GetByIdBrandDto> GetBrandByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("brands/" + id);
            GetByIdBrandDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdBrandDto>();

            return result;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brands/update", updateBrandDto);
        }
    }
}
