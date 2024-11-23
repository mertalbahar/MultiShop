using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Dtos;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetByIdOrderDetail;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Handlers.GetByIdOrderDetail;

public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQuery, GetByIdOrderDetailDto>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public GetByIdOrderDetailQueryHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<GetByIdOrderDetailDto> Handle(GetByIdOrderDetailQuery request, CancellationToken cancellationToken)
    {
        OrderDetail OrderDetail = await _manager.OrderDetailRepository.GetAsync(x => x.Id.Equals(request.Id));
        GetByIdOrderDetailDto getByIdOrderDetailDto = _mapper.Map<GetByIdOrderDetailDto>(OrderDetail);

        return getByIdOrderDetailDto;
    }
}
