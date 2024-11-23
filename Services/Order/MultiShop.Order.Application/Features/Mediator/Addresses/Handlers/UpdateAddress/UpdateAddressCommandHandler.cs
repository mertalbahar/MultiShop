using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Addresses.Commands.UpdateAddress;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Handlers.UpdateAddress;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdatedAddressDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<UpdatedAddressDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        Address getAddress = await _manager.AddressRepository.GetAsync(x => x.Id.Equals(request.Id));
        Address mappedAddress = _mapper.Map(request, getAddress);
        Address updatedAddress = await _manager.AddressRepository.UpdateAsync(mappedAddress);
        UpdatedAddressDto updatedAddressDto = _mapper.Map<UpdatedAddressDto>(updatedAddress);

        return updatedAddressDto;
    }
}
