using MultiShop.Comment.Contexts;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Repositories.Abstracts;
using MultiShop.Core.Repositories.Concretes;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class UserCommentRepository : EfRepositoryBase<UserComment, CommentContex>, IUserCommentRepository
    {
        public UserCommentRepository(CommentContex context) : base(context)
        {
        }
    }
}
