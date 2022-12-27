using ECommerceSample.Application.Repositories.Product;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Product;

public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
{
    public ProductReadRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}