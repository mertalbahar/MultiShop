namespace MultiShop.Comment.WebApi.Repositories.Abstracts
{
    public interface IRepositoryManager
    {
        IUserCommentRepository UserComment {  get; }
        IContactRepository Contact { get; }
    }
}
