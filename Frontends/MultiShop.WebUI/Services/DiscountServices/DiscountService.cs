using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDiscountCouponDto>("discounts/create", createCouponDto);
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            await _httpClient.DeleteAsync("discounts/delete/" + id);
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("discounts");
            List<ResultDiscountCouponDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultDiscountCouponDto>>();

            return result;
        }

        public async Task<ResultDiscountCouponDto> GetByCodeDiscountCouponAsync(string code)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("discounts/discountCode/" + code);
            ResultDiscountCouponDto result = await responseMessage.Content.ReadFromJsonAsync<ResultDiscountCouponDto>();

            return result;
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("discounts/" + id);
            GetByIdDiscountCouponDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdDiscountCouponDto>();

            return result;
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDiscountCouponDto>("discounts/update", updateCouponDto);
        }
    }
}
