using ECommerceSample.Application.Repositories.OrderItem;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.OrderItem;

public class OrderItemWriteRepository : WriteRepository<Domain.Entities.OrderItem>, IOrderItemWriteRepository
{
    public OrderItemWriteRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}