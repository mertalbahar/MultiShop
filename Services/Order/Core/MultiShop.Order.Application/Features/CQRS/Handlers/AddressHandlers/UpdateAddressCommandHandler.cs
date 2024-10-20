using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public UpdateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAddressCommand command)
    {
        Address value = await _repository.GetByIdAsync(command.Id);
        value.UserId = command.UserId;
        value.Name = command.Name;
        value.Surname = command.Surname;
        value.Email = command.Email;
        value.Phone = command.Phone;
        value.Line1 = command.Line1;
        value.Line2 = command.Line2;
        value.District = command.District;
        value.City = command.City;
        value.Country = command.Country;
        value.ZipCode = command.ZipCode;

        await _repository.UpdateAsync(value);
    }
}
