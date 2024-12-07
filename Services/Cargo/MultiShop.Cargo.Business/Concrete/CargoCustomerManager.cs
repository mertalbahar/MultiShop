using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.Business.Concrete;

public class CargoCustomerManager : ICargoCustomerService
{
    private readonly IRepositoryManager _manager;

    public CargoCustomerManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public void TDelete(int id)
    {
        CargoCustomer cargoCustomer = TGetById(id);
        _manager.CargoCustomerRepository.Delete(cargoCustomer);
    }

    public IList<CargoCustomer> TGetAll()
    {
        return _manager.CargoCustomerRepository.GetList();
    }

    public CargoCustomer TGetById(int id)
    {
        return _manager.CargoCustomerRepository.Get(x => x.Id.Equals(id));
    }

    public void TInsert(CargoCustomer entity)
    {
        _manager.CargoCustomerRepository.Add(entity);
    }

    public void TUpdate(CargoCustomer entity)
    {
        _manager.CargoCustomerRepository.Update(entity);
    }
}