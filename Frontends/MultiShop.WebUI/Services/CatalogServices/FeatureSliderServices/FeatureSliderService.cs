using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders/create", createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featuresliders/delete/" + id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("featuresliders");
            List<ResultFeatureSliderDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();

            return result;
        }

        public async Task<GetByIdFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
            GetByIdFeatureSliderDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdFeatureSliderDto>();

            return result;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders/update", updateFeatureSliderDto);
        }
    }
}
