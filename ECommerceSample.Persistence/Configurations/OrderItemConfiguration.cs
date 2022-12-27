using ECommerceSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSample.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id).ValueGeneratedOnAdd();
        builder.Property(oi => oi.CreatedDate).IsRequired();
        builder.Property(oi => oi.ModifiedDate).IsRequired();
        builder.Property(oi => oi.IsDeleted).IsRequired();

        builder.HasOne<Product>(bi => bi.Product).WithMany(p => p.OrderItems)
            .HasForeignKey(bi => bi.ProductId);
        builder.HasOne<Order>(oi => oi.Order).WithMany(o => o.OrderItems)
            .HasForeignKey(bi => bi.OrderId);
        builder.ToTable("OrderItems");
    }
}