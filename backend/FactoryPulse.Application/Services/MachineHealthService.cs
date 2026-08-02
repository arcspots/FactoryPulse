using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interfaces;

namespace FactoryPulse.Application.Services;

public class MachineHealthService
{
    private readonly IMachineRepository _machineRepository;
    private readonly ITelemetryRepository _telemetryRepository;

    public MachineHealthService(
        IMachineRepository machineRepository,
        ITelemetryRepository telemetryRepository)
    {
        _machineRepository = machineRepository;
        _telemetryRepository = telemetryRepository;
    }


    public async Task<MachineHealthResponse?> GetHealthAsync(Guid machineId)
    {
        var machine = await _machineRepository.GetByIdAsync(machineId);

        if (machine is null)
            return null;


        var telemetry =
            await _telemetryRepository
            .GetLatestByMachineIdAsync(machineId);


        if (telemetry is null)
        {
            return new MachineHealthResponse
            {
                MachineId = machine.Id,
                Name = machine.Name,
                Status = "Offline",
                Health = "Unknown",
                MinutesOffline = 0
            };
        }


        var minutesOffline =
            (int)(DateTime.UtcNow - telemetry.Timestamp)
            .TotalMinutes;


        string health;

        if (minutesOffline <= 5)
        {
            health = "Good";
        }
        else if (minutesOffline <= 30)
        {
            health = "Warning";
        }
        else
        {
            health = "Critical";
        }


        return new MachineHealthResponse
        {
            MachineId = machine.Id,
            Name = machine.Name,
            Status = machine.Status.ToString(),
            LastCommunication = telemetry.Timestamp,
            MinutesOffline = minutesOffline,
            Health = health
        };
    }
}