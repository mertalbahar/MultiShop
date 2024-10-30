using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.CreateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.UpdateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ordering, CreatedOrderingDto>().ReverseMap();
            CreateMap<Ordering, CreateOrderingCommand>().ReverseMap();

            CreateMap<Ordering, OrderingListDto>().ReverseMap();

            CreateMap<Ordering, GetOrderingByIdDto>().ReverseMap();

            CreateMap<Ordering, UpdatedOrderingDto>().ReverseMap();
            CreateMap<Ordering, UpdateOrderingCommand>().ReverseMap();
        }
    }
}
