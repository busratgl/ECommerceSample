using System.Linq.Expressions;
using ECommerceSample.Application.Repositories;
using ECommerceSample.Domain.Entities.Common;
using ECommerceSample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly ECommerceSampleDbContext _context;

    public ReadRepository(ECommerceSampleDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
    {
        var query = Table.AsQueryable().AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
    {
        var query = Table.Where(expression).AsNoTracking();
        return query;
    }

    public async Task<T> SingleGetAsync(Expression<Func<T, bool>> expression)
    {
        var query = Table.AsQueryable().AsNoTracking();
        return await query.SingleOrDefaultAsync(expression);
    }

    public async Task<T> GetByIdAsync(long id)
    {
        var query = Table.AsQueryable().AsNoTracking();
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}