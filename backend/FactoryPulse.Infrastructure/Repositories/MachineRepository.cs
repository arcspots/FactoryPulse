using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FactoryPulse.Infrastructure.Repositories;

public class MachineRepository : IMachineRepository
{
    private readonly FactoryPulseDbContext _context;

    public MachineRepository(FactoryPulseDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Machine machine)
    {
        await _context.Machines.AddAsync(machine);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var machine = await _context.Machines.FindAsync(id);

        if (machine is null)
            return;

        _context.Machines.Remove(machine);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Machine>> GetAllAsync()
    {
        return await _context.Machines.ToListAsync();
    }

    public async Task<Machine?> GetByIdAsync(Guid id)
    {
        return await _context.Machines
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task UpdateAsync(Machine machine)
    {
        _context.Machines.Update(machine);
        await _context.SaveChangesAsync();
    }
}