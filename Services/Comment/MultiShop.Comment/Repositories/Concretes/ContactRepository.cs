using MultiShop.Comment.Contexts;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Repositories.Abstracts;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(CommentContex context) : base(context)
        {
        }
    }
}
