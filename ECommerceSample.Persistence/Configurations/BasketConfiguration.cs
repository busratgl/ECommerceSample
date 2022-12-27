using ECommerceSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSample.Persistence.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.CreatedDate).IsRequired();
        builder.Property(b => b.ModifiedDate).IsRequired();
        builder.Property(b => b.IsDeleted).IsRequired();

        builder.HasOne<User>(b => b.User).WithOne(u => u.Basket)
            .HasForeignKey<Basket>(b => b.UserId);
        builder.ToTable("Baskets");
    }
}