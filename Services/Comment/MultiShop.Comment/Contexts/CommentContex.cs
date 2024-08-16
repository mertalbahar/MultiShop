using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Contexts
{
    public class CommentContex : DbContext
    {
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public CommentContex(DbContextOptions<CommentContex> options) : base(options)
        {
        }
    }
}
