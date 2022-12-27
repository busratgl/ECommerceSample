using ECommerceSample.Domain.Entities;
using ECommerceSample.Domain.Entities.Common;
using ECommerceSample.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSample.Persistence.Contexts;

public class ECommerceSampleDbContext : DbContext
{
    public ECommerceSampleDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BasketConfiguration());
        modelBuilder.ApplyConfiguration(new BasketItemConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        //ChangeTracker:Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. 
        //Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

        var data = ChangeTracker.Entries<BaseEntity>();
        // ne kadar data geliyorsa burada yakalıyoruz.

        foreach (var eachData in data)
        {
            _ = eachData.State switch
            {
                EntityState.Added => eachData.Entity.CreatedDate = DateTime.Now,
                EntityState.Modified => eachData.Entity.ModifiedDate = DateTime.Now,
                _ => DateTime.Now

                //ne create ne modified ise "  _ =>DateTime.Now" geri döndürsün.
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}