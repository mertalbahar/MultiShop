using MultiShop.Comment.WebApi.Repositories.Abstracts;
using MultiShop.Comment.WebApi.Services.Abstracts;

namespace MultiShop.Comment.WebApi.Services.Concretes
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepositoryManager _manager;

        public StatisticService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public int GetActiveCommentCount()
        {
            int value = _manager.UserComment.GetList(x => x.Status.Equals(true)).Count();

            return value;
        }

        public int GetPassiveCommentCount()
        {
            int value = _manager.UserComment.GetList(x => x.Status.Equals(false)).Count();

            return value;
        }

        public int GetTotalCommentCount()
        {
            int value = _manager.UserComment.GetList().Count();

            return value;
        }
    }
}
