using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public CreateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _repository.CreateAsync(new Address
        {
            UserId = createAddressCommand.UserId,
            Name = createAddressCommand.Name,
            Surname = createAddressCommand.Surname,
            Email = createAddressCommand.Email,
            Phone = createAddressCommand.Phone,
            Line1 = createAddressCommand.Line1,
            Line2 = createAddressCommand.Line2,
            District = createAddressCommand.District,
            City = createAddressCommand.City,
            Country = createAddressCommand.Country,
            ZipCode = createAddressCommand.ZipCode
        });
    }
}
