using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Abstract
{
    public interface IServiceManager
    {
        ICargoCompanyService CargoCompanyService { get; }
        ICargoCustomerService CargoCustomerService { get; }
    }
}
