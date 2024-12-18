﻿using MultiShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Entity.Concrete;

public class CargoOperation : EfEntityBase
{
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}
