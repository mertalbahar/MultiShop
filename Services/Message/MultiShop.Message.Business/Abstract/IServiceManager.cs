using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Business.Abstract
{
    public interface IServiceManager
    {
        IUserMessageService UserMessageService { get; }
    }
}
