using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PriceConfig : IEntityTypeConfiguration<EstatePrice>
{
    public void Configure(EntityTypeBuilder<EstatePrice> builder)
    {
        builder.Property(u => u.PriceType).IsRequired();
        builder.Property(u => u.Amount).IsRequired();
    }
}