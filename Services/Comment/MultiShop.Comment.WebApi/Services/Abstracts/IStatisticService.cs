namespace MultiShop.Comment.WebApi.Services.Abstracts
{
    public interface IStatisticService
    {
        int GetActiveCommentCount();
        int GetPassiveCommentCount();
        int GetTotalCommentCount();
    }
}
