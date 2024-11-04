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
        private readonly MessageContext _context;
        private readonly IUserMessageRepository _userMessageRepository;

        public RepositoryManager(MessageContext context, IUserMessageRepository userMessageRepository)
        {
            _context = context;
            _userMessageRepository = userMessageRepository;
        }

        public IUserMessageRepository UserMessageRepository => _userMessageRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
