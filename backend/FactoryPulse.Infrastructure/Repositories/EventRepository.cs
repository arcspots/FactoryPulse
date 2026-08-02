using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FactoryPulse.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly FactoryPulseDbContext _context;


    public EventRepository(FactoryPulseDbContext context)
    {
        _context = context;
    }


    public async Task AddAsync(Event eventEntity)
    {
        await _context.Events.AddAsync(eventEntity);

        await _context.SaveChangesAsync();
    }


    public async Task<List<Event>> GetAllAsync()
    {
        return await _context.Events
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }


    public async Task<List<Event>> GetByMachineIdAsync(Guid machineId)
    {
        return await _context.Events
            .Where(e => e.MachineId == machineId)
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }
}