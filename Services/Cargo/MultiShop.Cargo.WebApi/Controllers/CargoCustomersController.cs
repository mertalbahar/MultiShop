using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCustomerDtos;

namespace MultiShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController : ControllerBase
{
    private readonly IServiceManager _manager;

    public CargoCustomersController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult CargoCustomerList()
    {
        List<ResultCargoCustomerDto> values = _manager.CargoCustomerService.GetAllCargoCustomer();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCustomerById(int id)
    {
        GetByIdCargoCustomerDto value = _manager.CargoCustomerService.GetByIdCargoCustomer(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        _manager.CargoCustomerService.CreateCargoCustomer(createCargoCustomerDto);

        return Ok("Kargo müşterisi başarıyla oluşturuldu.");
    }

    [HttpPut("update")]
    public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        _manager.CargoCustomerService.UpdateCargoCustomer(updateCargoCustomerDto);

        return Ok("Kargo müşterisi başarıyla güncellendi.");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult RemoveCargoCustomer(int id)
    {
        _manager.CargoCustomerService.DeleteCargoCustomer(id);

        return Ok("Kargo müşterisi başarıyla silindi.");
    }

    [HttpGet("userId")]
    public IActionResult GetCargoCustomerByUserId(string id)
    {
        GetByIdCargoCustomerDto values = _manager.CargoCustomerService.GetByUserIdCargoCustomer(id);

        return Ok(values);
    }
}
