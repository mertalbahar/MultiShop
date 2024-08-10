using System.Linq.Expressions;

namespace MultiShop.Comment.Repositories.Abstracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(Expression<Func<T, bool>> expression = null);
        T? FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
