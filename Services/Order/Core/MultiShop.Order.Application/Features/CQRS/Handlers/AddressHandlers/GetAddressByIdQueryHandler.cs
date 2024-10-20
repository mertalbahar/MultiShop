using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IRepository<Address> _repository;

    public GetAddressByIdQueryHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
    {
        Address values = await _repository.GetByIdAsync(query.Id);
        return new GetAddressByIdQueryResult
        {
            Id = values.Id,
            UserId = values.UserId,
            Name = values.Name,
            Surname = values.Surname,
            Email = values.Email,
            Phone = values.Phone,
            Line1 = values.Line1,
            Line2 = values.Line2,
            District = values.District,
            City = values.City,
            Country = values.Country,
            ZipCode = values.ZipCode
        };
    }
}
