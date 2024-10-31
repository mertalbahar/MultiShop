using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Commands.CreateOrdering;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Handlers.CreateOrdering;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand, CreatedOrderingDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public CreateOrderingCommandHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<CreatedOrderingDto> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        Ordering mappedOrdering = _mapper.Map<Ordering>(request);
        Ordering createdOrdering = await _manager.OrderingRepository.CreateAsync(mappedOrdering);
        CreatedOrderingDto createdOrderingDto = _mapper.Map<CreatedOrderingDto>(createdOrdering);

        return createdOrderingDto;
    }
}
