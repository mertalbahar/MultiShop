using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    private readonly IAsyncRepository<Address> _repository;

    public GetAddressQueryHandler(IAsyncRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAddressQueryResult>> Handle()
    {
        List<Address> values = await _repository.GetAllAsync();

        return values.Select(x => new GetAddressQueryResult
        {
            Id = x.Id,
            UserId = x.UserId,
            Name = x.Name,
            Surname = x.Surname,
            Email = x.Email,
            Phone = x.Phone,
            Line1 = x.Line1,
            Line2 = x.Line2,
            District = x.District,
            City = x.City,
            Country = x.Country,
            ZipCode = x.ZipCode,
        }).ToList();
    }
}
