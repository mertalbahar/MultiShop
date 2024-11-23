using Microsoft.EntityFrameworkCore.Query;
using MultiShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Repositories.Abstracts
{
    public interface IAsyncRepository<T>
        where T : EfEntityBase
    {
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, bool enableTracking = true,
            CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
