using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Application.Repositories;

public interface IWriteRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    Task<bool> CreateAsync(T model);
    Task<bool> CreateRangeAsync(List<T> data);
    bool Update(T model);
    bool Delete(T model);
    Task<bool> DeleteAsync(long id);
    bool DeleteRange(List<T> data);
    Task<T> FindAsync(long id);
    Task<int> SaveAsync();
}