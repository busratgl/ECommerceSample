using ECommerceSample.Application.Repositories.Product;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Product;

public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}