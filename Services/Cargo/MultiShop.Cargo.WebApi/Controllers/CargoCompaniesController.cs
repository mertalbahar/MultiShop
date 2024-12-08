using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;

namespace MultiShop.Cargo.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController : ControllerBase
{
    private readonly IServiceManager _manager;

    public CargoCompaniesController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult CargoCompanyList()
    {
        List<ResultCargoCompanyDto> values = _manager.CargoCompanyService.GetAllCargoCompany();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetCargoCompanyById(int id)
    {
        GetByIdCargoCompanyDto value = _manager.CargoCompanyService.GetByIdCargoCompany(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        _manager.CargoCompanyService.CreateCargoCompany(createCargoCompanyDto);

        return Ok("Kargo şirketi başarıyla oluşturuldu.");
    }

    [HttpPut("update")]
    public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        _manager.CargoCompanyService.UpdateCargoCompany(updateCargoCompanyDto);

        return Ok("Kargo şirketi başarıyla güncellendi.");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult RemoveCargoCompany(int id)
    {
        _manager.CargoCompanyService.DeleteCargoCompany(id);

        return Ok("Kargo şirketi başarıyla silindi.");
    }
}
