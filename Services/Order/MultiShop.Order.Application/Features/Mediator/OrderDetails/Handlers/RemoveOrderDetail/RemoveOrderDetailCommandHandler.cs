using MediatR;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.RemoveOrderDetail;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Handlers.RemoveOrderDetail;

public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand>
{
    private readonly IRepositoryManager _manager;

    public RemoveOrderDetailCommandHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail OrderDetail = await _manager.OrderDetailRepository.GetByFilterAsync(x => x.Id.Equals(request.Id));
        await _manager.OrderDetailRepository.DeleteAsync(OrderDetail);
    }
}
