using MediatR;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.RemoveAddress;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Handlers.RemoveAddress;

public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommand>
{
    private readonly IRepositoryManager _manager;

    public RemoveAddressCommandHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
    {
        Address address = await _manager.AddressRepository.GetByFilterAsync(x => x.Id.Equals(request.Id));
        await _manager.AddressRepository.DeleteAsync(address);
    }
}
