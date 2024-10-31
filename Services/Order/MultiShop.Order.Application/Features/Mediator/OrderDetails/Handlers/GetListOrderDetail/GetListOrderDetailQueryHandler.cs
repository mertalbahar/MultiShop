using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Dtos;
using MultiShop.Order.Application.Features.Mediator.OrderDetails.Queries.GetListOrderDetail;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.OrderDetails.Handlers.GetListOrderDetail;

public class GetListOrderDetailQueryHandler : IRequestHandler<GetListOrderDetailQuery, List<GetListOrderDetailDto>>
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public GetListOrderDetailQueryHandler(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<List<GetListOrderDetailDto>> Handle(GetListOrderDetailQuery request, CancellationToken cancellationToken)
    {
        List<OrderDetail> listedOrderDetail = await _manager.OrderDetailRepository.GetAllAsync();
        List<GetListOrderDetailDto> getListOrderDetailDto = _mapper.Map<List<GetListOrderDetailDto>>(listedOrderDetail);

        return getListOrderDetailDto;
    }
}
