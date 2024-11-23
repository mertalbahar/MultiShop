using MultiShop.Core.Repositories.Concretes;
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
    public class OrderingRepository : EfRepositoryBase<Ordering, OrderContext>, IOrderingRepository
    {
        public OrderingRepository(OrderContext context) : base(context)
        {
        }
    }
}
