using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.DataAccess.Concrete
{
    public class RepositoryBase<T> : IAsyncRepository<T>
        where T : class
    {
        private readonly MessageContext _context;

        public RepositoryBase(MessageContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await _context.Set<T>().ToListAsync()
                : await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
