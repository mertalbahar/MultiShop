using MultiShop.Message.DataAccess.Abstract;
using MultiShop.Message.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Concrete
{
    public class UserMessageRepository : RepositoryBase<UserMessage>, IUserMessageRepository
    {
        public UserMessageRepository(MessageContext context) : base(context)
        {
        }
    }
}
