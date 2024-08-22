using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices
{
    public class DiscountOfferService : IDiscountOfferService
    {
        private readonly HttpClient _httpClient;

        public DiscountOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDiscountOfferDto>("discountoffers/create", createDiscountOfferDto);
        }

        public async Task DeleteDiscountOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("discountoffers/delete/" + id);
        }

        public async Task<List<ResultDiscountOfferDto>> GetAllDiscountOffersAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("discountoffers");
            List<ResultDiscountOfferDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultDiscountOfferDto>>();

            return result;
        }

        public async Task<GetByIdDiscountOfferDto> GetDiscountOfferByIdAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("discountoffers/" + id);
            GetByIdDiscountOfferDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdDiscountOfferDto>();

            return result;
        }

        public async Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDiscountOfferDto>("discountoffers/update", updateDiscountOfferDto);
        }
    }
}
