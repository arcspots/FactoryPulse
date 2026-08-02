using FactoryPulse.Domain.Entities;

namespace FactoryPulse.Application.Interfaces;

public interface ITelemetryRepository
{
    Task AddAsync(Telemetry telemetry);

    Task<List<Telemetry>> GetByMachineIdAsync(Guid machineId);

    Task<Telemetry?> GetLatestByMachineIdAsync(Guid machineId);

    Task<List<Telemetry>> GetAllAsync();
}