using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController : ControllerBase
{
    private readonly ICargoDetailService _cargoDetailService;

    public CargoDetailsController(ICargoDetailService cargoDetailService)
    {
        _cargoDetailService = cargoDetailService;
    }

    [HttpGet]
    public IActionResult CargoDetailList()
    {
        List<CargoDetail> values = _cargoDetailService.TGetAll();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoDetailById(int id)
    {
        CargoDetail value = _cargoDetailService.TGetById(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        CargoDetail cargoDetail = new CargoDetail()
        {
            CargoCompanyId = createCargoDetailDto.CargoCompanyId,
            Barcode = createCargoDetailDto.Barcode,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            SenderCustomer = createCargoDetailDto.SenderCustomer
        };
        _cargoDetailService.TInsert(cargoDetail);

        return Ok("Kargo detayları başarıyla oluşturuldu.");
    }

    [HttpPut("update")]
    public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        CargoDetail cargoDetail = new CargoDetail()
        {
            Id = updateCargoDetailDto.Id,
            CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
            Barcode = updateCargoDetailDto.Barcode,
            SenderCustomer = updateCargoDetailDto.ReceiverCustomer,
            ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer
        };
        _cargoDetailService.TUpdate(cargoDetail);

        return Ok("Kargo detayları başarıyla güncellendi.");
    }

    [HttpDelete("delete")]
    public IActionResult RemoveCargoDetail(int id)
    {
        _cargoDetailService.TDelete(id);

        return Ok("Kargo detayları başarıyla silindi.");
    }
}
