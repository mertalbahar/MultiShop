using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCargoCustomerDto>> GetAllCargoCustomerAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("cargocustomers");
            List<ResultCargoCustomerDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCustomerDto>>();

            return result;
        }

        public async Task<GetByIdCargoCustomerDto> GetByUserIdCargoCustomerAsync(string id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("cargocustomers/userId?id=" + id);
            GetByIdCargoCustomerDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoCustomerDto>();

            return result;
        }
    }
}
