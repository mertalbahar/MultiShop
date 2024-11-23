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
    public interface IRepository<T> : IQuery<T>
        where T : EfEntityBase
    {
        IList<T> GetList(Expression<Func<T, bool>>? predicate = null, bool enableTracking = true);
        T Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
