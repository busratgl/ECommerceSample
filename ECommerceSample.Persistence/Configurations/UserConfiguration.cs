using ECommerceSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceSample.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Address).IsRequired().HasMaxLength(250);
        builder.Property(u => u.BirthDate).IsRequired();
        builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Property(u => u.EmailAddress).IsRequired().HasMaxLength(50);
        builder.HasIndex(u => u.EmailAddress).IsUnique();
        builder.Property(u => u.CreatedDate).IsRequired();
        builder.Property(u => u.ModifiedDate).IsRequired();
        builder.Property(u => u.IsDeleted).IsRequired();

        builder.ToTable("Users");
    }
}