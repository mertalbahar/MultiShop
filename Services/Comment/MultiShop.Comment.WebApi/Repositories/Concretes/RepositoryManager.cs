using MultiShop.Comment.Repositories.Abstracts;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IUserCommentRepository _userCommentRepository;
        private readonly IContactRepository _contactRepository;

        public RepositoryManager(IUserCommentRepository userCommentRepository, IContactRepository contactRepository)
        {
            _userCommentRepository = userCommentRepository;
            _contactRepository = contactRepository;
        }

        public IUserCommentRepository UserComment => _userCommentRepository;

        public IContactRepository Contact => _contactRepository;
    }
}
