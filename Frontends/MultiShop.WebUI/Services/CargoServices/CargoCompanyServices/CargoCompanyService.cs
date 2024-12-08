using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargocompanies/create", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocompanies/delete/" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("cargocompanies");
            List<ResultCargoCompanyDto> result = await responseMessage.Content.ReadFromJsonAsync<List<ResultCargoCompanyDto>>();

            return result;
        }

        public async Task<GetByIdCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("cargocompanies/" + id);
            GetByIdCargoCompanyDto result = await responseMessage.Content.ReadFromJsonAsync<GetByIdCargoCompanyDto>();

            return result;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargocompanies/update", updateCargoCompanyDto);
        }
    }
}
