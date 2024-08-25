using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("abouts/create", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("abouts/delete/" + id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("abouts");
            List<ResultAboutDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();

            return result;
        }

        public async Task<GetByIdAboutDto> GetAboutByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("abouts/" + id);
            GetByIdAboutDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdAboutDto>();

            return result;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("abouts/update", updateAboutDto);
        }
    }
}
