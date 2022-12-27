using ECommerceSample.Application.Repositories.Basket;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Basket;

public class BasketWriteRepository : WriteRepository<Domain.Entities.Basket>, IBasketWriteRepository
{
    public BasketWriteRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}