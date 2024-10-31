using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetByIdOrdering;

public class GetByIdOrderingQuery : IRequest<GetByIdOrderingDto>
{
    public int Id { get; set; }

    public GetByIdOrderingQuery(int id)
    {
        Id = id;
    }
}
