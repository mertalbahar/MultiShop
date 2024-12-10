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
        private readonly IStatisticService _statisticService;

        public ServiceManager(IUserMessageService userMessageService, IStatisticService statisticService)
        {
            _userMessageService = userMessageService;
            _statisticService = statisticService;
        }

        public IUserMessageService UserMessageService => _userMessageService;

        public IStatisticService StatisticService => _statisticService;
    }
}
