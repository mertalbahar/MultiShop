using System.Linq.Expressions;

namespace MultiShop.Order.Application.Services.Repositories;

public interface IAsyncRepository<T>
    where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
