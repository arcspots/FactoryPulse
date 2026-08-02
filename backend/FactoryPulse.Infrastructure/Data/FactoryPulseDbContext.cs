using FactoryPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FactoryPulse.Infrastructure.Data;

public class FactoryPulseDbContext : DbContext
{
    public FactoryPulseDbContext(DbContextOptions<FactoryPulseDbContext> options)
        : base(options)
    {
    }

    public DbSet<Machine> Machines => Set<Machine>();

    public DbSet<Telemetry> Telemetries => Set<Telemetry>();

    public DbSet<Alert> Alerts => Set<Alert>();

    public DbSet<Event> Events => Set<Event>();

}