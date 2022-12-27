using ECommerceSample.Application.Repositories;
using ECommerceSample.Domain.Entities.Common;
using ECommerceSample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceSample.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly ECommerceSampleDbContext _context;

    public WriteRepository(ECommerceSampleDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> CreateAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> CreateRangeAsync(List<T> data)
    {
        await Table.AddRangeAsync(data);
        return true;
    }

    public bool Update(T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        T model = await Table.FirstOrDefaultAsync(x => x.Id == id);
        return Delete(model);
    }

    public bool Delete(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool DeleteRange(List<T> data)
    {
        Table.RemoveRange(data);
        return true;
    }

    public async Task<T> FindAsync(long id)
    {
        var response = await Table.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        return response;
    }

    public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();
}