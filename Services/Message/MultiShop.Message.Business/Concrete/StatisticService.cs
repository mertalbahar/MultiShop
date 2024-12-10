using MultiShop.Message.Business.Abstract;
using MultiShop.Message.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Business.Concrete
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepositoryManager _manager;

        public StatisticService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<int> GetTotalMessageCountAsync()
        {
            var userMessages = await _manager.UserMessageRepository.GetListAsync();
            var result = userMessages?.Count ?? 0;

            return result;
        }
    }
}
