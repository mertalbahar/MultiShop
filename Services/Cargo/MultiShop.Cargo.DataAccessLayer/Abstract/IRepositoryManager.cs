using MultiShop.Cargo.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccess.Abstract
{
    public interface IRepositoryManager
    {
        ICargoCompanyRepository CargoCompanyRepository { get; }
        ICargoCustomerRepository CargoCustomerRepository { get; }
        ICargoDetailRepository CargoDetailRepository { get; }
        ICargoOperationRepository CargoOperationRepository { get; }
    }
}
