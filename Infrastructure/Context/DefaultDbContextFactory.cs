using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Context
{
    public class DefaultDbContextFactory : IDesignTimeDbContextFactory<DefaultDbContext>
    {
        public DefaultDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DefaultDbContext>();

            // کانکشن استرینگ رو اینجا بذار
            optionsBuilder.UseSqlServer("Server=.;Database=Estate;Trusted_Connection=True;TrustServerCertificate=True;");

            return new DefaultDbContext(optionsBuilder.Options);
        }
    }
}