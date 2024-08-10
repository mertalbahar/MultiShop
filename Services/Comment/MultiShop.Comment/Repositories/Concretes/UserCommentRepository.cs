using MultiShop.Comment.Contexts;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Repositories.Abstracts;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class UserCommentRepository : RepositoryBase<UserComment>, IUserCommentRepository
    {
        public UserCommentRepository(CommentContex context) : base(context)
        {
        }
    }
}
