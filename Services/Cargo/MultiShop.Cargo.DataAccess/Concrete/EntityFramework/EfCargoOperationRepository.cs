using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoOperationRepository : EfRepositoryBase<CargoOperation, CargoContext>, ICargoOperationRepository
{
    public EfCargoOperationRepository(CargoContext context) : base(context)
    {
    }
}
