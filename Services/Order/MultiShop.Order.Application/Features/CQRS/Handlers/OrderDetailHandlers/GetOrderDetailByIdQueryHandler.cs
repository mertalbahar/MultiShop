using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IAsyncRepository<OrderDetail> _repository;

    public GetOrderDetailByIdQueryHandler(IAsyncRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        OrderDetail values = await _repository.GetByFilterAsync(x => x.Id.Equals(query.Id));

        return new GetOrderDetailByIdQueryResult
        {
            Id = values.Id,
            OrderingId = values.OrderingId,
            ProductId = values.ProductId,
            ProductAmount = values.ProductAmount,
            ProductName = values.ProductName,
            ProductPrice = values.ProductPrice,
            ProductTotalPrice = values.ProductTotalPrice
        };
    }
}
