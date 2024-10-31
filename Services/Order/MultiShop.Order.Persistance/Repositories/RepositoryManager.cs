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
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public RepositoryManager(IOrderingRepository orderingRepository, IAddressRepository addressRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderingRepository = orderingRepository;
            _addressRepository = addressRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public IOrderingRepository OrderingRepository => _orderingRepository;

        public IAddressRepository AddressRepository => _addressRepository;

        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
    }
}
