using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    private readonly ICargoCustomerService _cargoCustomerService;

    public CargoCustomersController(ICargoCustomerService cargoCustomerService)
    {
        _cargoCustomerService = cargoCustomerService;
    }

    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        List<CargoCustomer> values = _cargoCustomerService.TGetAll();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCustomerById(int id)
    {
        CargoCustomer value = _cargoCustomerService.TGetById(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Name = createCargoCustomerDto.Name,
            Surname = createCargoCustomerDto.Surname,
            Email = createCargoCustomerDto.Email,
            Phone = createCargoCustomerDto.Phone,
            City = createCargoCustomerDto.City,
            District = createCargoCustomerDto.District,
            Address = createCargoCustomerDto.Address,
        };
        _cargoCustomerService.TInsert(cargoCustomer);

        return Ok("Kargo müşterisi başarıyla oluşturuldu.");
    }

    [HttpPut("update")]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = new CargoCustomer()
        {
            Id = updateCargoCustomerDto.Id,
            Name = updateCargoCustomerDto.Name,
            Surname = updateCargoCustomerDto.Surname,
            Email = updateCargoCustomerDto.Email,
            Phone = updateCargoCustomerDto.Phone,
            City = updateCargoCustomerDto.City,
            District= updateCargoCustomerDto.District,
            Address = updateCargoCustomerDto.Address,
        };
        _cargoCustomerService.TUpdate(cargoCustomer);

        return Ok("Kargo müşterisi başarıyla güncellendi.");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult RemoveCargoCustomer(int id)
    {
        _cargoCustomerService.TDelete(id);

        return Ok("Kargo müşterisi başarıyla silindi.");
    }
}
