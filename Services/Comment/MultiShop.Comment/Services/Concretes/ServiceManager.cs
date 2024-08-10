using MultiShop.Comment.Services.Abstracts;

namespace MultiShop.Comment.Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUserCommentService _userCommentService;

        public ServiceManager(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        public IUserCommentService UserCommentService => _userCommentService;
    }
}
