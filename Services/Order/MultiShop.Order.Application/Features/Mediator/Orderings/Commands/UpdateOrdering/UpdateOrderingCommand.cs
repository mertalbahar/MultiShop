﻿using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.UpdateOrdering;

public class UpdateOrderingCommand : IRequest<UpdatedOrderingDto>
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
