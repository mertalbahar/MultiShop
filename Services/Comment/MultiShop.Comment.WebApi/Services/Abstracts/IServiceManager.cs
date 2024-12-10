namespace MultiShop.Comment.WebApi.Services.Abstracts
{
    public interface IServiceManager
    {
        IUserCommentService UserCommentService { get; }
        IContactService ContactService { get; }
        IStatisticService StatisticService { get; }
    }
}
