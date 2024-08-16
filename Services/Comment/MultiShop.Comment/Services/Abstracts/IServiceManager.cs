namespace MultiShop.Comment.Services.Abstracts
{
    public interface IServiceManager
    {
        IUserCommentService UserCommentService { get; }
        IContactService ContactService { get; }
    }
}
