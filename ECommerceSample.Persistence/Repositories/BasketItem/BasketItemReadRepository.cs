using ECommerceSample.Application.Repositories.BasketItem;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.BasketItem;

public class BasketItemReadRepository : ReadRepository<Domain.Entities.BasketItem>, IBasketItemReadRepository
{
    public BasketItemReadRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}