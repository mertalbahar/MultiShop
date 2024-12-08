using MultiShop.Comment.WebApi.Contexts;
using MultiShop.Comment.WebApi.Entities;
using MultiShop.Comment.WebApi.Repositories.Abstracts;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Comment.WebApi.Repositories.Concretes
{
    public class ContactRepository : EfRepositoryBase<Contact, CommentContex>, IContactRepository
    {
        public ContactRepository(CommentContex context) : base(context)
        {
        }
    }
}
