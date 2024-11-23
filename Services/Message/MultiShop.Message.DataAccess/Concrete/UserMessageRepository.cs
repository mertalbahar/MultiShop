using MultiShop.Core.Repositories.Concretes;
using MultiShop.Message.DataAccess.Abstract;
using MultiShop.Message.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Concrete
{
    public class UserMessageRepository : EfRepositoryBase<UserMessage, MessageContext>, IUserMessageRepository
    {
        public UserMessageRepository(MessageContext context) : base(context)
        {
        }
    }
}
