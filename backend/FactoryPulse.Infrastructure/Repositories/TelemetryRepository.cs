using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FactoryPulse.Infrastructure.Repositories;

public class TelemetryRepository : ITelemetryRepository
{
    private readonly FactoryPulseDbContext _context;

    public TelemetryRepository(FactoryPulseDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Telemetry telemetry)
    {
        await _context.Telemetries.AddAsync(telemetry);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Telemetry>> GetByMachineIdAsync(Guid machineId)
    {
        return await _context.Telemetries
            .Where(t => t.MachineId == machineId)
            .OrderByDescending(t => t.Timestamp)
            .ToListAsync();
    }

    public async Task<Telemetry?> GetLatestByMachineIdAsync(Guid machineId)
    {
        return await _context.Telemetries
            .Where(t => t.MachineId == machineId)
            .OrderByDescending(t => t.Timestamp)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Telemetry>> GetAllAsync()
    {
        return await _context.Telemetries
            .OrderByDescending(t => t.Timestamp)
            .ToListAsync();
    }
}