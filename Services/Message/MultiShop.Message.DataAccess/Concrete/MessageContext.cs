using Microsoft.EntityFrameworkCore;
using MultiShop.Message.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Concrete
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
        }

        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
