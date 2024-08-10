using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Entities
{
    public class EfEntityBase : IEntityBase<int>
    {
        public int Id { get; set; }
    }
}
