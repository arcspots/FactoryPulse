using FactoryPulse.Domain.Entities;

namespace FactoryPulse.Application.Interfaces;

public interface IAlertRepository
{
    Task AddAsync(Alert alert);

    Task UpdateAsync(Alert alert);

    Task<List<Alert>> GetByMachineIdAsync(Guid machineId);

    Task<List<Alert>> GetAllAsync();

    Task<Alert?> GetActiveByMachineIdAsync(Guid machineId);
}