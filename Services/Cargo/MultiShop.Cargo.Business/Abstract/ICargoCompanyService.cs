using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Abstract;

public interface ICargoCompanyService
{
    List<ResultCargoCompanyDto> GetAllCargoCompany();
    GetByIdCargoCompanyDto GetByIdCargoCompany(int id);
    void CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto);
    void UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto);
    void DeleteCargoCompany(int id);
}
