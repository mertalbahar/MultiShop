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

        public ServiceManager(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public ICargoCompanyService CargoCompanyService => _cargoCompanyService;
    }
}
