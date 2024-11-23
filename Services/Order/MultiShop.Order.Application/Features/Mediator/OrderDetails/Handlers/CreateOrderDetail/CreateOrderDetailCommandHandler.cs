using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.CreateOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Dtos;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Handlers.CreateOrderDetail;

public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreatedOrderDetailDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public CreateOrderDetailCommandHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<CreatedOrderDetailDto> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail mappedOrderDetail = _mapper.Map<OrderDetail>(request);
        OrderDetail createdOrderDetail = await _manager.OrderDetailRepository.AddAsync(mappedOrderDetail);
        CreatedOrderDetailDto createdOrderDetailDto = _mapper.Map<CreatedOrderDetailDto>(createdOrderDetail);

        return createdOrderDetailDto;
    }
}
