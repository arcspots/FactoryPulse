using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Engines;
using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Enums;

namespace FactoryPulse.Application.Services;

public class MachineService
{
    private readonly IMachineRepository _machineRepository;
    private readonly ITelemetryRepository _telemetryRepository;
    private readonly IAlertRepository _alertRepository;

    public MachineService(
        IMachineRepository machineRepository,
        ITelemetryRepository telemetryRepository,
        IAlertRepository alertRepository)
    {
        _machineRepository = machineRepository;
        _telemetryRepository = telemetryRepository;
        _alertRepository = alertRepository;
    }

    public async Task<MachineResponse> CreateMachineAsync(MachineRequest request)
    {
        var machine = new Domain.Entities.Machine(
            request.Name,
            request.Sector);

        await _machineRepository.AddAsync(machine);

        return new MachineResponse
        {
            Id = machine.Id,
            Name = machine.Name,
            Sector = machine.Sector,
            Status = machine.Status.ToString(),
            CreatedAt = machine.CreatedAt
        };
    }

    public async Task<List<MachineResponse>> GetAllMachinesAsync()
    {
        var machines = await _machineRepository.GetAllAsync();

        return machines.Select(machine => new MachineResponse
        {
            Id = machine.Id,
            Name = machine.Name,
            Sector = machine.Sector,
            Status = machine.Status.ToString(),
            CreatedAt = machine.CreatedAt
        }).ToList();
    }

    public async Task<MachineResponse?> GetMachineByIdAsync(Guid id)
    {
        var machine = await _machineRepository.GetByIdAsync(id);

        if (machine is null)
            return null;

        return new MachineResponse
        {
            Id = machine.Id,
            Name = machine.Name,
            Sector = machine.Sector,
            Status = machine.Status.ToString(),
            CreatedAt = machine.CreatedAt
        };
    }

    public async Task<List<TelemetryResponse>> GetTelemetryHistoryAsync(Guid machineId)
    {
        var telemetry = await _telemetryRepository.GetByMachineIdAsync(machineId);

        return telemetry.Select(t => new TelemetryResponse
        {
            Temperature = t.Temperature,
            Pressure = t.Pressure,
            Rpm = t.Rpm,
            PiecesProduced = t.PiecesProduced,
            Timestamp = t.Timestamp
        }).ToList();
    }

    public async Task<MachineDashboardResponse?> GetDashboardAsync(Guid machineId)
    {
        var machine = await _machineRepository.GetByIdAsync(machineId);

        if (machine is null)
            return null;

        var latestTelemetry =
            await _telemetryRepository.GetLatestByMachineIdAsync(machineId);

        var recentTelemetry =
            await _telemetryRepository.GetByMachineIdAsync(machineId);

        var alerts =
            await _alertRepository.GetByMachineIdAsync(machineId);


        int healthScore = 100;
        string healthStatus = "Unknown";


        if (latestTelemetry is not null)
        {
            var health = HealthEngine.Calculate(
                latestTelemetry.Temperature,
                latestTelemetry.Pressure,
                latestTelemetry.Rpm);

            healthScore = health.Score;
            healthStatus = health.Status;
        }


        var activeAlerts = alerts
            .Where(a => a.IsActive)
            .ToList();


        return new MachineDashboardResponse
        {
            MachineId = machine.Id,
            Name = machine.Name,
            Sector = machine.Sector,
            Status = machine.Status.ToString(),

            HealthStatus = healthStatus,
            HealthScore = healthScore,

            LastTemperature = latestTelemetry?.Temperature,
            LastPressure = latestTelemetry?.Pressure,
            LastRPM = latestTelemetry?.Rpm,
            LastPiecesProduced = latestTelemetry?.PiecesProduced,
            LastTelemetryAt = latestTelemetry?.Timestamp,


            ActiveAlerts = activeAlerts.Count(a =>
                a.Severity == AlertSeverity.High ||
                a.Severity == AlertSeverity.Critical),


            Alerts = activeAlerts.Select(a => new AlertResponse
            {
                Id = a.Id,
                MachineId = a.MachineId,
                Message = a.Message,
                Severity = a.Severity.ToString(),
                CreatedAt = a.CreatedAt
            }).ToList(),


            RecentTelemetry = recentTelemetry
                .Take(5)
                .Select(t => new TelemetryResponse
                {
                    Temperature = t.Temperature,
                    Pressure = t.Pressure,
                    Rpm = t.Rpm,
                    PiecesProduced = t.PiecesProduced,
                    Timestamp = t.Timestamp
                })
                .ToList()
        };
    }
}