using MultiShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Entity.Concrete
{
    public class UserMessage : EfEntityBase
    {
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedDate { get; set; }
    }
}
