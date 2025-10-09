using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstateImage> EstateImages { get; set; }
        public DbSet<EstatePrice> EstatePrices { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // همه‌ی کلاس‌های IEntityTypeConfiguration داخل Assembly فعلی (Infrastructure) اعمال می‌شن
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultDbContext).Assembly);
        }

    }
}