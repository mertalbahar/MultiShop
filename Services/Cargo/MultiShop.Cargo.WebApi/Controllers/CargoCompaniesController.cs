using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    private readonly ICargoCompanyService _cargoCompanyService;

    public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
    {
        _cargoCompanyService = cargoCompanyService;
    }

    [HttpGet]
    public IActionResult CargoCompanyList()
    {
        List<CargoCompany> values = _cargoCompanyService.TGetAll();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCompanyById(int id)
    {
        CargoCompany value = _cargoCompanyService.TGetById(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            Name = createCargoCompanyDto.Name,
        };
        _cargoCompanyService.TInsert(cargoCompany);

        return Ok("Kargo şirketi başarıyla oluşturuldu.");
    }

    [HttpPut("update")]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        CargoCompany cargoCompany = new CargoCompany()
        {
            Id = updateCargoCompanyDto.Id,
            Name = updateCargoCompanyDto.Name,
        };
        _cargoCompanyService.TUpdate(cargoCompany);

        return Ok("Kargo şirketi başarıyla güncellendi.");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult RemoveCargoCompany(int id)
    {
        _cargoCompanyService.TDelete(id);

        return Ok("Kargo şirketi başarıyla silindi.");
    }
}
