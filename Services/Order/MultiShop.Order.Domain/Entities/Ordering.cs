using MultiShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Domain.Entities;

public class Ordering : EfEntityBase
{
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}
