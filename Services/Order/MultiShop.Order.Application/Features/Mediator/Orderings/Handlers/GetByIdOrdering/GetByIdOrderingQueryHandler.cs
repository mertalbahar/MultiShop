using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetByIdOrdering;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Handlers.GetByIdOrdering;

public class GetByIdOrderingQueryHandler : IRequestHandler<GetByIdOrderingQuery, GetByIdOrderingDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public GetByIdOrderingQueryHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<GetByIdOrderingDto> Handle(GetByIdOrderingQuery request, CancellationToken cancellationToken)
    {
        Ordering ordering = await _manager.OrderingRepository.GetByFilterAsync(x => x.Id.Equals(request.Id));
        GetByIdOrderingDto getOrderingByIdDto = _mapper.Map<GetByIdOrderingDto>(ordering);

        return getOrderingByIdDto;
    }
}
