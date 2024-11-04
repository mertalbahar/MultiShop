using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.CreateOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.RemoveOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Commands.UpdateOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Dtos;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetByIdOrderDetail;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetListOrderDetail;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderDetailsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> OrderDetailList([FromQuery] GetListOrderDetailQuery getListOrderDetailQuery)
    {
        List<GetListOrderDetailDto> result = await _mediator.Send(getListOrderDetailQuery);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetByIdOrderDetailQuery(id));

        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailCommand createOrderDetailCommand)
    {
        CreatedOrderDetailDto result = await _mediator.Send(createOrderDetailCommand);

        return Created("", result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
    {
        UpdatedOrderDetailDto result = await _mediator.Send(updateOrderDetailCommand);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await _mediator.Send(new RemoveOrderDetailCommand(id));

        return Ok("Sipariş detayı başarıyla silindi.");
    }
}