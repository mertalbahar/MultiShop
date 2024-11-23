using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Abstract
{
    public interface IRepositoryManager
    {
        IUserMessageRepository UserMessageRepository { get; }
    }
}
