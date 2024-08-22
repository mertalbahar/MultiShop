using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers/create", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffers/delete/" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("specialoffers");
            List<ResultSpecialOfferDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();

            return result;
        }

        public async Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
            GetByIdSpecialOfferDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdSpecialOfferDto>();

            return result;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers/update", updateSpecialOfferDto);
        }
    }
}
