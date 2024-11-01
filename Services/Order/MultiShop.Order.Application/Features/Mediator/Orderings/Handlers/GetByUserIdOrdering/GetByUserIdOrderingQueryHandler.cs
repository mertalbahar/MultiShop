using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Orderings.Dtos;
using MultiShop.Order.Application.Features.Mediator.Orderings.Queries.GetByUserIdOrdering;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Orderings.Handlers.GetByUserIdOrdering
{
    public class GetByUserIdOrderingQueryHandler : IRequestHandler<GetByUserIdOrderingQuery, List<GetListOrderingDto>>
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public GetByUserIdOrderingQueryHandler(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<List<GetListOrderingDto>> Handle(GetByUserIdOrderingQuery request, CancellationToken cancellationToken)
        {
            List<Ordering> ordering = await _manager.OrderingRepository.GetAllAsync(x => x.UserId.Equals(request.UserId));
            List<GetListOrderingDto> getListOrderingDto = _mapper.Map<List<GetListOrderingDto>>(ordering);

            return getListOrderingDto;
        }
    }
}
