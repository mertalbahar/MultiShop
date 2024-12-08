using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDto>> GetAllCargoCustomerAsync();
        Task<GetByIdCargoCustomerDto> GetByUserIdCargoCustomerAsync(string id);
    }
}
