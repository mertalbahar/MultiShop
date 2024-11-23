using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete;

public class CargoCompanyManager : ICargoCompanyService
{
    private readonly IRepositoryManager _manager;

    public CargoCompanyManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public void TDelete(int id)
    {
        CargoCompany cargoCompany = TGetById(id);
        _manager.CargoCompanyRepository.Delete(cargoCompany);
    }

    public IList<CargoCompany> TGetAll()
    {
        return _manager.CargoCompanyRepository.GetList();
    }

    public CargoCompany TGetById(int id)
    {
        return _manager.CargoCompanyRepository.Get(x => x.Id.Equals(id));
    }

    public void TInsert(CargoCompany entity)
    {
        _manager.CargoCompanyRepository.Add(entity);
    }

    public void TUpdate(CargoCompany entity)
    {
        _manager.CargoCompanyRepository.Update(entity);
    }
}
