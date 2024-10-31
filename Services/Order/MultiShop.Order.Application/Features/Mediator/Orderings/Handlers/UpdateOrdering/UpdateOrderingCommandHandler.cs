using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.UpdateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Handlers.UpdateOrdering;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand, UpdatedOrderingDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public UpdateOrderingCommandHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<UpdatedOrderingDto> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        Ordering getOrdering = await _manager.OrderingRepository.GetByFilterAsync(x => x.Id.Equals(request.Id));
        Ordering mappedOrdering = _mapper.Map(request, getOrdering);
        Ordering updatedOrdering = await _manager.OrderingRepository.UpdateAsync(mappedOrdering);
        UpdatedOrderingDto updatedOrderingDto = _mapper.Map<UpdatedOrderingDto>(updatedOrdering);

        return updatedOrderingDto;
    }
}
