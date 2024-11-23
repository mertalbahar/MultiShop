using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccess.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ICargoCompanyRepository _cargoCompanyRepository;
        private readonly ICargoCustomerRepository _cargoCustomerRepository;
        private readonly ICargoDetailRepository _cargoDetailRepository;
        private readonly ICargoOperationRepository _cargoOperationRepository;

        public RepositoryManager(ICargoCompanyRepository cargoCompanyRepository, ICargoCustomerRepository cargoCustomerRepository, ICargoDetailRepository cargoDetailRepository, ICargoOperationRepository cargoOperationRepository)
        {
            _cargoCompanyRepository = cargoCompanyRepository;
            _cargoCustomerRepository = cargoCustomerRepository;
            _cargoDetailRepository = cargoDetailRepository;
            _cargoOperationRepository = cargoOperationRepository;
        }

        public ICargoCompanyRepository CargoCompanyRepository => _cargoCompanyRepository;

        public ICargoCustomerRepository CargoCustomerRepository => _cargoCustomerRepository;

        public ICargoDetailRepository CargoDetailRepository => _cargoDetailRepository;

        public ICargoOperationRepository CargoOperationRepository => _cargoOperationRepository;
    }
}
