using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.CreateAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.UpdateAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, CreatedAddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();

            CreateMap<Address, GetListAddressDto>().ReverseMap();

            CreateMap<Address, GetByIdAddressDto>().ReverseMap();

            CreateMap<Address, UpdatedAddressDto>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();
        }
    }
}
