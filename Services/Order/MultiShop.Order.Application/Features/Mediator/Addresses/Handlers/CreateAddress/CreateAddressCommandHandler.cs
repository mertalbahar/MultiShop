using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.CreateAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Handlers.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public CreateAddressCommandHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<CreatedAddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        Address mappedAddress = _mapper.Map<Address>(request);
        Address createdAddress = await _manager.AddressRepository.AddAsync(mappedAddress);
        CreatedAddressDto createdAddressDto = _mapper.Map<CreatedAddressDto>(createdAddress);

        return createdAddressDto;
    }
}
