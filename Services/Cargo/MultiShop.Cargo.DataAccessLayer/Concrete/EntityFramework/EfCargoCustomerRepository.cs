using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Cargo.DataAccessLayer.Concrete.EntityFramework;

public class EfCargoCustomerRepository : EfRepositoryBase<CargoCustomer, CargoContext>, ICargoCustomerRepository
{
    public EfCargoCustomerRepository(CargoContext context) : base(context)
    {
    }
}
