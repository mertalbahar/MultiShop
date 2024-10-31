using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Addresses.Dtos;
using MultiShop.Order.Application.Features.Mediator.Addresses.Queries.GetListAddress;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Addresses.Handlers.GetListAddress;

public class GetListAddressQueryHandler : IRequestHandler<GetListAddressQuery, List<GetListAddressDto>>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public GetListAddressQueryHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<List<GetListAddressDto>> Handle(GetListAddressQuery request, CancellationToken cancellationToken)
    {
        List<Address> listedAddress = await _manager.AddressRepository.GetAllAsync();
        List<GetListAddressDto> getListAddressDto = _mapper.Map<List<GetListAddressDto>>(listedAddress);

        return getListAddressDto;
    }
}
