using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories/create", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories/delete/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("categories");
            List<ResultCategoryDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();

            return result;
        }

        public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("categories/" + id);
            GetByIdCategoryDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();

            return result;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories/update", updateCategoryDto);
        }
    }
}
