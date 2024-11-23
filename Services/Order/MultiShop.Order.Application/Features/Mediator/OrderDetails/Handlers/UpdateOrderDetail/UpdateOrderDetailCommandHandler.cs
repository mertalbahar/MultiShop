using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.UpdateOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Dtos;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Handlers.UpdateOrderDetail;

public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, UpdatedOrderDetailDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public UpdateOrderDetailCommandHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<UpdatedOrderDetailDto> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail getOrderDetail = await _manager.OrderDetailRepository.GetAsync(x => x.Id.Equals(request.Id));
        OrderDetail mappedOrderDetail = _mapper.Map(request, getOrderDetail);
        OrderDetail updatedOrderDetail = await _manager.OrderDetailRepository.UpdateAsync(mappedOrderDetail);
        UpdatedOrderDetailDto updatedOrderDetailDto = _mapper.Map<UpdatedOrderDetailDto>(updatedOrderDetail);

        return updatedOrderDetailDto;
    }
}
