using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.CreateAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.RemoveAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.UpdateAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using MultiShop.Order.Application.Features.Mediator.Addresses.Queries.GetByIdAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Queries.GetListAddress;

namespace MultiShop.Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AddressesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> AddressList(GetListAddressQuery getListAddressQuery)
    {
        List<GetListAddressDto> result = await _mediator.Send(getListAddressQuery);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var result = await _mediator.Send(new GetByIdAddressQuery(id));

        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
    {
        CreatedAddressDto result = await _mediator.Send(createAddressCommand);

        return Created("", result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
    {
        UpdatedAddressDto result = await _mediator.Send(updateAddressCommand);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        await _mediator.Send(new RemoveAddressCommand(id));

        return Ok("Adres başarıyla silindi.");
    }
}
