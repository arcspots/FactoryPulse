using FactoryPulse.Application.DTOs;
using FactoryPulse.Application.Exceptions;
using FactoryPulse.Application.Interfaces;
using FactoryPulse.Domain.Entities;
using FactoryPulse.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace FactoryPulse.Application.Services;

public class TelemetryService
{
    private readonly IMachineRepository _machineRepository;
    private readonly ITelemetryRepository _telemetryRepository;
    private readonly IAlertRepository _alertRepository;
    private readonly IDashboardNotifier _dashboardNotifier;
    private readonly ILogger<TelemetryService> _logger;

    public TelemetryService(
        IMachineRepository machineRepository,
        ITelemetryRepository telemetryRepository,
        IAlertRepository alertRepository,
        IDashboardNotifier dashboardNotifier,
        ILogger<TelemetryService> logger)
    {
        _machineRepository = machineRepository;
        _telemetryRepository = telemetryRepository;
        _alertRepository = alertRepository;
        _dashboardNotifier = dashboardNotifier;
        _logger = logger;
    }


    public async Task ReceiveTelemetryAsync(TelemetryRequest request)
    {
        _logger.LogInformation(
            "Receiving telemetry from machine {MachineId}",
            request.MachineId);


        var machine = await _machineRepository.GetByIdAsync(request.MachineId);

        if (machine is null)
        {
            _logger.LogWarning(
                "Machine {MachineId} not found",
                request.MachineId);

            throw new NotFoundException("Machine not found.");
        }


        var telemetry = new Telemetry(
            request.MachineId,
            request.Temperature,
            request.Pressure,
            request.Rpm,
            request.PiecesProduced);


        await _telemetryRepository.AddAsync(telemetry);


        _logger.LogInformation(
            "Telemetry stored successfully for machine {MachineId}",
            request.MachineId);



        var activeAlert =
            await _alertRepository.GetActiveByMachineIdAsync(request.MachineId);



        if (request.Temperature > 90)
        {
            if (activeAlert is null)
            {
                var alert = new Alert(
                    request.MachineId,
                    $"High temperature detected ({request.Temperature}°C)",
                    AlertSeverity.High);


                await _alertRepository.AddAsync(alert);


                _logger.LogWarning(
                    "High temperature alert created for machine {MachineId}. Temperature: {Temperature}°C",
                    request.MachineId,
                    request.Temperature);
            }
        }


        if (request.Temperature < 85)
        {
            if (activeAlert is not null)
            {
                activeAlert.Resolve();

                await _alertRepository.UpdateAsync(activeAlert);


                _logger.LogInformation(
                    "Alert resolved for machine {MachineId}",
                    request.MachineId);
            }
        }



        await _dashboardNotifier.NotifyDashboardUpdated(request.MachineId);


        _logger.LogInformation(
            "Dashboard update notification sent for machine {MachineId}",
            request.MachineId);
    }
}