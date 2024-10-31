using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetByUserIdOrdering
{
    public class GetByUserIdOrderingQuery : IRequest<List<GetListOrderingDto>>
    {
        public string UserId { get; set; }

        public GetByUserIdOrderingQuery(string userId)
        {
            UserId = userId;
        }
    }
}
