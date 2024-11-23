using MultiShop.Comment.Contexts;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Repositories.Abstracts;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class ContactRepository : EfRepositoryBase<Contact, CommentContex>, IContactRepository
    {
        public ContactRepository(CommentContex context) : base(context)
        {
        }
    }
}
