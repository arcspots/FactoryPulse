using FactoryPulse.Domain.Entities;

namespace FactoryPulse.Application.Interfaces;

public interface IEventRepository
{
    Task AddAsync(Event eventEntity);

    Task<List<Event>> GetAllAsync();

    Task<List<Event>> GetByMachineIdAsync(Guid machineId);
}