using System.Linq.Expressions;
using ECommerceSample.Domain.Entities.Common;

namespace ECommerceSample.Application.Repositories;

public interface IReadRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();

    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);

    //Şarta uygun birden fazla veriyi elde edebilmek için.
    Task<T> SingleGetAsync(Expression<Func<T, bool>> expression); //Şarta uygun olanlardan ilkini getirir.
    Task<T> GetByIdAsync(long id);
}