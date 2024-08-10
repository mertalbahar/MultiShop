using MultiShop.Comment.Contexts;
using MultiShop.Comment.Repositories.Abstracts;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CommentContex _context;
        private readonly IUserCommentRepository _userCommentRepository;

        public RepositoryManager(CommentContex context, IUserCommentRepository userCommentRepository)
        {
            _context = context;
            _userCommentRepository = userCommentRepository;
        }

        public IUserCommentRepository UserComment => _userCommentRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
