using FactoryPulse.Domain.Entities;

namespace FactoryPulse.Application.Interfaces;

public interface IMachineRepository
{
    Task<Machine?> GetByIdAsync(Guid id);

    Task<List<Machine>> GetAllAsync();

    Task AddAsync(Machine machine);

    Task UpdateAsync(Machine machine);

    Task DeleteAsync(Guid id);
}