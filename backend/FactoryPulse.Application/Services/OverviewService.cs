using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Engines;
using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Enums;

namespace FactoryPulse.Application.Services;

public class OverviewService
{
    private readonly IMachineRepository _machineRepository;
    private readonly ITelemetryRepository _telemetryRepository;
    private readonly IAlertRepository _alertRepository;

    public OverviewService(
        IMachineRepository machineRepository,
        ITelemetryRepository telemetryRepository,
        IAlertRepository alertRepository)
    {
        _machineRepository = machineRepository;
        _telemetryRepository = telemetryRepository;
        _alertRepository = alertRepository;
    }

    public async Task<OverviewDto> GetOverviewAsync()
    {
        var machines = await _machineRepository.GetAllAsync();

        var telemetry = await _telemetryRepository.GetAllAsync();

        var alerts = await _alertRepository.GetAllAsync();

        var latestTelemetry = telemetry
            .GroupBy(t => t.MachineId)
            .Select(g => g
                .OrderByDescending(x => x.Timestamp)
                .First())
            .ToList();

        var averageHealth = latestTelemetry.Any()
            ? latestTelemetry
                .Average(t => HealthEngine.Calculate(
                    t.Temperature,
                    t.Pressure,
                    t.Rpm).Score)
            : 100;

        var machineOverview = machines
            .Select(machine =>
            {
                var lastTelemetry = latestTelemetry
                    .FirstOrDefault(t => t.MachineId == machine.Id);

                var machineAlerts = alerts.Count(a =>
                    a.MachineId == machine.Id &&
                    a.IsActive);

                string healthStatus = "Unknown";
                int healthScore = 100;

                if (lastTelemetry != null)
                {
                    var health = HealthEngine.Calculate(
                        lastTelemetry.Temperature,
                        lastTelemetry.Pressure,
                        lastTelemetry.Rpm);

                    healthStatus = health.Status;
                    healthScore = health.Score;
                }

                return new OverviewMachineDto
                {
                    MachineId = machine.Id,
                    Name = machine.Name,
                    Sector = machine.Sector,
                    Status = machine.Status.ToString(),

                    HealthStatus = healthStatus,
                    HealthScore = healthScore,

                    Temperature = lastTelemetry?.Temperature ?? 0,
                    Pressure = lastTelemetry?.Pressure ?? 0,
                    RPM = lastTelemetry?.Rpm ?? 0,
                    PiecesProduced = lastTelemetry?.PiecesProduced ?? 0,

                    ActiveAlerts = machineAlerts,

                    LastTelemetryAt =
                        lastTelemetry?.Timestamp ?? DateTime.MinValue
                };
            })
            .ToList();

        return new OverviewDto
        {
            TotalMachines = machines.Count,

            RunningMachines = machines.Count(m =>
                m.Status == MachineStatus.Running),

            WarningMachines = machineOverview.Count(m =>
                m.HealthStatus == "Warning"),

            CriticalMachines = machineOverview.Count(m =>
                m.HealthStatus == "Critical" ||
                m.HealthStatus == "Emergency"),

            OfflineMachines = machines.Count(m =>
                m.Status == MachineStatus.Stopped),

            ActiveAlerts = alerts.Count(a => a.IsActive),

            AverageTemperature = latestTelemetry.Any()
                ? latestTelemetry.Average(t => t.Temperature)
                : 0,

            AverageHealthScore = averageHealth,

            TotalProduction = latestTelemetry.Sum(t =>
                t.PiecesProduced),

            LastUpdate = DateTime.UtcNow,

            Machines = machineOverview
        };
    }
}