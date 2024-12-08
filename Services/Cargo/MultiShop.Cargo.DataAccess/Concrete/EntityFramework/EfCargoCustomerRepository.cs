using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoCustomerRepository : EfRepositoryBase<CargoCustomer, CargoContext>, ICargoCustomerRepository
{
    public EfCargoCustomerRepository(CargoContext context) : base(context)
    {
    }
}
