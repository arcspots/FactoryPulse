using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FactoryPulse.Infrastructure.Repositories;

public class AlertRepository : IAlertRepository
{
    private readonly FactoryPulseDbContext _context;

    public AlertRepository(FactoryPulseDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Alert alert)
    {
        await _context.Alerts.AddAsync(alert);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Alert alert)
    {
        _context.Alerts.Update(alert);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Alert>> GetAllAsync()
    {
        return await _context.Alerts.ToListAsync();
    }

    public async Task<List<Alert>> GetByMachineIdAsync(Guid machineId)
    {
        return await _context.Alerts
            .Where(a => a.MachineId == machineId)
            .ToListAsync();
    }

    public async Task<Alert?> GetActiveByMachineIdAsync(Guid machineId)
    {
        return await _context.Alerts
            .FirstOrDefaultAsync(a =>
                a.MachineId == machineId &&
                a.IsActive);
    }
}