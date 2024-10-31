﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.RemoveOrderDetail;

public class RemoveOrderDetailCommand : IRequest
{
    public int Id { get; set; }

    public RemoveOrderDetailCommand(int id)
    {
        Id = id;
    }
}
