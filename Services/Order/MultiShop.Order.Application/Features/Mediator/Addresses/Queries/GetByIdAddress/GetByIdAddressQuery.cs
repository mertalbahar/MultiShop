using MediatR;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Queries.GetByIdAddress;

public class GetByIdAddressQuery : IRequest<GetByIdAddressDto>
{
    public int Id { get; set; }

    public GetByIdAddressQuery(int id)
    {
        Id = id;
    }
}
