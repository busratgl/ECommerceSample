using ECommerceSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSample.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(75);
        builder.Property(p => p.UnitsInStock).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.CreatedDate).IsRequired();
        builder.Property(p => p.ModifiedDate).IsRequired();
        builder.Property(p => p.IsDeleted).IsRequired();

        builder.HasOne<Category>(p => p.Category).WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
        builder.ToTable("Products");
    }
}