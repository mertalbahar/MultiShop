using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController : ControllerBase
{
    private readonly ICargoOperationService _cargoOperationService;

    public CargoOperationsController(ICargoOperationService cargoOperationService)
    {
        _cargoOperationService = cargoOperationService;
    }

    [HttpGet]
    public IActionResult CargoOperationList()
    {
        List<CargoOperation> values = _cargoOperationService.TGetAll();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoOperationById(int id)
    {
        CargoOperation value = _cargoOperationService.TGetById(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        CargoOperation cargoOperation = new CargoOperation()
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OperationDate = createCargoOperationDto.OperationDate,
        };
        _cargoOperationService.TInsert(cargoOperation);

        return Ok("Kargo operasyonu başarıyla oluşturuldu.");
    }

    [HttpPut("update")]
    public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        CargoOperation cargoOperation = new CargoOperation()
        {
            Id = updateCargoOperationDto.Id,
            Barcode = updateCargoOperationDto.Barcode,
            Description = updateCargoOperationDto.Description,
            OperationDate = updateCargoOperationDto.OperationDate
        };
        _cargoOperationService.TUpdate(cargoOperation);

        return Ok("Kargo operasyonu başarıyla güncellendi.");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult RemoveCargoOperation(int id)
    {
        _cargoOperationService.TDelete(id);

        return Ok("Kargo operasyonu başarıyla silindi.");
    }
}
