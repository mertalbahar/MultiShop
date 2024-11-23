using MultiShop.Message.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IUserMessageRepository _userMessageRepository;

        public RepositoryManager(IUserMessageRepository userMessageRepository)
        {
            _userMessageRepository = userMessageRepository;
        }

        public IUserMessageRepository UserMessageRepository => _userMessageRepository;
    }
}
