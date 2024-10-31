using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Services.Repositories
{
    public interface IRepositoryManager
    {
        IOrderingRepository OrderingRepository { get; }
        IAddressRepository AddressRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
    }
}
