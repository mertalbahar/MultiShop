using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoOperationManager : ICargoOperationService
{
    private readonly IRepositoryManager _manager;

    public CargoOperationManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public void TDelete(int id)
    {
        CargoOperation cargoOperation = TGetById(id);
        _manager.CargoOperationRepository.Delete(cargoOperation);
    }

    public IList<CargoOperation> TGetAll()
    {
        return _manager.CargoOperationRepository.GetList();
    }

    public CargoOperation TGetById(int id)
    {
        return _manager.CargoOperationRepository.Get(x => x.Id.Equals(id));
    }

    public void TInsert(CargoOperation entity)
    {
        _manager.CargoOperationRepository.Add(entity);
    }

    public void TUpdate(CargoOperation entity)
    {
        _manager.CargoOperationRepository.Update(entity);
    }
}
