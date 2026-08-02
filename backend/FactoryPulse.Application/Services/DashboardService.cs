using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Enums;

namespace FactoryPulse.Application.Services;

public class DashboardService
{
    private readonly IMachineRepository _machineRepository;
    private readonly ITelemetryRepository _telemetryRepository;
    private readonly IAlertRepository _alertRepository;


    public DashboardService(
        IMachineRepository machineRepository,
        ITelemetryRepository telemetryRepository,
        IAlertRepository alertRepository)
    {
        _machineRepository = machineRepository;
        _telemetryRepository = telemetryRepository;
        _alertRepository = alertRepository;
    }


    public async Task<DashboardStatisticsResponse> GetStatisticsAsync()
    {
        var machines =
            await _machineRepository.GetAllAsync();

        var telemetry =
            await _telemetryRepository.GetAllAsync();

        var alerts =
            await _alertRepository.GetAllAsync();


        return new DashboardStatisticsResponse
        {
            TotalMachines = machines.Count,


            RunningMachines = machines.Count(m =>
                m.Status == MachineStatus.Running),


            StoppedMachines = machines.Count(m =>
                m.Status == MachineStatus.Stopped),


            MaintenanceMachines = machines.Count(m =>
                m.Status == MachineStatus.Maintenance),


            TotalAlerts = alerts.Count,


            CriticalAlerts = alerts.Count(a =>
                a.Severity == AlertSeverity.Critical),



            AverageTemperature =
                telemetry.Any()
                ? telemetry.Average(t => t.Temperature)
                : 0,


            MaxTemperature =
                telemetry.Any()
                ? telemetry.Max(t => t.Temperature)
                : 0,


            MinTemperature =
                telemetry.Any()
                ? telemetry.Min(t => t.Temperature)
                : 0,


            AveragePressure =
                telemetry.Any()
                ? telemetry.Average(t => t.Pressure)
                : 0,


            AverageRPM =
                telemetry.Any()
                ? telemetry.Average(t => t.Rpm)
                : 0,


            TotalProduction =
                telemetry.Any()
                ? telemetry.Sum(t => t.PiecesProduced)
                : 0
        };
    }



    public async Task<List<TelemetryResponse>> GetMachineHistoryAsync(Guid machineId)
    {
        var telemetry =
            await _telemetryRepository.GetByMachineIdAsync(machineId);


        return telemetry
            .OrderBy(t => t.Timestamp)
            .Select(t => new TelemetryResponse
            {
                Temperature = t.Temperature,

                Pressure = t.Pressure,

                Rpm = t.Rpm,

                PiecesProduced = t.PiecesProduced,

                Timestamp = t.Timestamp
            })
            .ToList();
    }
}