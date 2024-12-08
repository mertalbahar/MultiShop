using MultiShop.Comment.WebApi.Services.Abstracts;

namespace MultiShop.Comment.WebApi.Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUserCommentService _userCommentService;
        private readonly IContactService _contactService;

        public ServiceManager(IUserCommentService userCommentService, IContactService contactService)
        {
            _userCommentService = userCommentService;
            _contactService = contactService;
        }

        public IUserCommentService UserCommentService => _userCommentService;

        public IContactService ContactService => _contactService;
    }
}
