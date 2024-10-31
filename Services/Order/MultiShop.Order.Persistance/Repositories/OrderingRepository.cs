using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistance.Repositories
{
    public class OrderingRepository : RepositoryBase<Ordering>, IOrderingRepository
    {
        public OrderingRepository(OrderContext context) : base(context)
        {
        }
    }
}
