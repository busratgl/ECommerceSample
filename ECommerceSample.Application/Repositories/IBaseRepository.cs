using ECommerceSample.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}