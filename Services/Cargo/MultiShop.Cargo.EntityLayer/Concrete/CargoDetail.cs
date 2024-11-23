using MultiShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntityLayer.Concrete;

public class CargoDetail : EfEntityBase
{
    public int CargoCompanyId { get; set; }
    public string SenderCustomer { get; set; }
    public string ReceiverCustomer { get; set; }
    public int Barcode { get; set; }

    public CargoCompany CargoCompany { get; set; }
}
