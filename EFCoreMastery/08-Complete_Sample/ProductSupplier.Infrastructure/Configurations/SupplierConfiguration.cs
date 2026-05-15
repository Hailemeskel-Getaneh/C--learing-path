using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; // for fluent API
using ProductSupplier.Domain.Entities;

namespace ProductSupplier.Infrastructure.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.CompanyName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.Email)
            .HasMaxLength(100);

        builder.Property(s => s.Phone)
            .HasMaxLength(30);

        builder.Property(s => s.Address)
            .HasMaxLength(250);

        builder.HasQueryFilter(s => !s.IsDeleted);
    }
}