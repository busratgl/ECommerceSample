using ECommerceSample.Application.Repositories.User;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.User;

public class UserReadRepository : ReadRepository<Domain.Entities.User>, IUserReadRepository
{
    public UserReadRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}