using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using MultiShop.Order.Application.Features.Mediator.Addresses.Queries.GetByIdAddress;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Handlers.GetByIdAddress;

public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GetByIdAddressDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public GetByIdAddressQueryHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<GetByIdAddressDto> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
    {
        Address address = await _manager.AddressRepository.GetByFilterAsync(x => x.Id.Equals(request.Id));
        GetByIdAddressDto getByIdAddressDto = _mapper.Map<GetByIdAddressDto>(address);

        return getByIdAddressDto;
    }
}
