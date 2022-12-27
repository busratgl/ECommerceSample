using ECommerceSample.Application.Repositories.Order;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Order;

public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
{
    public OrderReadRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}