using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class EstateConfig : IEntityTypeConfiguration<Estate>
{
    public void Configure(EntityTypeBuilder<Estate> builder)
    {
        builder.ToTable("Estate");
        builder.Property(u => u.Title).HasMaxLength(300).IsRequired(true);
        builder.Property(U => U.Description).IsRequired().HasMaxLength(2000);
        builder.Property(u => u.Province).IsRequired().HasMaxLength(100);
        builder.Property(u => u.City).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Address).HasMaxLength(500);
        builder.Property(u => u.DocumentType).IsRequired();
        builder.Property(u => u.EstateType).IsRequired();
        builder.Property(u => u.TransactionType).IsRequired();
    }
}