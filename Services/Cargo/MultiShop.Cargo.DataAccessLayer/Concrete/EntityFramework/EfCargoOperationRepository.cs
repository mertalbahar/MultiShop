using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Cargo.DataAccessLayer.Concrete.EntityFramework;

public class EfCargoOperationRepository : EfRepositoryBase<CargoOperation, CargoContext>, ICargoOperationRepository
{
    public EfCargoOperationRepository(CargoContext context) : base(context)
    {
    }
}
