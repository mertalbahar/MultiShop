using MultiShop.Core.Entities;

namespace MultiShop.Comment.WebApi.Entities
{
    public class UserComment : EfEntityBase
    {
        public string ProductId { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;
    }
}
