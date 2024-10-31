﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Commands.RemoveAddress;

public class RemoveAddressCommand : IRequest
{
    public int Id { get; set; }

    public RemoveAddressCommand(int id)
    {
        Id = id;
    }
}
