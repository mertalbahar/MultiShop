using MediatR;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetByIdOrderDetail;

public class GetByIdOrderDetailQuery : IRequest<GetByIdOrderDetailDto>
{
    public int Id { get; set; }

    public GetByIdOrderDetailQuery(int id)
    {
        Id = id;
    }
}
