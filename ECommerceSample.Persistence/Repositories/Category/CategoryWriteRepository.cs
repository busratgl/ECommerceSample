using ECommerceSample.Application.Repositories.Category;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Category;

public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}