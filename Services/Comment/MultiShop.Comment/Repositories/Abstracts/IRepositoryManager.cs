namespace MultiShop.Comment.Repositories.Abstracts
{
    public interface IRepositoryManager
    {
        IUserCommentRepository UserComment {  get; }
        IContactRepository Contact { get; }
    }
}
