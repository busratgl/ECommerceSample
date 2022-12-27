using ECommerceSample.Application.Repositories.Category;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Category;

public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
{
    public CategoryReadRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}