using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.DtoLayer.MessageDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public CargoController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> CargoCompanyList()
        {
            List<ResultCargoCompanyDto> values = await _manager.CargoCompanyService.GetAllCargoCompanyAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCargoCompany([FromForm] CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _manager.CargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany([FromRoute(Name = "id")] int id)
        {
            GetByIdCargoCompanyDto values = await _manager.CargoCompanyService.GetByIdCargoCompanyAsync(id);
            UpdateCargoCompanyDto result = _mapper.Map<UpdateCargoCompanyDto>(values);

            return View(result);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCargoCompany([FromForm] UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _manager.CargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteCargoCompany([FromRoute(Name = "id")] int id)
        {
            await _manager.CargoCompanyService.DeleteCargoCompanyAsync(id);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }
    }
}
