using MultiShop.Message.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUserMessageService _userMessageService;

        public ServiceManager(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        public IUserMessageService UserMessageService => _userMessageService;
    }
}
