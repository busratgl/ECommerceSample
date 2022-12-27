using ECommerceSample.Application.Repositories.Basket;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.Basket;

public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>, IBasketReadRepository
{
    public BasketReadRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}