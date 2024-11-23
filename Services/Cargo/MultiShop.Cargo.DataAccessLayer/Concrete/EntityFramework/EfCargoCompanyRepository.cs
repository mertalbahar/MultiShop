using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Core.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Concrete.EntityFramework;

public class EfCargoCompanyRepository : EfRepositoryBase<CargoCompany, CargoContext>, ICargoCompanyRepository
{
    public EfCargoCompanyRepository(CargoContext context) : base(context)
    {
    }
}
