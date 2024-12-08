using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;
using MultiShop.Core.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoCompanyRepository : EfRepositoryBase<CargoCompany, CargoContext>, ICargoCompanyRepository
{
    public EfCargoCompanyRepository(CargoContext context) : base(context)
    {
    }
}
