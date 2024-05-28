using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
    private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
    private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
    private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
    private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

    public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler,
        GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
        CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
        UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler,
        RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
    {
        _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
        _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
        _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> OrderDetailList()
    {
        List<GetOrderDetailQueryResult> values = await _getOrderDetailQueryHandler.Handle();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        GetOrderDetailByIdQueryResult value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));

        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
    {
        await _createOrderDetailCommandHandler.Handle(command);

        return Ok("Sipari detayı başarıyla eklendi.");
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
    {
        await _updateOrderDetailCommandHandler.Handle(command);

        return Ok("Sipari detayı başarıyla güncellendi.");
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));

        return Ok("Sipari detayı başarıyla silindi.");
    }
}