using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Abstract
{
    public interface IAsyncRepository<T>
        where T : class
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
