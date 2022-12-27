using ECommerceSample.Application.Repositories.User;
using ECommerceSample.Persistence.Contexts;

namespace ECommerceSample.Persistence.Repositories.User;

public class UserWriteRepository : WriteRepository<Domain.Entities.User>, IUserWriteRepository
{
    public UserWriteRepository(ECommerceSampleDbContext context) : base(context)
    {
    }
}