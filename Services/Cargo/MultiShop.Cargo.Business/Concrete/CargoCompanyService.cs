using AutoMapper;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Concrete;

public class CargoCompanyService : ICargoCompanyService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public CargoCompanyService(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public void DeleteCargoCompany(int id)
    {
        CargoCompany cargoCompany = _manager.CargoCompanyRepository.Get(x => x.Id.Equals(id));
        _manager.CargoCompanyRepository.Delete(cargoCompany);
    }

    public List<ResultCargoCompanyDto> GetAllCargoCompany()
    {
        IList<CargoCompany> listedCargoCompany = _manager.CargoCompanyRepository.GetList();
        List<ResultCargoCompanyDto> result = _mapper.Map<List<ResultCargoCompanyDto>>(listedCargoCompany);

        return result;
    }

    public GetByIdCargoCompanyDto GetByIdCargoCompany(int id)
    {
        CargoCompany cargoCompany = _manager.CargoCompanyRepository.Get(x => x.Id.Equals(id));
        GetByIdCargoCompanyDto result = _mapper.Map<GetByIdCargoCompanyDto>(cargoCompany);

        return result;
    }

    public void CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        CargoCompany cargoCompany = _mapper.Map<CargoCompany>(createCargoCompanyDto);
        _manager.CargoCompanyRepository.Add(cargoCompany);
    }

    public void UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        CargoCompany getCargoCompany = _manager.CargoCompanyRepository.Get(x => x.Id.Equals(updateCargoCompanyDto.Id));
        CargoCompany mappedCargoCompany = _mapper.Map(updateCargoCompanyDto, getCargoCompany);
        _manager.CargoCompanyRepository.Update(mappedCargoCompany);
    }
}
