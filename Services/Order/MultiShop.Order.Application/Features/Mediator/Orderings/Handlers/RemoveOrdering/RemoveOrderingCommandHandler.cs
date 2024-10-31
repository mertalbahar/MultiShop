using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.RemoveOrdering;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Handlers.RemoveOrdering;

public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
{
    private readonly IRepositoryManager _manager;

    public RemoveOrderingCommandHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        Ordering ordering = await _manager.OrderingRepository.GetByFilterAsync(x => x.Id.Equals(request.Id));
        await _manager.OrderingRepository.DeleteAsync(ordering);
    }
}
