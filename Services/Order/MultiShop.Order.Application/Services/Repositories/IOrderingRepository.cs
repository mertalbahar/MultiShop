﻿using MultiShop.Core.Repositories.Abstracts;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Services.Repositories
{
    public interface IOrderingRepository : IAsyncRepository<Ordering>
    {
    }
}
