using MultiShop.Cargo.Dto.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.Business.Abstract;

public interface ICargoCustomerService
{
    List<ResultCargoCustomerDto> GetAllCargoCustomer();
    GetByIdCargoCustomerDto GetByIdCargoCustomer(int id);
    GetByIdCargoCustomerDto GetByUserIdCargoCustomer(string id);
    void CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto);
    void UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto);
    void DeleteCargoCustomer(int id);
}
