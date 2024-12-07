using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoDetailRepository : EfRepositoryBase<CargoDetail, CargoContext>, ICargoDetailRepository
{
    public EfCargoDetailRepository(CargoContext context) : base(context)
    {
    }
}
