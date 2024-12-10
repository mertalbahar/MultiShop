using MultiShop.Comment.WebApi.Services.Abstracts;

namespace MultiShop.Comment.WebApi.Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUserCommentService _userCommentService;
        private readonly IContactService _contactService;
        private readonly IStatisticService _statisticService;

        public ServiceManager(IUserCommentService userCommentService, IContactService contactService, IStatisticService statisticService)
        {
            _userCommentService = userCommentService;
            _contactService = contactService;
            _statisticService = statisticService;
        }

        public IUserCommentService UserCommentService => _userCommentService;

        public IContactService ContactService => _contactService;

        public IStatisticService StatisticService => _statisticService;
    }
}
