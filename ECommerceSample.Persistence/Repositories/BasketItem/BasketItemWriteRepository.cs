using ECommerceSample.Application.Repositories.BasketItem;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.BasketItem;

public class BasketItemWriteRepository : WriteRepository<Domain.Entities.BasketItem>, IBasketItemWriteRepository
{
    public BasketItemWriteRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}