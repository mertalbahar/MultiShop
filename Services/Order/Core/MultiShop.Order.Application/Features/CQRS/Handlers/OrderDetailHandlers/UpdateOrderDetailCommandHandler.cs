﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        OrderDetail value = await _repository.GetByIdAsync(command.Id);
        value.OrderingId = command.OrderingId;
        value.ProductId = command.ProductId;
        value.ProductName = command.ProductName;
        value.ProductPrice = command.ProductPrice;
        value.ProductAmount = command.ProductAmount;
        value.ProductTotalPrice = command.ProductTotalPrice;

        await _repository.UpdateAsync(value);
    }
}
