using MultiShop.Core.Repositories.Abstracts;
using MultiShop.Message.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Abstract
{
    public interface IUserMessageRepository : IAsyncRepository<UserMessage>
    {
    }
}
