using MultiShop.Core.Entities;

namespace MultiShop.Comment.Entities
{
    public class Contact : EfEntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
