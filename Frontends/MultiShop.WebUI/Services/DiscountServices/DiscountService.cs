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
    }
}
