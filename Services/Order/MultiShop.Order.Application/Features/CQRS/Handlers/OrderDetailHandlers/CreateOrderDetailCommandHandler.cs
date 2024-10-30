using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IAsyncRepository<OrderDetail> _repository;

    public CreateOrderDetailCommandHandler(IAsyncRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderDetailCommand command)
    {
        await _repository.CreateAsync(new OrderDetail
        {
            OrderingId = command.OrderingId,
            ProductId = command.ProductId,
            ProductName = command.ProductName,
            ProductAmount = command.ProductAmount,
            ProductPrice = command.ProductPrice,
            ProductTotalPrice = command.ProductTotalPrice,
        });
    }
}
