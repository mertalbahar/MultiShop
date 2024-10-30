using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Persistance.Context;
using System.Linq.Expressions;

namespace MultiShop.Order.Persistance.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T>
    where T : class
{
    private readonly OrderContext _context;

    public RepositoryBase(OrderContext context)
    {
        _context = context;
    }

    public async Task<T> CreateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await  _context.SaveChangesAsync();

        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        return filter == null
            ? await _context.Set<T>().ToListAsync()
            : await _context.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(filter);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }
}
