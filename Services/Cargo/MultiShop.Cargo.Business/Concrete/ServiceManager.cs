using MultiShop.Cargo.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public ServiceManager(ICargoCompanyService cargoCompanyService, ICargoCustomerService cargoCustomerService)
        {
            _cargoCompanyService = cargoCompanyService;
            _cargoCustomerService = cargoCustomerService;
        }

        public ICargoCompanyService CargoCompanyService => _cargoCompanyService;

        public ICargoCustomerService CargoCustomerService => _cargoCustomerService;
    }
}
