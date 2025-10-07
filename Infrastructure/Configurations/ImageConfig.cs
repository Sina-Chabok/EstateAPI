using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ImageConfig : IEntityTypeConfiguration<EstateImage>
{
    public void Configure(EntityTypeBuilder<EstateImage> builder)
    {
        builder.Property(u => u.ImagePath).IsRequired().HasMaxLength(500);
            
    }
}