using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.CreateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.RemoveOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.UpdateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetByIdOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetByUserIdOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetListOrdering;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> OrderingList(GetListOrderingQuery getListOrderingQuery)
    {
        List<GetListOrderingDto> result = await _mediator.Send(getListOrderingQuery);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        var result = await _mediator.Send(new GetByIdOrderingQuery(id));

        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
    {
        CreatedOrderingDto result =  await _mediator.Send(createOrderingCommand);

        return Created("", result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
    {
        UpdatedOrderingDto result = await _mediator.Send(updateOrderingCommand);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteOrdering(int id)
    {
        await _mediator.Send(new RemoveOrderingCommand(id));

        return Ok("Sipariş başarıyla silindi.");
    }

    [HttpGet("userId")]
    public async Task<IActionResult> GetOrderingByUserId(string id)
    {
        var result = await _mediator.Send(new GetByUserIdOrderingQuery(id));

        return Ok(result);
    }
}
