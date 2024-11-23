using MultiShop.Core.Repositories.Abstracts;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Services.Repositories
{
    public interface IOrderDetailRepository : IAsyncRepository<OrderDetail>
    {
    }
}
