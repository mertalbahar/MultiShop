using MultiShop.Comment.Contexts;
using MultiShop.Comment.Repositories.Abstracts;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CommentContex _context;
        private readonly IUserCommentRepository _userCommentRepository;
        private readonly IContactRepository _contactRepository;

        public RepositoryManager(CommentContex context, IUserCommentRepository userCommentRepository, IContactRepository contactRepository)
        {
            _context = context;
            _userCommentRepository = userCommentRepository;
            _contactRepository = contactRepository;
        }

        public IUserCommentRepository UserComment => _userCommentRepository;

        public IContactRepository Contact => _contactRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
