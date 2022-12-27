using ECommerceSample.Application.Repositories.Order;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Order;

public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
{
    public OrderWriteRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}