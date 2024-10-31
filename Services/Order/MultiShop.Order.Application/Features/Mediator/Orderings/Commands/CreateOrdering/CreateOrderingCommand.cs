using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Commands.CreateOrdering;

public class CreateOrderingCommand : IRequest<CreatedOrderingDto>
{
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
