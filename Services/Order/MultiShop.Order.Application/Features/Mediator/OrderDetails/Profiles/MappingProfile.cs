using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.CreateOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.UpdateOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Dtos;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDetail, CreatedOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();

            CreateMap<OrderDetail, GetListOrderDetailDto>().ReverseMap();

            CreateMap<OrderDetail, GetByIdOrderDetailDto>().ReverseMap();

            CreateMap<OrderDetail, UpdatedOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
        }
    }
}
