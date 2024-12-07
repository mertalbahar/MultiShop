using AutoMapper;
using MultiShop.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, GetByIdCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, ResultCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();
        }
    }
}
