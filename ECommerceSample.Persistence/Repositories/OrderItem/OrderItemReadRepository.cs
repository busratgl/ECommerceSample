using ECommerceSample.Application.Repositories.OrderItem;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.OrderItem;

public class OrderItemReadRepository : ReadRepository<Domain.Entities.OrderItem>, IOrderItemReadRepository
{
    public OrderItemReadRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}