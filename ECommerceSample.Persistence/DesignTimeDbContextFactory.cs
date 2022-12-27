using ECommerceSample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerceSample.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceSampleDbContext>
{
    public ECommerceSampleDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ECommerceSampleDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);

        return new(dbContextOptionsBuilder.Options);
    }
}