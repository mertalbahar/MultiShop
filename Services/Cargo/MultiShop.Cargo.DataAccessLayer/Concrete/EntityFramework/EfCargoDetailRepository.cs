using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Cargo.DataAccessLayer.Concrete.EntityFramework;

public class EfCargoDetailRepository : EfRepositoryBase<CargoDetail, CargoContext>, ICargoDetailRepository
{
    public EfCargoDetailRepository(CargoContext context) : base(context)
    {
    }
}
