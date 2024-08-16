using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Contexts;
using MultiShop.Comment.Repositories.Abstracts;
using System.Linq.Expressions;

namespace MultiShop.Comment.Repositories.Concretes
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class, new()
    {
        protected readonly CommentContex _context;

        protected RepositoryBase(CommentContex context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                    ? _context.Set<T>()
                : _context.Set<T>().Where(expression);
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
