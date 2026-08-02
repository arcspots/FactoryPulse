using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FactoryPulse.Infrastructure.Data;

public class FactoryPulseDbContextFactory
    : IDesignTimeDbContextFactory<FactoryPulseDbContext>
{
    public FactoryPulseDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FactoryPulseDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=FactoryPulseDb;Trusted_Connection=True;TrustServerCertificate=True;"
        );

        return new FactoryPulseDbContext(optionsBuilder.Options);
    }
}