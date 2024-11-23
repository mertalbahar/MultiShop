using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoDetailManager : ICargoDetailService
{
    private readonly IRepositoryManager _manager;

    public CargoDetailManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public void TDelete(int id)
    {
        CargoDetail cargoDetail = TGetById(id);
        _manager.CargoDetailRepository.Delete(cargoDetail);
    }

    public IList<CargoDetail> TGetAll()
    {
        return _manager.CargoDetailRepository.GetList();
    }

    public CargoDetail TGetById(int id)
    {
        return _manager.CargoDetailRepository.Get(x => x.Id.Equals(id));
    }

    public void TInsert(CargoDetail entity)
    {
        _manager.CargoDetailRepository.Add(entity);
    }

    public void TUpdate(CargoDetail entity)
    {
        _manager.CargoDetailRepository.Update(entity);
    }
}
