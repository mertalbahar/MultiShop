using MultiShop.Order.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistance.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IOrderingRepository _orderingRepository;

        public RepositoryManager(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public IOrderingRepository OrderingRepository => _orderingRepository;
    }
}
