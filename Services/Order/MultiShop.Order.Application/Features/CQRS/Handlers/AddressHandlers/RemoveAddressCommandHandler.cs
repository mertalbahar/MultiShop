using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler
{
    private readonly IAsyncRepository<Address> _repository;

    public RemoveAddressCommandHandler(IAsyncRepository<Address> repository)
    {
        _repository = repository;
    }

    //public async Task Handle(RemoveAddressCommand command)
    //{
    //    Address value = await _repository.GetByIdAsync(command.Id);
    //    await _repository.DeleteAsync(value);
    //}
}
