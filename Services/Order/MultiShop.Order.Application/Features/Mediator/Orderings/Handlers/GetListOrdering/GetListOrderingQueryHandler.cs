using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetListOrdering;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Handlers.GetListOrdering;

public class GetListOrderingQueryHandler : IRequestHandler<GetListOrderingQuery, List<OrderingListDto>>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public GetListOrderingQueryHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<List<OrderingListDto>> Handle(GetListOrderingQuery request, CancellationToken cancellationToken)
    {
        List<Ordering> listedOrdering = await _manager.OrderingRepository.GetAllAsync();
        List<OrderingListDto> orderingListDto = _mapper.Map<List<OrderingListDto>>(listedOrdering);

        return orderingListDto;
    }
}
