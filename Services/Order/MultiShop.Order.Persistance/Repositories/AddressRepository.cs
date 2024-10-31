using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistance.Context;

namespace MultiShop.Order.Persistance.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(OrderContext context) : base(context)
        {
        }
    }
}
