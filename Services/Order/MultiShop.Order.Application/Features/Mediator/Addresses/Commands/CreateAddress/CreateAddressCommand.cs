using MediatR;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Commands.CreateAddress;

public class CreateAddressCommand : IRequest<CreatedAddressDto>
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}
