using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class RemoveOrderDetailCommandHandler
{
    private readonly IAsyncRepository<OrderDetail> _repository;

    public RemoveOrderDetailCommandHandler(IAsyncRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveOrderDetailCommand command)
    {
        OrderDetail value = await _repository.GetByFilterAsync(x => x.Id.Equals(command.Id));
        await _repository.DeleteAsync(value);
    }
}
